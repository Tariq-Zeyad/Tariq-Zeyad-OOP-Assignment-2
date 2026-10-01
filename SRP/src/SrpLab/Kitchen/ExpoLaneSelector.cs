namespace SrpLab.Kitchen;

public sealed class ExpoLaneSelector
{
    public string Select(
        IReadOnlyList<string> allergens,
        int estimatedMinutes)
    {
        if (allergens.Count > 0)
            return "LANE-ALLERGY";

        return estimatedMinutes > 20
            ? "LANE-SLOW"
            : "LANE-FAST";
    }
}
