
using ClassLibraryPOO;
// Taller#1 POO

public class Program
{
    static void Main()
    {
        try
        {
            var t1 = new MyTime(0, 0, 0, 0);
            Imprimir(t1, new MyTime(9, 34, 0, 0));

            var t2 = new MyTime(14, 0, 0, 0);
            Imprimir(t2, new MyTime(23, 34, 0, 0));

            var t3 = new MyTime(9, 34, 0, 0);
            Imprimir(t3, new MyTime(19, 8, 0, 0));

            var t4 = new MyTime(19, 45, 56, 0);
            Imprimir(t4, new MyTime(5, 19, 56, 0));

            var t5 = new MyTime(23, 3, 45, 678);
            Imprimir(t5, new MyTime(8, 37, 45, 678));

            // Este dará error
            var t6 = new MyTime(45, -7, 90, -87);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void Imprimir(MyTime t, MyTime add)
    {
        Console.WriteLine("................................");
        Console.WriteLine("--------------------------------");
        Console.WriteLine();
        Console.WriteLine($"{" Time:"} {t}");
        Console.WriteLine($"{"    Milliseconds:",-18} {t.ToMilliseconds(),12:N0}");
        Console.WriteLine($"{"    Seconds:",-18} {t.ToSeconds(),12:N0}");
        Console.WriteLine($"{"    Minutes:",-18} {t.ToMinutes(),12:N0}");

        bool isOtherDay;
        var result = t.Add(add, out isOtherDay);
        Console.WriteLine($"{"    Add:",-13} {add}");
        Console.WriteLine($"{"    Is Other day:",-18} {isOtherDay}");
        Console.WriteLine();
    }
}
