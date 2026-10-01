namespace SrpLab.Enrollment;

public sealed class EnrollmentManager
{
    private readonly HashSet<string> _seated =
        new(StringComparer.OrdinalIgnoreCase);

    private readonly WaitlistManager _waitlist;

    public EnrollmentManager(WaitlistManager waitlist)
    {
        _waitlist = waitlist;
    }

    public string Register(
        string studentEmail,
        int capacity)
    {
        if (string.IsNullOrWhiteSpace(studentEmail))
            throw new ArgumentException("email");

        var email = studentEmail.Trim();

        if (_seated.Contains(email) ||
            _waitlist.Contains(email))
        {
            return "ALREADY_REGISTERED";
        }

        if (_seated.Count < capacity)
        {
            _seated.Add(email);
            return "SEATED";
        }

        return _waitlist.Add(email);
    }

    public bool IsSeated(string studentEmail)
    {
        return _seated.Contains(studentEmail);
    }

    public int SeatedCount => _seated.Count;

    public void AddToSeat(string studentEmail)
    {
        _seated.Add(studentEmail);
    }
}
