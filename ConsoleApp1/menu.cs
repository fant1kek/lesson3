using ConsoleTables;
using System;
using result;

namespace menu
{
    class Menu
    {
        public string[] args;
        public Menu(string[] args)
        {
            this.args = args;
        }
        public int Creating()
        {
            Console.WriteLine("Available moves:");
            for (int i = 0; i < args.Length; i++)
                Console.WriteLine($"{i + 1} - {args[i]}");
            Console.WriteLine("0 - exit\n? - help");
            Console.Write("Enter your move: ");
            string muve = Console.ReadLine();
            if (muve == "?")
            {
                Help();
                return -1;
            }
            if (Int32.TryParse(muve, out int num))
                return num;
            return -1;
        }

        public void Help()
        {
            Result result = new Result();
            string[] tempTable = new string[args.Length + 1];
            string[] tempRow = new string[args.Length + 1];
            tempTable[0] = "PC/User";
            for (int i = 0; i < args.Length; i++)
                tempTable[i + 1] = args[i];
            var consoleTable = new ConsoleTable(tempTable);
            for (int i = 0; i < args.Length; i++)
            {
                tempRow[0] = args[i];
                for (int j = 0; j < args.Length; j++)
                {
                    tempRow[j + 1] = result.GetResult(j, i, args.Length);
                }
                consoleTable.AddRow(tempRow);
                tempRow = new string[args.Length + 1];
            }
            consoleTable.Write();
            Console.WriteLine("Press any button...");
            Console.ReadKey();
        }
    }
}
