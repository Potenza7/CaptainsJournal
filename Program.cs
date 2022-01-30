using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptainsJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = null;
            DateTime startDate = DateTime.Now;
            string startDateStr;

            bool isLogStarted = false;

            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    continue;
                }

                if (isLogStarted)
                {
                    writer.WriteLine(line);

                    if (line.ToLower().Equals("stop"))
                    {
                        writer.WriteLine("\nJean-Luc Picard");
                        writer.Close();

                        isLogStarted = false;
                    }
                }
                else if (line.ToLower().Equals("start"))
                {
                    isLogStarted = true;

                    startDateStr = startDate.ToString("yyyy.MM.dd");

                    writer = new StreamWriter(startDateStr + ".txt");
                    writer.WriteLine("Captain's log");
                    writer.WriteLine("Startdate " + startDateStr + "\n");

                    writer.WriteLine(line);
                }
                else
                {
                    Console.WriteLine("Line could not be saved.");
                }
            }

            Console.Read();
        }
    }
}
