namespace SrpLab.Appointments;

public sealed class AppointmentSmsBuilder
{
    public string Build(
        DateTimeOffset slot,
        string clinicPhone)
    {
        return
            $"Reminder: appointment " +
            $"{slot:MMM dd HH:mm}. " +
            $"Call {clinicPhone} to reschedule.";
    }
}
