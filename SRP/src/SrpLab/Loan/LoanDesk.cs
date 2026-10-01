namespace SrpLab.Loan;

public sealed class LoanDesk
{
    public decimal RequestedAmount { get; }

    public int CreditScore { get; }

    public int EmploymentMonths { get; }

    public bool HasCollateral { get; }

    private readonly RiskScoreCalculator _riskScoreCalculator = new();
    private readonly LoanEligibilityChecker _eligibilityChecker = new();
    private readonly LoanDocumentRequirement _documentRequirement = new();
    private readonly LoanDecisionLetterBuilder _decisionLetterBuilder = new();
    private readonly UnderwriterCsvExporter _csvExporter = new();

    public LoanDesk(
        decimal requestedAmount,
        int creditScore,
        int employmentMonths,
        bool hasCollateral)
    {
        RequestedAmount = requestedAmount;
        CreditScore = creditScore;
        EmploymentMonths = employmentMonths;
        HasCollateral = hasCollateral;
    }

    public decimal RiskScore()
    {
        return _riskScoreCalculator.Calculate(
            RequestedAmount,
            CreditScore,
            EmploymentMonths,
            HasCollateral);
    }

    public bool IsEligible()
    {
        return _eligibilityChecker.IsEligible(
            RiskScore(),
            CreditScore);
    }

    public IReadOnlyList<string> RequiredDocuments()
    {
        return _documentRequirement.GetRequiredDocuments(
            RequestedAmount,
            HasCollateral,
            EmploymentMonths,
            IsEligible());
    }

    public string DecisionLetter(string applicantName)
    {
        return _decisionLetterBuilder.Build(
            applicantName,
            RequestedAmount,
            RiskScore(),
            IsEligible(),
            RequiredDocuments());
    }

    public string UnderwriterCsvRow(string applicationId)
    {
        return _csvExporter.Export(
            applicationId,
            CreditScore,
            EmploymentMonths,
            HasCollateral,
            RiskScore(),
            IsEligible());
    }
}
