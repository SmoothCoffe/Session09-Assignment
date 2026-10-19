namespace Session09Assignment;

// =====================================================================
// Part 1 — Q3: PatientDto positional record
// =====================================================================
// A positional record auto-generates:
//   - init-only properties
//   - value-based Equals / GetHashCode
//   - deconstructor
//   - == / != operators
//   - a synthesized "with" clone helper
//
// Medical history is SENSITIVE — that is exactly why this DTO exposes only
// Id, FullName, PhoneNumber.  The medical history never leaves the model layer.
// =====================================================================

public record PatientDto(int Id, string FullName, string PhoneNumber);
