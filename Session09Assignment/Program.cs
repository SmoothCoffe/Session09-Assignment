using Session09Assignment;


PrintHeader("Part 1 — Q1 / Q2 : Patient class (primary constructor)");

// Q1 — primary constructor: Patient(Id, FullName, PhoneNumber, MedicalHistory)
var patient01 = new Patient(1, "Ahmed Ali", "01012345678", "Asthma, Hypertension");
var patient02 = new Patient(1, "Ahmed Ali", "01012345678", "Asthma, Hypertension");

Console.WriteLine($"patient01: {patient01}");
Console.WriteLine($"patient02: {patient02}");

//  Q2.1 : GetHashCode 
Console.WriteLine();
Console.WriteLine("Q2.1 — GetHashCode of both patients:");
Console.WriteLine($"  patient01.GetHashCode() = {patient01.GetHashCode()}");
Console.WriteLine($"  patient02.GetHashCode() = {patient02.GetHashCode()}");

// Are they equal?  NO.  Because Patient is a CLASS (reference type) and we
// deliberately did NOT override GetHashCode, the default implementation is
// based on the object's memory address (runtime identity).  Two `new`
// calls produce two different heap locations, hence two different hashes.

//  Q2.2 : Equals 
Console.WriteLine();
Console.WriteLine("Q2.2 — patient01.Equals(patient02):");
Console.WriteLine($"  Result = {patient01.Equals(patient02)}");

// Result is FALSE.  Object.Equals by default performs reference equality
// (it checks whether the two variables point to the same heap object).
// patient01 and patient02 have identical field values but live at
// different memory addresses — so Equals returns false.

//  Q2.3 : Assign then Equals 
Console.WriteLine();
Console.WriteLine("Q2.3 — After `patient01 = patient02;`:");
patient01 = patient02;
Console.WriteLine($"  patient01.Equals(patient02) = {patient01.Equals(patient02)}");

// Now TRUE.  After the assignment, patient01 and patient02 both refer to
// the SAME object on the heap (reference copy), so Equals (reference
// equality) returns true.  No new object was created — only the reference
// was copied.

// =====================================================================
PrintHeader("Part 1 — Q3 : PatientDto positional record");

var dto01 = new PatientDto(1, "Ahmed Ali", "01012345678");
var dto02 = new PatientDto(1, "Ahmed Ali", "01012345678");

Console.WriteLine($"dto01.GetHashCode()  = {dto01.GetHashCode()}");
Console.WriteLine($"dto02.GetHashCode()  = {dto02.GetHashCode()}");
Console.WriteLine($"dto01.Equals(dto02)   = {dto01.Equals(dto02)}");

// EXPLANATION (class vs record):
// A `record` is syntactic sugar over a class/struct that the compiler
// augments with VALUE-based semantics:
//   - synthesized Equals and GetHashCode based on all fields
//   - == and != operators
//   - a `with` clone expression
//   - a deconstruct method
// Therefore two records with the same property values are EQUAL and have
// the same hash code, even though they live at different heap addresses.
// By contrast, our Patient CLASS uses the default Object.Equals which
// only compares references — so two patients with identical data are
// considered NOT equal.  Records are ideal for DTOs, value objects,
// and immutable domain models precisely because of this behavior.

// =====================================================================
PrintHeader("Part 1 — Q4 : PatientMapper");

var sourcePatient = new Patient(2, "Sara Mohamed", "01198765432", "Diabetes Type 2");
var dtoFromMapper = PatientMapper.MapFromModelToDto(sourcePatient);
Console.WriteLine($"  Source model : {sourcePatient}");
Console.WriteLine($"  Mapped DTO   : {dtoFromMapper}");

// Notice that the DTO does NOT contain MedicalHistory.  The sensitive
// field is dropped by the mapper on purpose, so it cannot leak out of
// the model layer.

// =====================================================================
PrintHeader("Part 2 — Q6 : AppLogger Singleton (4 calls)");

var logger1 = AppLogger.GetLogger();
var logger2 = AppLogger.GetLogger();
var logger3 = AppLogger.GetLogger();
var logger4 = AppLogger.GetLogger();

Console.WriteLine($"  GetLogger() #1 hash = {logger1.GetHashCode()}");
Console.WriteLine($"  GetLogger() #2 hash = {logger2.GetHashCode()}");
Console.WriteLine($"  GetLogger() #3 hash = {logger3.GetHashCode()}");
Console.WriteLine($"  GetLogger() #4 hash = {logger4.GetHashCode()}");

// OBSERVATION: all four hash codes are IDENTICAL — meaning the four
// calls returned the SAME object instance.
// WHY: GetLogger() uses the Singleton pattern.  On the first call the
// private static `_instance` field is null, so the constructor runs
// once and the instance is cached.  Every subsequent call simply
// returns the cached instance without calling `new` again.
// The "[AppLogger] instance created." message above is therefore printed
// exactly once, no matter how many times GetLogger() is invoked.

// =====================================================================
PrintHeader("Part 3 — Q7 : var & dynamic");

// 1. Target-typed new — the compiler infers the type from the LHS.
Patient targetTyped = new(10, "Mona Hassan", "01234567890", "Migraine");
Console.WriteLine($"  Target-typed new : {targetTyped}");

// 2. var — the compiler infers the type from the RHS at compile time.
var varTyped = new Patient(11, "Khaled Saad", "01567890123", "Allergy - Penicillin");
Console.WriteLine($"  var              : {varTyped}");

// 3. dynamic — type is resolved at RUN TIME; the compiler skips type-checking.
dynamic dyn = new Patient(12, "Nour Ibrahim", "01678901234", "Hypothyroidism");
Console.WriteLine($"  dynamic          : {dyn}");

// After being declared, dyn could be reassigned to ANY type (int, string,
// etc.) without a compile error — the type check is deferred until
// execution.  That flexibility is also why dynamic loses IDE IntelliSense
// and compile-time safety.

// EXPLANATION — var vs dynamic:
//   var     : resolved at COMPILE TIME.  The compiler infers a concrete
//             type from the initializer and the variable becomes strongly
//             typed from that point on.  Re-assigning an incompatible type
//             is a compile-time error.
//   dynamic : resolved at RUN TIME.  The compiler treats the variable as
//             `object` for type-checking purposes and resolves the actual
//             type during execution.  You can assign any type at any time
//             but you lose compile-time type safety and IntelliSense.

// =====================================================================
PrintHeader("Part 4 — Q8 : Anonymous Types");

var doctor01 = new { Name = "Sara", Specialty = "Cardiology", ExperienceYears = 8, Salary = 25_000 };
var doctor02 = new { Name = "Sara", Specialty = "Cardiology", ExperienceYears = 8, Salary = 25_000 };

// 1) Properties of doctor01
Console.WriteLine($"  doctor01.Name        = {doctor01.Name}");
Console.WriteLine($"  doctor01.Specialty   = {doctor01.Specialty}");

// 2) Hash codes of both
Console.WriteLine($"  doctor01.GetHashCode() = {doctor01.GetHashCode()}");
Console.WriteLine($"  doctor02.GetHashCode() = {doctor02.GetHashCode()}");

// 3) GetType() — the compiler generates one anonymous class per
// property-set signature; the generated name is compiler-controlled.
Console.WriteLine($"  doctor01.GetType()  = {doctor01.GetType()}");

// 4) Equals between the two anonymous objects
Console.WriteLine($"  doctor01.Equals(doctor02) = {doctor01.Equals(doctor02)}");

// 5) ToString of an anonymous object
Console.WriteLine($"  doctor01.ToString() = {doctor01.ToString()}");

// COMPARISON — class vs record vs anonymous type
//   - CLASS (Patient)
//   : reference equality — different
//instances are NOT equal even when
//every field has the same value.

//   - RECORD (PatientDto)
//   : value equality — two records with
//the same field values ARE equal and
//share the same hash code.

//   - ANONYMOUS TYPE (doctor01)  :
//value equality, just like a record.
//Two anonymous objects with the same
//property names, types, and values (in
//the same order) are EQUAL.  The
//compiler even reuses the SAME
//generated type for both, which is why
//doctor01.GetType() == doctor02.GetType().
//Anonymous types are immutable and
//cannot be named — perfect for ad-hoc
//projections (e.g. LINQ Select).

// =====================================================================
PrintHeader("Part 5 — Q10 : Extension methods");

Console.WriteLine($"  \"Stethoscope\".IsShorterThan(5) = {"Stethoscope".IsShorterThan(5)}");
Console.WriteLine($"  \"Ab\".Repeat(4)                  = {"Ab".Repeat(4)}");

// "Stethoscope".IsShorterThan(5):
//   "Stethoscope".Length = 11, and 11 < 5 is FALSE → returns false.
// "Ab".Repeat(4):
//   The extension concatenates "Ab" four times → "AbAbAbAb".

// =====================================================================
Console.WriteLine();
Console.WriteLine("============================================================");
Console.WriteLine("  End of Session 09 — Assignment (Q1..Q10)                 ");
Console.WriteLine("============================================================");

// -----
// Local helper: print a colored section header.
// -----
static void PrintHeader(string title)
{
    Console.WriteLine();
    Console.WriteLine("============================================================");
    Console.WriteLine($"  {title}");
    Console.WriteLine("============================================================");
}
