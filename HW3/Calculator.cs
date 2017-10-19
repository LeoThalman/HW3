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
        //private StringReader scin = new StringReader(Console.Read );


        /**
         * Entry point method, Ignores initial command line arguements
         */ 
         public void Main(String[] args)
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
            String input = "2 2 +";
            Console.WriteLine("> ");  //Prompt User

            input = Console.ReadLine();

            if( input.StartsWith("q") || input.StartsWith("Q"))
            {
                rtn = false;
            }
            else
            {            
                String output = "4";
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
     */
        public String EvaluatePostFixInput(String input)
        {
            if (input == null || input == "")
                throw new ArgumentException("Null/empty string are not valid postfix expressions");
            stack.Clear();

            String s; //temp var for token read
            Double a; //temp var for operand
            Double b; //temp var for operand
            Double c; //temp var for answer

            while
        }
    }
}
