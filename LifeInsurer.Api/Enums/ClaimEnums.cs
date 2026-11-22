
namespace LifeInsurer.Api.Enums;

public enum UserRole
{
    Claimant,
    ClaimOfficer,
    ClaimApprover
}

public enum ClaimStatus
{
    Submitted,
    InformationRequired,
    ReadyForAssessment,
    UnderReview,
    PendingApproval,
    ReturnedToOfficer,
    Approved,
    Rejected,
    Settled
}

public enum Recommendation
{
    Approve,
    Reject
}

public enum ReviewDecision
{
    Approved,
    Rejected,
    Returned
}

public enum ErrorSource
{
    Claimant,
    ClaimOfficer
}

public enum InformationRequestStatus
{
    Open,
    Resolved
}
