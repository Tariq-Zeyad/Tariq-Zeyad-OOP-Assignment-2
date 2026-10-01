namespace SrpLab.Enrollment;

public sealed class WaitlistManager
{
    private readonly List<string> _students = new();

    public bool Contains(string studentEmail)
    {
        return _students.Contains(
            studentEmail,
            StringComparer.OrdinalIgnoreCase);
    }

    public string Add(string studentEmail)
    {
        _students.Add(studentEmail);

        return $"WAITLIST:{_students.Count}";
    }

    public int Position(string studentEmail)
    {
        var index = _students.FindIndex(
            x => x.Equals(
                studentEmail,
                StringComparison.OrdinalIgnoreCase));

        return index < 0 ? -1 : index + 1;
    }

    public string RemoveFirst()
    {
        var student = _students[0];
        _students.RemoveAt(0);

        return student;
    }

    public int Count => _students.Count;
}
