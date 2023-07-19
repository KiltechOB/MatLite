
using MatLite.factory;

class Program
{

    static void Main(string[] args)
    {
        Pairs pair = new Pairs("s", "4");
        Pairs pair2 = new Pairs("f3,1", "25");
        PairsDictionary pairs = new PairsDictionary();
        pairs.AddDictionary(pair); pairs.AddDictionary(pair2);

        string formula = "s+1";

        ReversePolishNotation pl = new ReversePolishNotation();
        Queue<string> queue = pl.GetReversePolishNotations(formula, pairs);
        Calculation result = new Calculation();

        Console.WriteLine("Enter user formula:");
        Console.WriteLine(formula);

        Console.WriteLine("Reverse polish notation:");
        foreach (string s in queue)
        {
            Console.Write(s + " ");
        }
        //го бухати
        Console.WriteLine("result: " + result.getResult(queue));

    }
  
}
