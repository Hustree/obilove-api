// obiloveapi.Domain/Enums/UserStatus.cs
namespace obiloveapi.Domain.Enums
{
    public enum UserStatus
    {
        Pending,    // Registration submitted; pending verification.
        Verified,   // Verified as legit.
        Rejected    // Registration rejected.
    }
}
