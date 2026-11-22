
using LifeInsurer.Api.Enums;

namespace LifeInsurer.Api.Models;

public class ClaimAssessment
{
    public int Id { get; set; }

    public int ClaimId { get; set; }
    public Claim Claim { get; set; } = null!;

    public int OfficerId { get; set; }

    public Recommendation Recommendation { get; set; }

    public string AssessmentRemarks { get; set; }
        = string.Empty;

    public decimal RecommendedAmount { get; set; }

    public DateTime AssessedAt { get; set; }
        = DateTime.UtcNow;
}
