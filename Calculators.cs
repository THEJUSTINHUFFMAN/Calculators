using System;
using System.Text;

namespace Calculators
{
	class Program
	{
		static void Main(string[] args)
		{
			bool cont = true;
			while ( cont == true)
			{
				Console.WriteLine("");
				Console.WriteLine("Please choose an option below: ");
				Console.WriteLine("[1] --- Continuious Addition");
				Console.WriteLine("[2] --- Factorial");
				Console.WriteLine("[3] --- Tip Calculator");
				Console.WriteLine("[4] --- Imaginary Product");
				Console.WriteLine("[5] --- Exit");
				
				int select = int.Parse( Console.ReadLine() );
				Console.WriteLine("");
				
				switch (select)
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
						Console.WriteLine("Invalid input, try again.");
						break;
				}
			}
			Console.WriteLine("Enter any key to exit...");
			Console.ReadLine();
		}
		
		static void ContAdd()
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
		
		static void Factorial()
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
		
		static int fact(int n)
		{
			if (n == 0) return 0;
			if (n == 1) return 1;
			else return n *= fact(n-1);
		}
		
		static void EZTip()
		{
			Console.WriteLine("Enter amount billed: ");
			float amount = float.Parse( Console.ReadLine() );
			Console.WriteLine("Enter tip percentage: ");
			float percent = ( float.Parse( Console.ReadLine() ) / 100 );
			Console.WriteLine("");
			
			Console.WriteLine("Tip: ${0}", amount * percent);
			Console.WriteLine("Total to be paid: ${0}" , amount *(1 + percent));
		}
		
		public struct imagNum
		{
			public int real;
			public int imag;
		}
		
		static imagNum product(imagNum n1, imagNum n2)
		{
			imagNum result;
			result.real = (n1.real * n2.real) - (n1.imag * n2.imag);
			result.imag = (n1.real * n2.imag) + (n2.real * n1.imag);
			return result;
		}
		
		static void ImagProd()
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