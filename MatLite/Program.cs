
using MatLite.factory;

class Program
{

    static void Main(string[] args)
    {
        string formula = "(2*3)^(4-2)";
        
        ReversePolishNotation pl = new ReversePolishNotation();
        Queue<string> queue = pl.GetReversePolishNotation(formula);
        Calculation result= new Calculation();

        Console.WriteLine("Enter user formula:");
        Console.WriteLine(formula);

        Console.WriteLine("Reverse polish notation:");
        foreach(string s in queue)
        {
            Console.Write(s+" ");
        }
        //го бухати
        Console.WriteLine("result: " + result.getResult(queue));
    }
  
}
