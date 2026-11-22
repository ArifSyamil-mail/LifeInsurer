
using LifeInsurer.Api.Enums;

namespace LifeInsurer.Api.Models;

public class Claim
{
    public int Id { get; set; }

    public string ClaimNumber { get; set; } = string.Empty;

    // Claimant
    public int ClaimantId { get; set; }
    public User Claimant { get; set; } = null!;

    // Optional assigned Claim Officer
    public int? AssignedOfficerId { get; set; }
    public User? AssignedOfficer { get; set; }

    public string PolicyNumber { get; set; } = string.Empty;

    // Market code is configurable rather than assuming
    // which six markets the assignment refers to.
    public string MarketCode { get; set; } = string.Empty;

    public string ClaimType { get; set; } = string.Empty;

    public string IncidentDescription { get; set; } = string.Empty;

    public DateTime IncidentDate { get; set; }

    public decimal EstimatedLiability { get; set; }

    public ClaimStatus Status { get; set; }
        = ClaimStatus.Submitted;

    public DateTime SubmittedAt { get; set; }
        = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public ICollection<ClaimDocument> Documents { get; set; }
        = new List<ClaimDocument>();

    public ICollection<ClaimInformationRequest> InformationRequests
        { get; set; } = new List<ClaimInformationRequest>();

    public ICollection<ClaimAssessment> Assessments { get; set; }
        = new List<ClaimAssessment>();

    public ICollection<ClaimReview> Reviews { get; set; }
        = new List<ClaimReview>();

    public ICollection<ClaimActivity> Activities { get; set; }
        = new List<ClaimActivity>();
}
