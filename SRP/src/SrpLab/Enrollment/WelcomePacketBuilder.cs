namespace SrpLab.Enrollment;

public sealed class WelcomePacketBuilder
{
    public string Build(
        string courseCode,
        string studentName,
        string status)
    {
        return
            $"# Welcome to {courseCode}\n" +
            $"Hi {studentName},\n" +
            $"Your status: **{status}**.\n" +
            $"Bring a laptop. Discord onboarding link: " +
            $"https://example.invalid/{courseCode.ToLowerInvariant()}\n";
    }
}
