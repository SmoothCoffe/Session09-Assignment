namespace Session09Assignment;

// =====================================================================
// Part 6 — Q11: FineCalculator
// =====================================================================
// This is the system-under-test (SUT) for the xUnit project.  It is placed
// in the Console project so the Tests project can reference it directly.
//
// Divide must throw DivideByZeroException when b == 0 — verified by test #6.
// =====================================================================

public class FineCalculator
{
    public int Add(int a, int b) => a + b;

    public int Subtract(int a, int b) => a - b;

    public int Multiply(int a, int b) => a * b;

    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero (b == 0).");
        return a / b;
    }
}
