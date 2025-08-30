
using ClassLibraryPOO;

class Program
{
    static void Main()
    {
        try
        {
            var t1 = new Time(0, 0, 0, 0);
            Imprimir(t1, new Time(9, 34, 0, 0));

            var t2 = new Time(2, 0, 0, 0);
            Imprimir(t2, new Time(9, 34, 0, 0));

            var t3 = new Time(9, 34, 0, 0);
            Imprimir(t3, new Time(9, 34, 0, 0));

            var t4 = new Time(7, 45, 56, 0);
            Imprimir(t4, new Time(9, 34, 0, 0));

            var t5 = new Time(11, 3, 45, 678);
            Imprimir(t5, new Time(9, 34, 0, 0));

            // Este dará error
            var t6 = new Time(45, 0, 0, 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void Imprimir(Time t, Time add)
    {
        Console.WriteLine($"Time: {t}");
        Console.WriteLine($" Milliseconds : {t.ToMilliseconds():N0}");
        Console.WriteLine($" Seconds      : {t.ToSeconds():N0}");
        Console.WriteLine($" Minutes      : {t.ToMinutes():N0}");

        bool isOtherDay;
        var result = t.Add(add, out isOtherDay);
        Console.WriteLine($" Add          : {result}");
        Console.WriteLine($" Is Other day : {isOtherDay}");
        Console.WriteLine();
    }
}
