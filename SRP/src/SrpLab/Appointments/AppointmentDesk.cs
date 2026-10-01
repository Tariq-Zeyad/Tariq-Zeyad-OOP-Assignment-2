namespace SrpLab.Appointments;

public sealed class AppointmentDesk
{
    private readonly HashSet<DateTimeOffset> _booked = new();

    private readonly BusinessHoursChecker _businessHoursChecker = new();

    private readonly AppointmentSlotFinder _slotFinder;

    private readonly AppointmentCalendarExporter _calendarExporter = new();

    private readonly AppointmentSmsBuilder _smsBuilder = new();

    public TimeOnly Open { get; }

    public TimeOnly Close { get; }

    public int SlotMinutes { get; }

    public AppointmentDesk(
        TimeOnly open,
        TimeOnly close,
        int slotMinutes)
    {
        Open = open;
        Close = close;
        SlotMinutes = slotMinutes;

        _slotFinder =
            new AppointmentSlotFinder(
                _businessHoursChecker);
    }

    public bool IsWithinBusinessHours(
        DateTimeOffset when)
    {
        return _businessHoursChecker.IsWithin(
            when,
            Open,
            Close,
            SlotMinutes);
    }

    public DateTimeOffset? FindNextSlot(
        DateTimeOffset from,
        int searchHours)
    {
        return _slotFinder.FindNext(
            from,
            searchHours,
            Open,
            Close,
            SlotMinutes,
            _booked);
    }

    public bool TryBook(
        DateTimeOffset slot)
    {
        if (!IsWithinBusinessHours(slot) ||
            _booked.Contains(slot))
        {
            return false;
        }

        _booked.Add(slot);

        return true;
    }

    public string ToIcs(
        DateTimeOffset slot,
        string patientName,
        string clinician)
    {
        return _calendarExporter.Export(
            slot,
            SlotMinutes,
            patientName,
            clinician);
    }

    public string SmsReminder(
        DateTimeOffset slot,
        string clinicPhone)
    {
        return _smsBuilder.Build(
            slot,
            clinicPhone);
    }
}
