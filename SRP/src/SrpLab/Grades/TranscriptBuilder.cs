namespace SrpLab.Grades;

public sealed class TranscriptBuilder
{
    public string Build(
        string studentId,
        string fullName,
        decimal average,
        string letter,
        bool honorRoll)
    {
        return
            $"TRANSCRIPT\n" +
            $"Student: {fullName} ({studentId})\n" +
            $"Average: {average}\n" +
            $"Letter: {letter}\n" +
            $"Honor: {honorRoll}\n";
    }
}
