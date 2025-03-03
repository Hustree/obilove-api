// obiloveapi.Domain/Enums/CitizenStatus.cs
namespace obiloveapi.Domain.Enums
{
    public enum CitizenStatus
    {
        Pending,    // Registration submitted; pending verification.
        Verified,   // Verified as legit.
        Rejected    // Registration rejected.
    }
}
