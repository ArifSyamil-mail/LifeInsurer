
using LifeInsurer.Api.Enums;

namespace LifeInsurer.Api.Models;

public class ClaimInformationRequest
{
    public int Id { get; set; }

    public int ClaimId { get; set; }
    public Claim Claim { get; set; } = null!;

    public int? RequestedByUserId { get; set; }

    public string Description { get; set; } = string.Empty;

    public InformationRequestStatus Status { get; set; }
        = InformationRequestStatus.Open;

    public DateTime RequestedAt { get; set; }
        = DateTime.UtcNow;

    public DateTime? ResolvedAt { get; set; }
}
