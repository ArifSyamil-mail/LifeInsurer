
namespace LifeInsurer.Api.Models;

public class ClaimDocument
{
    public int Id { get; set; }

    public int ClaimId { get; set; }
    public Claim Claim { get; set; } = null!;

    public string FileName { get; set; } = string.Empty;

    public string DocumentType { get; set; } = string.Empty;

    // Where the actual file is stored
    public string FilePath { get; set; } = string.Empty;

    public int UploadedByUserId { get; set; }

    public DateTime UploadedAt { get; set; }
        = DateTime.UtcNow;
}
