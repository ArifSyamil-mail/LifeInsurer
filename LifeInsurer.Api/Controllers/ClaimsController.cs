
using LifeInsurer.Api.Data;
using LifeInsurer.Api.DTOs.Claims;
using LifeInsurer.Api.Enums;
using LifeInsurer.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LifeInsurer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClaimsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ClaimsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // POST: api/claims
    // Submit a new insurance claim.
    [HttpPost]
    public async Task<ActionResult<ClaimResponse>> CreateClaim(
        CreateClaimRequest request)
    {
        // Verify that the claimant exists and is active.
        var claimantExists = await _context.Users.AnyAsync(
            u => u.Id == request.ClaimantId
                 && u.Role == UserRole.Claimant
                 && u.IsActive
        );

        if (!claimantExists)
        {
            return BadRequest("Invalid or inactive claimant.");
        }

        // Generate a unique claim number.
        var claimNumber =
            $"CLM-{DateTime.UtcNow:yyyyMMdd}-" +
            $"{Guid.NewGuid().ToString("N")[..8].ToUpperInvariant()}";

        var claim = new Claim
        {
            ClaimNumber = claimNumber,
            ClaimantId = request.ClaimantId,
            PolicyNumber = request.PolicyNumber,
            MarketCode = request.MarketCode,
            ClaimType = request.ClaimType,
            IncidentDescription = request.IncidentDescription,
            IncidentDate = request.IncidentDate!.Value,
            EstimatedLiability = request.EstimatedLiability,
            Status = ClaimStatus.Submitted,
            SubmittedAt = DateTime.UtcNow
        };

        _context.Claims.Add(claim);

        // Record the claim submission in its activity history.
        var activity = new ClaimActivity
        {
            Claim = claim,
            ActorId = request.ClaimantId,
            Action = "ClaimSubmitted",
            Description = "Claim submitted successfully."
        };

        _context.ClaimActivities.Add(activity);

        await _context.SaveChangesAsync();

        var response = MapToResponse(claim);

        return CreatedAtAction(
            nameof(GetClaimById),
            new { id = claim.Id },
            response
        );
    }

    // GET: api/claims
    // Retrieve all claims.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClaimResponse>>> GetClaims()
    {
        var claims = await _context.Claims
            .AsNoTracking()
            .OrderByDescending(c => c.SubmittedAt)
            .Select(c => new ClaimResponse
            {
                Id = c.Id,
                ClaimNumber = c.ClaimNumber,
                PolicyNumber = c.PolicyNumber,
                MarketCode = c.MarketCode,
                ClaimType = c.ClaimType,
                IncidentDescription = c.IncidentDescription,
                IncidentDate = c.IncidentDate,
                EstimatedLiability = c.EstimatedLiability,
                Status = c.Status,
                SubmittedAt = c.SubmittedAt
            })
            .ToListAsync();

        return Ok(claims);
    }

    // GET: api/claims/1
    // Retrieve a specific claim.
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ClaimResponse>> GetClaimById(int id)
    {
        var claim = await _context.Claims
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (claim == null)
        {
            return NotFound($"Claim with ID {id} was not found.");
        }

        return Ok(MapToResponse(claim));
    }

    // Convert database entity into API response DTO.
    private static ClaimResponse MapToResponse(Claim claim)
    {
        return new ClaimResponse
        {
            Id = claim.Id,
            ClaimNumber = claim.ClaimNumber,
            PolicyNumber = claim.PolicyNumber,
            MarketCode = claim.MarketCode,
            ClaimType = claim.ClaimType,
            IncidentDescription = claim.IncidentDescription,
            IncidentDate = claim.IncidentDate,
            EstimatedLiability = claim.EstimatedLiability,
            Status = claim.Status,
            SubmittedAt = claim.SubmittedAt
        };
    }
}
