namespace SrpLab.Grades;

public sealed class GradeCsvExporter
{
    public string Export(
        IReadOnlyDictionary<string, (decimal Average, string Letter, bool Honor)> students)
    {
        var rows = new List<string>
        {
            "studentId,average,letter,honor"
        };

        foreach (var student in students.Keys.OrderBy(x => x))
        {
            var data = students[student];

            rows.Add(
                $"{student}," +
                $"{data.Average}," +
                $"{data.Letter}," +
                $"{(data.Honor ? 1 : 0)}");
        }

        return string.Join('\n', rows);
    }
}
