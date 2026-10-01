namespace SrpLab.Enrollment;

public sealed class CourseEnrollmentDesk
{
    public int Capacity { get; }

    public decimal Tuition { get; }

    public string CourseCode { get; }

    private readonly WaitlistManager _waitlist = new();

    private readonly EnrollmentManager _enrollment;

    private readonly WelcomePacketBuilder _welcomePacketBuilder = new();

    private readonly TuitionInvoiceBuilder _tuitionInvoiceBuilder = new();

    public CourseEnrollmentDesk(
        string courseCode,
        int capacity,
        decimal tuition)
    {
        CourseCode = courseCode;
        Capacity = capacity;
        Tuition = tuition;

        _enrollment =
            new EnrollmentManager(_waitlist);
    }

    public string Register(string studentEmail)
    {
        return _enrollment.Register(
            studentEmail,
            Capacity);
    }

    public int WaitlistPosition(string studentEmail)
    {
        return _waitlist.Position(studentEmail);
    }

    public string WelcomePacketMarkdown(
        string studentEmail,
        string studentName)
    {
        var status = _enrollment.IsSeated(studentEmail)
            ? "confirmed seat"
            : $"waitlist #{WaitlistPosition(studentEmail)}";

        return _welcomePacketBuilder.Build(
            CourseCode,
            studentName,
            status);
    }

    public string TuitionInvoiceLine(
        string studentEmail)
    {
        var isSeated =
            _enrollment.IsSeated(studentEmail);

        return _tuitionInvoiceBuilder.Build(
            CourseCode,
            Tuition,
            isSeated);
    }

    public void PromoteFromWaitlist(int seats)
    {
        while (
            seats > 0 &&
            _waitlist.Count > 0 &&
            _enrollment.SeatedCount < Capacity)
        {
            var next = _waitlist.RemoveFirst();

            _enrollment.AddToSeat(next);

            seats--;
        }
    }
}
