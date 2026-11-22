
using LifeInsurer.Api.Enums;

namespace LifeInsurer.Api.Models;

public class User
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public UserRole Role { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Claims submitted by this user
    public ICollection<Claim> SubmittedClaims { get; set; }
        = new List<Claim>();
}
