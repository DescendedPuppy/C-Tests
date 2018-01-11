using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ErrorHandlingComparison
    {
        private WorkLibrary WorkLibrary { get; set; }
        

        public ErrorHandlingComparison(WorkLibrary workLibrary)
        {
            WorkLibrary = workLibrary;
        }
    
        public bool HandleInputData(int a)
        {
            bool ok = true;

            int result = 0;

            if (WorkLibrary.DoSomething(a, out result) == true)
            {
                if (WorkLibrary.DoFurtherWork(a, out result) == true)
                {
                    // Remark: this is no error handling code:
                    if (result != 0)
                    {
                        // execute some code
                    }
                }
                else
                {
                    Console.WriteLine("DoSomething failed! Division by 0!");
                    ok = false;
                }
            }
            else
            {
                Console.WriteLine("DoFurtherWork failed! Division by 0!");
                ok = false;

            }

            // only execute when there is no error
            if (ok == true)
            {
                ok = WorkLibrary.DoOtherWork(a, out result);

                if (!ok)
                {
                    Console.WriteLine("DoOtherWork failed! Index out of range!");
                }
            }

            // execute the following code in case of an error and in case of no error 
            Console.WriteLine("Code that must always be executed!");
            return ok;
        }

        public void HandleInputDataExcVersion(int a)
        {
            // TODO: implement here a version which uses exceptions instead of return values
            // TODO: Use try/catch/finally and rethrow the caught exception
            int result = 0;

            try
            {
                WorkLibrary.DoSomethingExcVersion(a, out result);
                WorkLibrary.DoFurtherWorkExcVersion(a, out result);
                if (result != 0)
                {
                    // execute some code
                }
                WorkLibrary.DoOtherWorkExcVersion(a, out result);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {

            }

            // copy the code from HandleInputData and modify it
           
        }



    }
}
