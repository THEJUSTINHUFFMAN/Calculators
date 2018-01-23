using System;
using System.Text; //JUSTIN HUFFMAN

namespace Calculators
{
	class Program
	{
		static void Main(string[] args)
		{
			bool cont = true;
			while ( cont == true) //While loop with cont determines if program exits or loops
			{
				Console.WriteLine("");
				Console.WriteLine("Please choose an option below: ");
				Console.WriteLine("[1] --- Continuious Addition"); 		//UI
				Console.WriteLine("[2] --- Factorial");
				Console.WriteLine("[3] --- Tip Calculator");
				Console.WriteLine("[4] --- Imaginary Product");
				Console.WriteLine("[5] --- Exit");
				
				try //to ensure user input is an int
				{
					int select = int.Parse( Console.ReadLine() ); //User selects option from above menu
					Console.WriteLine("");
				
					switch (select) //based off user selection
					{
						case 1:
							ContAdd();
							break;
						case 2:
							Factorial();
							break;
						case 3:
							EZTip();
							break;
						case 4:
							ImagProd();
							break;
						case 5:
							cont = false;
							Console.WriteLine("Goodbye!");
						break;
						default:
							Console.ForegroundColor = ConsoleColor.DarkGray;
							Console.WriteLine("Invalid input, try again.");
							Console.ResetColor();
							break;
					}
				}
				catch (System.FormatException e) //catches input from either menu selection or input in any of the calculator functions
				{
					Console.WriteLine("");
					Console.ForegroundColor = ConsoleColor.DarkGray;
					Console.WriteLine("Please enter integers only. ({0})", e);
					Console.ResetColor();
				}
			}
			Console.WriteLine("Enter any key to exit..."); //keeps cmd on screen after program ends
			Console.ReadKey();
		}
		
		static void ContAdd() //option 1 above 
		{
			int total = 0;
			int numIn = 1;
			Console.WriteLine("Enter the numbers you want to add. (Input 0 to stop)");
			while (numIn != 0)
			{
				numIn = int.Parse( Console.ReadLine() );
				Console.WriteLine("{0} + {1} = {2}", total, numIn, total += numIn);
			}
		}
		
		static void Factorial() //option 2 above
		{
			Console.WriteLine("Please enter a number to be factorialized,");
			int num = int.Parse( Console.ReadLine() );
			if (num >= 0)
			{
				int total = fact(num);
				Console.WriteLine("{0}! = {1}", num, total);
			}
			else Console.WriteLine("Does not exist.");
		}
		
		static int fact(int n) //called in Factorial() , does the math
		{
			if (n == 0) return 0;
			if (n == 1) return 1;
			else return n *= fact(n-1);
		}
		
		static void EZTip() //option 3 above
		{
			Console.WriteLine("Enter amount billed: ");
			float amount = float.Parse( Console.ReadLine() );
			Console.WriteLine("Enter tip percentage: ");
			float percent = ( float.Parse( Console.ReadLine() ) / 100 );
			Console.WriteLine("");
			
			Console.WriteLine("Tip: ${0}", amount * percent);
			Console.WriteLine("Total to be paid: ${0}" , amount *(1 + percent));
		}
		
		public struct imagNum //sets up imaginary number object type for ImagProd() below
		{
			public int real;
			public int imag;
		}
		
		static imagNum product(imagNum n1, imagNum n2) //does math for imaginary num multiplication in ImagProd()
		{
			imagNum result;
			result.real = (n1.real * n2.real) - (n1.imag * n2.imag);
			result.imag = (n1.real * n2.imag) + (n2.real * n1.imag);
			return result;
		}
		
		static void ImagProd() //option 4 from above
		{
			Console.WriteLine("Please enter the real component, then the imaginary (without the i).");
			imagNum num1, num2;
			num1.real = int.Parse( Console.ReadLine() );
			num1.imag = int.Parse( Console.ReadLine() );
			Console.WriteLine("Please enter the real component, then the imaginary (without the i).");
			num2.real = int.Parse( Console.ReadLine() );
			num2.imag = int.Parse( Console.ReadLine() );
			
			imagNum prod = product(num1,num2);
			Console.WriteLine("({0} + {1}i) x ({2} + {3}i) = ({4} + {5}i)", num1.real, num1.imag,
								num2.real, num2.imag, prod.real, prod.imag);
		}
	}
}