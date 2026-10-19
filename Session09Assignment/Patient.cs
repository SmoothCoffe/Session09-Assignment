namespace Session09Assignment;

// =====================================================================
// Part 1 — Q1: Patient class with PRIMARY CONSTRUCTOR
// =====================================================================
// The parameters (id, fullName, phoneNumber, medicalHistory) are captured
// directly by the primary constructor and assigned to init-only properties.
// We intentionally DO NOT override Equals/GetHashCode so that the default
// reference-equality behavior is preserved — this is what Q2 demonstrates
// (class == reference equality, unlike records which use value equality).
// =====================================================================

public class Patient(int id, string fullName, string phoneNumber, string medicalHistory)
{
    public int Id { get; init; } = id;
    public string FullName { get; init; } = fullName;
    public string PhoneNumber { get; init; } = phoneNumber;
    public string MedicalHistory { get; init; } = medicalHistory;

    // Q1 — ToString override using the required format.
    public override string ToString()
        => $"Id: {Id} :: FullName: {FullName} :: PhoneNumber: {PhoneNumber} :: MedicalHistory: {MedicalHistory}";
}
