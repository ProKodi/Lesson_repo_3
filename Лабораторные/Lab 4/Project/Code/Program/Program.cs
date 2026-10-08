



using System.Data;

public class Program{
public static string Calculate(string expression)
{
    string[] input = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    int index = 0;

    // Первое число
    long a = 0;
    long b = 0;
    long c = 1;

    if (input[index].Contains('/'))
    {
        string[] fraction = input[index].Split('/');
        b = long.Parse(fraction[0]);
        c = long.Parse(fraction[1]);
        index++;
    }
    else
    {
        a = long.Parse(input[index]);
        index++;

        if (index < input.Length && input[index].Contains('/'))
        {
            string[] fraction = input[index].Split('/');
            b = long.Parse(fraction[0]);
            c = long.Parse(fraction[1]);
            index++;
        }
    }

    // Операция
    char operation = input[index][0];
    index++;

    // Второе число
    long d = 0;
    long e = 0;
    long f = 1;

    if (input[index].Contains('/'))
    {
        string[] fraction = input[index].Split('/');
        e = long.Parse(fraction[0]);
        f = long.Parse(fraction[1]);
    }
    else
    {
        d = long.Parse(input[index]);
        index++;

        if (index < input.Length && input[index].Contains('/'))
        {
            string[] fraction = input[index].Split('/');
            e = long.Parse(fraction[0]);
            f = long.Parse(fraction[1]);
        }
    }

    // Переводим смешанные числа в неправильные дроби
    long numerator1 = a * c + b;
    long numerator2 = d * f + e;

    long numerator;
    long denominator = c * f;

    if (operation == '+')
        numerator = numerator1 * f + numerator2 * c;
    else
        numerator = numerator1 * f - numerator2 * c;

    // Знак результата
    bool negative = numerator < 0;
    numerator = Math.Abs(numerator);

    // Сокращаем дробь
    long gcd = Gcd(numerator, denominator);

    numerator /= gcd;
    denominator /= gcd;

    // Выделяем целую часть
    long whole = numerator / denominator;
    long remainder = numerator % denominator;

    if (remainder == 0)
        return (negative ? "-" : "") + whole;

    if (whole == 0)
        return (negative ? "-" : "") + remainder + "/" + denominator;

    return (negative ? "-" : "") +
           whole + " " + remainder + "/" + denominator;
}

static long Gcd(long a, long b)
{
    while (b != 0)
    {
        long temp = a % b;
        a = b;
        b = temp;
    }

    return a;
}




    public static void Main(string[] args){
        string? read_line = Console.ReadLine();

        if(read_line == null) throw new NullReferenceException(); 

       // (string, string) res = InputParser(read_line); 


        /// ...
    }
}