using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zajęcia_3.Models
{
    public struct FizzBuzzEntry
    {
        public int entry { get; set; }
        public string result { get; set; }
        public DateTime date { get; set; }

        public FizzBuzzEntry(int entry)
        {
            this.entry = entry;
            date = DateTime.Now;

            // FizzBuzz Parsing:
            string result = "";

            result += (entry % 3 == 0) ? "Fizz" : "";
            result += (entry % 5 == 0) ? "Buzz" : "";

            if (result != "")
                this.result = $"Otrzymano: {result}";
            else
                this.result = $"Liczba: {entry} nie spełnia kryteriów Fizz/Buzz";

        }

        public override string ToString()
        {
            return $"{date} - {entry} -> \"{result}\"";
        }
    }
}
