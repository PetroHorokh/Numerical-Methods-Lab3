﻿namespace Lab3;

public static class NonlinearEquationSolution
{
    public static void DivisionInHalf(double x0, double x1, double e, double x)
    {
        var a = x0;
        var b = x1;
        double root;
        int counter = 0;
        do
        {
            var c = (a + b) / 2;

            if (Function(c) * Function(a) < 0) b = c;
            else a = c;

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
        int counter = 0;
        double priorX;
        var newX = x0;

        do
        {
            priorX = newX;

            newX = priorX - (1 / Math.Pow(priorX, 3)) * Function(priorX);

            Console.WriteLine($"Iteration: {counter}");
            Console.WriteLine($"Root: {priorX}\n");

            counter++;

        } while (Math.Abs(newX - priorX) >= e || Math.Abs(Function(newX)) >= e);

        Console.WriteLine($"Amount of iterations: {counter}");
        Console.WriteLine($"Incoherency: {Math.Abs(newX - root)}\n");
    }

    private static double Function(double x) => (Math.Pow(x, 3) - 10 - Math.Sqrt(x - 2));

}