
using LifeInsurer.Api.Enums;

namespace LifeInsurer.Api.DTOs.Claims;

public class ClaimResponse
{
    public int Id { get; set; }

    public string ClaimNumber { get; set; } = string.Empty;

    public string PolicyNumber { get; set; } = string.Empty;

    public string MarketCode { get; set; } = string.Empty;

    public string ClaimType { get; set; } = string.Empty;

    public string IncidentDescription { get; set; } = string.Empty;

    public DateTime IncidentDate { get; set; }

    public decimal EstimatedLiability { get; set; }

    public ClaimStatus Status { get; set; }

    public DateTime SubmittedAt { get; set; }
}
