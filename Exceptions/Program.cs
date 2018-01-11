using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {    
            ConsoleKeyInfo key;
            ErrorHandlingComparison calc = new ErrorHandlingComparison(new WorkLibrary());
            
            Console.Clear();
            Console.WriteLine("Terminate with <x>");
           

            do
            {
                // get number from user
              
                Console.WriteLine("Please enter a number. To run the program without error enter 1 or 2.");
                key = Console.ReadKey();
                Console.WriteLine("");

                // TODO uncomment and replace with TestExceptionErrorHandling
                Program.TestReturnCodeErrorHandling(key, calc);
                //Program.TestExceptionErrorHandling(key, calc);

                Console.WriteLine("");
                Console.WriteLine("---------------- Next try ---------------- ");
            }
            while (key.KeyChar.ToString() != "x");
            
        }

        static void TestReturnCodeErrorHandling(ConsoleKeyInfo key, ErrorHandlingComparison calc)
        {
            bool ok;
            int number;

            ok = Int32.TryParse(key.KeyChar.ToString(), out number);

            if (ok)
            {
                // this would be a useful check, but it's in comments so that we can test errors, too
                // if (number != 0) 
                // {
                    ok = calc.HandleInputData(number);
                // }
            }

            if (ok)
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Error! Try again with a correct number!");
            }

        }

        static void TestExceptionErrorHandling(ConsoleKeyInfo key, ErrorHandlingComparison calc)
        {
            int number;
            try
            { 

                number = Int32.Parse(key.KeyChar.ToString());

                // this would be a useful check, but it's in comments so that we can test errors, too
                // if (number != 0) 
                // {
                    calc.HandleInputDataExcVersion(number);
                // }
                           
                Console.WriteLine("Success!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! Try again with a correct number!");                              
            }
        }
    }
}
