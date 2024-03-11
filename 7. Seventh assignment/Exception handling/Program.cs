try
{
    CheckInput(5, 5);
    ThrowCustomException();
}
catch (CustomException ex)
{
    Console.WriteLine($"Custom Exception: {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Argument Exception catched and rethrown");
    throw;
}
catch (Exception ex)
{
    Console.WriteLine($"Base Exception: {ex.Message}");
}
finally
{
    Console.WriteLine("Finally block executed.");
}

static void CheckInput(int first, int second)
{
    if (first <= 0 || second <= 0)
    {
        throw new ArgumentException("Both arguments must be positive.");
    }
}

static void ThrowCustomException()
{
#if DEBUG
    throw new CustomException("Debug mode: Custom exception thrown.");
#else
    throw new Exception("Non debug mode: Normal exception thrown.");
#endif
}
