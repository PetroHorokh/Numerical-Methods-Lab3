namespace Lab3;

public static class NonlinearEquationSolution
{
    public static void DivisionInHalf(double x0, double x1, double e, double x)
    {
        var a = x0;
        var b = x1;
        double c, f, root;
        int counter = 0;
        do
        {
            c = (a + b)/2;

            f = FunctionT(c) * FunctionT(x0);

            if (f < 0) b = a;

            a = c;

            counter++;

            root = (a + b) / 2;

            Console.WriteLine($"Iteration {counter}");
            Console.WriteLine($"Left edge: {(a > b ? a : b)}; middle: {root}; right edge: {(a < b ? a : b)}\n");

        } while (Math.Abs(a - b) >= e);

        Console.WriteLine($"Root: {root}");
        Console.WriteLine($"Incoherency: {Math.Abs(x-root)}\n");
    }

    public static void SimpleIteration(double x0, double root, double e)
    {
        var counter = 0;
        var priorX = x0;
        var newX = x0;

        do
        {
            priorX = newX;

            newX = priorX - (1 / Math.Pow(priorX, 3)) * Function(priorX);

            Console.WriteLine($"Iteration: {counter}");
            Console.WriteLine($"Root: {priorX}\n");

            counter++;

        } while (Math.Abs(newX- priorX) >= e);

        Console.WriteLine($"Amount of iterations: {counter}");
        Console.WriteLine($"Incoherency: {Math.Abs(newX - root)}\n");
    }

    private static double Function(double x) => (Math.Pow(x, 3) - 10 - Math.Sqrt(x - 2));
}
