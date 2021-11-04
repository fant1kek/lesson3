using System;
using computer;
using hMACGenerate;
using menu;
using result;
using converter;
using System.Linq;

namespace main
{
    class Program
    {
        static void Main(string[] args)
        {
            if (ValidArgs(args))
            {
                Computer computer = new Computer(args);
                Menu menu = new Menu(args);
                Result result = new Result();
                HMACGenerator hMACGenerate = new HMACGenerator();
                Converter converter = new Converter();
                byte[] secretKey = hMACGenerate.KeyGenerate();
                string computerMuve = computer.RandomMuve();
                string HMAC = hMACGenerate.GenerateHmacWithMove(computerMuve, secretKey);
                Console.WriteLine($"HMAC: {HMAC}");
                bool errors = true;
                while (errors)
                {
                    int muve = menu.Creating();
                    if (muve >= 1 && muve <= args.Length - 1)
                    {
                        Console.WriteLine($"Your move: {args[muve - 1]}\nComputer move: {computerMuve}");
                        Console.WriteLine(result.GetResult(muve - 1, computer.GetNumMuve(), args.Length));
                        errors = false;
                    }
                    else if (muve == 0)
                    {
                        errors = false;
                    }
                }
                Console.Write($"HMAC key: {converter.BytesToHex(secretKey)}\nGame end");
            }
            else
                Console.WriteLine("Example: rock paper scissors lizard spock");
        }
        static bool ValidArgs(string[] args)
        {
            if (args.Length <= 2)
            {
                Console.WriteLine("Send 3 or more arguments");
                return false;
            }
            if (args.Length % 2 == 0)
            {
                Console.WriteLine("Even number of arguments");
                return false;
            }
            if (args.Distinct().Count() != args.Length)
            {
                Console.WriteLine("Arguments must not be repeated");
                return false;
            }
            return true;
        }
    }
}
