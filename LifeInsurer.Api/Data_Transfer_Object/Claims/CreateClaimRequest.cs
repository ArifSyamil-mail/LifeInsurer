
using System.ComponentModel.DataAnnotations;

namespace LifeInsurer.Api.DTOs.Claims;

public class CreateClaimRequest
{
    [Required]
    [Range(1, int.MaxValue)]
    public int ClaimantId { get; set; }

    [Required]
    [StringLength(50)]
    public string PolicyNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(10)]
    public string MarketCode { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string ClaimType { get; set; } = string.Empty;

    [Required]
    [StringLength(2000)]
    public string IncidentDescription { get; set; } = string.Empty;

    [Required]
    public DateTime? IncidentDate { get; set; }

    [Range(typeof(decimal), "0.01", "999999999")]
    public decimal EstimatedLiability { get; set; }
}
