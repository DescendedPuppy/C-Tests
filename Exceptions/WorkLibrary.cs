using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exceptions
{
    // ---------------------- NOTHING TO DO HERE ----------------------
    public class WorkLibrary
    {
        public bool DoSomething(int a, out int result)
        {
            result = 0;
            // let's assume a == 0 results in a division by 0
            if (a == 0)
            {
                return false;
            }
            else
            {
                result = 1 / a;
                return true;
            }
        }

        public bool DoFurtherWork(int a, out int result)
        {
            result = 0;
            // let's assume a == 0 results in a division by 0
            if (a == 0)
            {
                return false;
            }
            else
            {
                result = 1000 / a;
                return true;
            }
        }

        public bool DoOtherWork(int a, out int result)
        {
            int[] numbers = { 1, 2, 3 };

            result = -1;

            if ((0 <= a) && (a <= numbers.GetUpperBound(0)))
            {
                result = numbers[a];
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DoSomethingExcVersion(int a, out int result)
        {
            try
            {
                result = 1 / a;
            }
            catch (DivideByZeroException innerException)
            {
                throw new ArgumentException("DoSomething failed! Division by 0! Invalid argument for a.", innerException);
            }
        }
   
        public void DoFurtherWorkExcVersion(int a, out int result)
        {
            try
            {
                result = 1000 / a;
            }
            catch (DivideByZeroException innerException)
            {
                throw new ArgumentException("DoFurtherWork failed! Division by 0! Invalid argument for a.", innerException);
            }
        }

        // use a=0 for no error, a=3 to create an error
        public void DoOtherWorkExcVersion(int a, out int result)
        {
            int[] numbers = { 1, 2, 3 };

            try
            {
                result = numbers[a];
            }
            catch (IndexOutOfRangeException innerException)
            {
                throw new ArgumentException("DoOtherWork failed! Index out of range! Invalid argument for a.", innerException);
            }
                       
        }

    }
}
