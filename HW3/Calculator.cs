using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    /**
     * Class implements a postfix calculator, throws a exception if input is invalid.
     * 
     */ 
    class Calculator
    {

        private IStackADT stack = new LinkedStack();

        //Use Console.Read
        

        /**
         * Entry point method, Ignores initial command line arguements
         */ 
         public static void Main(string[] args)
        {
            //Instantiate a "Main" object so we don't have to make everything static
            Calculator app = new Calculator();
            Boolean playAgain = true;
            Console.WriteLine("\nPostfix Calculator. Recognizes these operators + - * /");
            while ( playAgain )
            {
                playAgain = app.DoCalculation();
            }
            Console.WriteLine("Bye.");
        }


        /**
         * Get input string from user and perform calculation, returning true when finished.
         * if the users quits this method returns false.
         */
         private Boolean DoCalculation()
        {
            Boolean rtn = true;
            Console.WriteLine("Please enter q to quit\n");
            string input = "2 2 +";
            Console.WriteLine("> ");  //Prompt User

            input = Console.ReadLine();

            if( input.StartsWith("q") || input.StartsWith("Q"))
            {
                rtn = false;
            }
            else
            {            
                string output = "4";
                try
                {
                    output = EvaluatePostFixInput(input);
                }
                catch(ArgumentException e)
                {
                    output = e.Message;
                }
                Console.WriteLine("\n\t>>> "+ input + " = "+ output);                
            }
            return rtn;
        }

         /**
          * Evaluate an arithmetic expression written in postfix form.
          * 
          * @param input                  Postfix mathematical expression as a string
          * @return                       Answer as a string
          * @exception ArgumentException  Something went wrong
         */
        public string EvaluatePostFixInput(string input)
        {
            if (input == null || input.Equals(""))
                throw new ArgumentException("Null/empty string are not valid postfix expressions");
            stack.Clear();

            string s; //temp var for token read
            Double a; //temp var for operand
            Double b; //temp var for operand
            Double c; //temp var for answer

            //Convert input into an array of strings
            string[] st = input.Split();

            for (int i = 0; i < st.Length; i++)
            {
                //if string at location i is a number, convert to double and push onto stack
                string temp = st[i];
                if (Double.TryParse(temp, out double result))
                {
                    try
                    {                    
                        stack.Push(result);
                    }
                    catch(Exception ex)
                    {
                        Console.Write(ex.Message);
                    }
                }
                else
                {
                    //Must be an operator some other character
                    s = st[i];
                    if (s.Length > 1)
                        throw new ArgumentException("Input Error: " + s + " is not an allowed number or operator");
                    //it may be an operator so pop two values off stack and perform the operation
                    if (stack.IsEmpty())
                        throw new ArgumentException("Improper input format. Stack became empty when expecting second operand.");
                    b = ((Double)stack.Pop());
                    if (stack.IsEmpty())
                        throw new ArgumentException("Improper input format. Stack becaome empty when expecting first operand.");
                    a = ((Double)stack.Pop());
                    //Wrap up all operations in a single method, easy to add other operators later this way
                    c = DoOperation(a, b, s);
                    //push the answer back on to the stack
                    stack.Push(c);
                }
            }
            return ((Double)stack.Pop()).ToString();
        }

        /**
         * Perform arithmetic. Put here so it doesn't clutter up previous method
         * 
         * @param a                      the first operand
         * @param b                      the second operand
         * @param s                      the operator
         * @return                       the answer
         * @expection ArgumentException  Something went wrong
         */
         public Double DoOperation(Double a, Double b, string s)
        {
            Double c = 0.0;
            if (s.Equals("+"))
                c = (a + b);
            else if (s.Equals("-"))
                c = (a - b);
            else if (s.Equals("*"))
                c = (a * b);
            else if (s.Equals("/"))
            {
                try
                {
                    c = (a / b);
                    if (Double.IsNegativeInfinity(c) || Double.IsPositiveInfinity(c))
                        throw new ArgumentException("Can't divide by zero");
                }
                catch (ArithmeticException e)
                {
                    throw new ArgumentException(e.Message);
                }
            }
            else
                throw new ArgumentException("Improper operator: " + s + ", is not one of +, -, *, or /");
            return c;
        }

    }//End of Calculator Class
}//End of Namespace HW3
