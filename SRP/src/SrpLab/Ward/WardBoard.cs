namespace SrpLab.Ward;

public sealed class WardBoard
{
    private readonly Dictionary<int, string> _bedPatient = new();
    private readonly Dictionary<int, int> _vitalsScore = new();

    private readonly AcuityCalculator _acuityCalculator = new();
    private readonly PagerAlertService _pagerAlertService = new();
    private readonly HandoffNoteBuilder _handoffNoteBuilder = new();
    private readonly CensusCsvExporter _censusCsvExporter = new();

    public void AssignBed(
        int bed,
        string patientId,
        int heartRate,
        int spo2)
    {
        if (bed <= 0)
            throw new ArgumentOutOfRangeException(nameof(bed));

        if (string.IsNullOrWhiteSpace(patientId))
            throw new ArgumentException("patient required");

        var patient = patientId.Trim().ToUpperInvariant();

        var acuity =
            _acuityCalculator.Calculate(heartRate, spo2);

        _bedPatient[bed] = patient;
        _vitalsScore[bed] = acuity;

        _pagerAlertService.CheckAndAddAlert(bed, acuity);
    }

    public int ScoreAcuity(int heartRate, int spo2)
    {
        return _acuityCalculator.Calculate(heartRate, spo2);
    }

    public string BuildHandoffNote(int bed)
    {
        _bedPatient.TryGetValue(bed, out var patient);

        var acuity = _vitalsScore.TryGetValue(bed, out var score)
            ? score
            : 0;

        return _handoffNoteBuilder.Build(
            bed,
            patient,
            acuity);
    }

    public IReadOnlyList<string> DrainPagerLog()
    {
        return _pagerAlertService.DrainLog();
    }

    public string ExportCensusCsv()
    {
        return _censusCsvExporter.Export(
            _bedPatient,
            _vitalsScore);
    }
}
