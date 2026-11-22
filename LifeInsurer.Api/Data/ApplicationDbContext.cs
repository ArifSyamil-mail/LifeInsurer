
using LifeInsurer.Api.Enums;
using LifeInsurer.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeInsurer.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Claim> Claims => Set<Claim>();

    public DbSet<ClaimDocument> ClaimDocuments =>
        Set<ClaimDocument>();

    public DbSet<ClaimInformationRequest> ClaimInformationRequests =>
        Set<ClaimInformationRequest>();

    public DbSet<ClaimAssessment> ClaimAssessments =>
        Set<ClaimAssessment>();

    public DbSet<ClaimReview> ClaimReviews =>
        Set<ClaimReview>();

    public DbSet<ClaimActivity> ClaimActivities =>
        Set<ClaimActivity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Store enums as readable strings in SQLite.
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>();

        modelBuilder.Entity<Claim>()
            .Property(c => c.Status)
            .HasConversion<string>();

        modelBuilder.Entity<ClaimAssessment>()
            .Property(a => a.Recommendation)
            .HasConversion<string>();

        modelBuilder.Entity<ClaimReview>()
            .Property(r => r.Decision)
            .HasConversion<string>();

        modelBuilder.Entity<ClaimReview>()
            .Property(r => r.ErrorSource)
            .HasConversion<string>();

        modelBuilder.Entity<ClaimInformationRequest>()
            .Property(r => r.Status)
            .HasConversion<string>();

        // Unique values
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Claim>()
            .HasIndex(c => c.ClaimNumber)
            .IsUnique();

        // Claimant relationship
        modelBuilder.Entity<Claim>()
            .HasOne(c => c.Claimant)
            .WithMany(u => u.SubmittedClaims)
            .HasForeignKey(c => c.ClaimantId)
            .OnDelete(DeleteBehavior.Restrict);

        // Assigned Claim Officer relationship
        modelBuilder.Entity<Claim>()
            .HasOne(c => c.AssignedOfficer)
            .WithMany()
            .HasForeignKey(c => c.AssignedOfficerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Claim documents
        modelBuilder.Entity<ClaimDocument>()
            .HasOne(d => d.Claim)
            .WithMany(c => c.Documents)
            .HasForeignKey(d => d.ClaimId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ClaimDocument>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(d => d.UploadedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Information requests
        modelBuilder.Entity<ClaimInformationRequest>()
            .HasOne(r => r.Claim)
            .WithMany(c => c.InformationRequests)
            .HasForeignKey(r => r.ClaimId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ClaimInformationRequest>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(r => r.RequestedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Claim assessments
        modelBuilder.Entity<ClaimAssessment>()
            .HasOne(a => a.Claim)
            .WithMany(c => c.Assessments)
            .HasForeignKey(a => a.ClaimId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ClaimAssessment>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(a => a.OfficerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Claim reviews
        modelBuilder.Entity<ClaimReview>()
            .HasOne(r => r.Claim)
            .WithMany(c => c.Reviews)
            .HasForeignKey(r => r.ClaimId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ClaimReview>()
            .HasOne(r => r.Assessment)
            .WithMany()
            .HasForeignKey(r => r.AssessmentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ClaimReview>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(r => r.ApproverId)
            .OnDelete(DeleteBehavior.Restrict);

        // Claim activity history
        modelBuilder.Entity<ClaimActivity>()
            .HasOne(a => a.Claim)
            .WithMany(c => c.Activities)
            .HasForeignKey(a => a.ClaimId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ClaimActivity>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(a => a.ActorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Monetary precision
        modelBuilder.Entity<Claim>()
            .Property(c => c.EstimatedLiability)
            .HasPrecision(18, 2);

        modelBuilder.Entity<ClaimAssessment>()
            .Property(a => a.RecommendedAmount)
            .HasPrecision(18, 2);
    }
}
