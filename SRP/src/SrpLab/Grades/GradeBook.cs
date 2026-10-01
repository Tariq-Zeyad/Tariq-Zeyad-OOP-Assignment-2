namespace SrpLab.Grades;

public sealed class GradeBook
{
    private readonly Dictionary<string, List<decimal>> _scores =
        new(StringComparer.OrdinalIgnoreCase);

    private readonly GradeAverageCalculator _averageCalculator = new();
    private readonly GradePolicy _gradePolicy = new();
    private readonly HonorRollPolicy _honorRollPolicy = new();
    private readonly TranscriptBuilder _transcriptBuilder = new();
    private readonly GradeCsvExporter _csvExporter = new();

    public void Record(string studentId, decimal score)
    {
        if (score is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(score));

        if (!_scores.TryGetValue(studentId, out var list))
        {
            list = new List<decimal>();
            _scores[studentId] = list;
        }

        list.Add(score);
    }

    public decimal Average(string studentId)
    {
        if (!_scores.TryGetValue(studentId, out var list) ||
            list.Count == 0)
        {
            return 0m;
        }

        return _averageCalculator.Calculate(list);
    }

    public string Letter(string studentId)
    {
        var average = Average(studentId);

        return _gradePolicy.GetLetter(average);
    }

    public bool MeetsHonorRoll(string studentId)
    {
        var average = Average(studentId);
        var letter = Letter(studentId);

        return _honorRollPolicy.MeetsRequirements(
            average,
            letter);
    }

    public string TranscriptPlain(
        string studentId,
        string fullName)
    {
        var average = Average(studentId);
        var letter = Letter(studentId);
        var honor = MeetsHonorRoll(studentId);

        return _transcriptBuilder.Build(
            studentId,
            fullName,
            average,
            letter,
            honor);
    }

    public string ExportCsv()
    {
        var students =
            new Dictionary<string, (decimal Average, string Letter, bool Honor)>(
                StringComparer.OrdinalIgnoreCase);

        foreach (var id in _scores.Keys)
        {
            students[id] = (
                Average(id),
                Letter(id),
                MeetsHonorRoll(id));
        }

        return _csvExporter.Export(students);
    }
}
