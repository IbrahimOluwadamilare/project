using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You are welcome please enter your number");
            int no = Convert.ToInt32 (Console.ReadLine());
            
            //if construct

            if (no == 50)
            {
                Console.WriteLine("You Passed with {0} marks",no);
            }
            else if (no < 30)
            {
                Console.WriteLine("You Failed with {0} marks", no);
            }
            else 
            {
                Console.WriteLine("You tried");
            }
            Console.ReadLine();
        }
    }
}
