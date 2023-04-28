using System;
using System.Collections.Generic;

public class OutOfRangeError : Exception { }
public class NotIntegerError : Exception { }
public class InvalidRomanNumeralError : Exception { }

public class Program
{
    static readonly (string, int)[] roman_numeral_map =
    {
        ("M", 1000),
        ("CM", 900),
        ("D", 500),
        ("CD", 400),
        ("C", 100),
        ("XC", 90),
        ("L", 50),
        ("XL", 40),
        ("X", 10),
        ("IX", 9),
        ("V", 5),
        ("IV", 4),
        ("I", 1)
    };

    static readonly List<string> to_roman_table = new List<string> { null };
    static readonly Dictionary<string, int> from_roman_table = new Dictionary<string, int>();

    public static string ToRoman(int n)
    {
        if (!(0 < n && n < 5000))
        {
            throw new OutOfRangeError();
        }

        return to_roman_table[n];
    }

    public static int FromRoman(string s)
    {
        if (!(s is string))
        {
            throw new InvalidRomanNumeralError();
        }
        if (string.IsNullOrEmpty(s))
        {
            throw new InvalidRomanNumeralError();
        }
        if (!from_roman_table.ContainsKey(s))
        {
            throw new InvalidRomanNumeralError();
        }

        return from_roman_table[s];
    }

    public static void BuildLookupTables()
    {
        string ToRoman(int n)
        {
            string result = "";
            foreach (var (numeral, integer) in roman_numeral_map)
            {
                if (n >= integer)
                {
                    result = numeral;
                    n -= integer;
                    break;
                }
            }
            if (n > 0)
            {
                result += to_roman_table[n];
            }
            return result;
        }

        for (int i = 1; i < 5000; i++)
        {
            string roman_numeral = ToRoman(i);
            to_roman_table.Add(roman_numeral);
            from_roman_table[roman_numeral] = i;
        }
    }

    static void Main(string[] args)
    {
        BuildLookupTables();

        Console.WriteLine("Select one of the following: ");
        Console.WriteLine("1. Convert from integer to Roman");
        Console.WriteLine("2. Convert from Roman to integer");
        Console.WriteLine("3. Exit");

        string menu_selection = Console.ReadLine();

        if (menu_selection == "1")
        {
            Console.Write("Convert an integer to Roman numeral: ");
            if (int.TryParse(Console.ReadLine(), out int to_roman_input))
            {
                try
                {
                    Console.WriteLine($"Here is the result: {ToRoman(to_roman_input)}");
                }
                catch (Exception)
                {
                    Console.WriteLine("Input must be integer");
                }
            }
            else
            {
                Console.WriteLine("Input must be integer");
            }
        }
        else if (menu_selection == "2")
        {
            Console.Write("Convert a Roman numeral to an integer: ");
            string from_roman_input = Console.ReadLine().ToUpper();
            try
            {
                Console.WriteLine($"Here is the result: {FromRoman(from_roman_input)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Adios");
        }
    }
}
