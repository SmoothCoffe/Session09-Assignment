namespace Session09Assignment;

// =====================================================================
// Part 1 — Q4: Static PatientMapper
// =====================================================================
// A static class cannot be instantiated and acts as a container for pure
// (stateless) functions.  MapFromModelToDto copies the safe fields of the
// Patient model into the DTO and intentionally drops MedicalHistory.
// =====================================================================

public static class PatientMapper
{
    public static PatientDto MapFromModelToDto(Patient patient)
        => new PatientDto(patient.Id, patient.FullName, patient.PhoneNumber);
}
