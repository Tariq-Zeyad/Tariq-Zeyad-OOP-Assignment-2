namespace SrpLab.Appointments;

public sealed class AppointmentSlotFinder
{
    private readonly BusinessHoursChecker _businessHoursChecker;

    public AppointmentSlotFinder(
        BusinessHoursChecker businessHoursChecker)
    {
        _businessHoursChecker = businessHoursChecker;
    }

    public DateTimeOffset? FindNext(
        DateTimeOffset from,
        int searchHours,
        TimeOnly open,
        TimeOnly close,
        int slotMinutes,
        IReadOnlySet<DateTimeOffset> booked)
    {
        var cursor = Align(
            from,
            slotMinutes);

        var end = from.AddHours(searchHours);

        while (cursor < end)
        {
            var withinBusinessHours =
                _businessHoursChecker.IsWithin(
                    cursor,
                    open,
                    close,
                    slotMinutes);

            if (withinBusinessHours &&
                !booked.Contains(cursor))
            {
                return cursor;
            }

            cursor = cursor.AddMinutes(slotMinutes);
        }

        return null;
    }

    private static DateTimeOffset Align(
        DateTimeOffset from,
        int slotMinutes)
    {
        var minutes =
            from.Minute -
            (from.Minute % slotMinutes);

        return new DateTimeOffset(
            from.Year,
            from.Month,
            from.Day,
            from.Hour,
            minutes,
            0,
            from.Offset);
    }
}
