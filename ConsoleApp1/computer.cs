using System;

namespace computer
{
    class Computer
    {
        public string[] args;
        public int numMuve;
        public Computer(string[] args)
        {
            this.args = args;
        }
        public string RandomMuve()
        {
            Random randomMuve = new Random();
            numMuve = randomMuve.Next(0, args.Length);
            return args[numMuve];
        }

        public int GetNumMuve()
        {
            return numMuve;
        }
    }
}
