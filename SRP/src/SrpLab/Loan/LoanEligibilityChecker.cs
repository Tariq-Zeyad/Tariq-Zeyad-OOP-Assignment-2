namespace SrpLab.Loan;

public sealed class LoanEligibilityChecker
{
    public bool IsEligible(
        decimal riskScore,
        int creditScore)
    {
        return riskScore >= 55m &&
               creditScore >= 580;
    }
}
