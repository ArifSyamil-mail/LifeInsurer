
using LifeInsurer.Api.Enums;

namespace LifeInsurer.Api.Models;

public class ClaimReview
{
    public int Id { get; set; }

    public int ClaimId { get; set; }
    public Claim Claim { get; set; } = null!;

    public int AssessmentId { get; set; }
    public ClaimAssessment Assessment { get; set; } = null!;

    public int ApproverId { get; set; }

    public ReviewDecision Decision { get; set; }

    // Used when the Approver returns an assessment
    public ErrorSource? ErrorSource { get; set; }

    public string Comments { get; set; } = string.Empty;

    public DateTime ReviewedAt { get; set; }
        = DateTime.UtcNow;
}
