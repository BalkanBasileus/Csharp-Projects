/*************************************************************
 *Authored by BalkanBasileus
 *
 *The following C# program asks for real and imaginary nums
 *and builds two overloaded structs and displays the results
 *in terms of [-,+,*]. 
 *
 *Program shows use of operator overloading.
 *
 *************************************************************/
using System;

namespace ComplexNumber {

  class Program {

    static void Main(string[] args) {

      //Local Vars
      double realOne, realTwo, imagOne, imagTwo;

      //Prompt for numbers
      Console.Write("Enter first Real num[<20]:");
      realOne = double.Parse( Console.ReadLine() );

      //Error
      while(realOne > 20 || realOne < 1) {
        Console.Write("Enter first Real num[<20]:");
        realOne = double.Parse(Console.ReadLine());
      }

      Console.Write("Enter first Imaginary num[<20]:");
      imagOne = double.Parse( Console.ReadLine() );

      //Error
      while (imagOne > 20 || imagOne < 1) {
        Console.Write("Enter first Imaginary num[<20]:");
        imagOne = double.Parse(Console.ReadLine());
      }

      Console.Write("Enter second Real num[<20]:");
      realTwo = double.Parse(Console.ReadLine());

      //Error
      while(realTwo > 20 || realTwo < 1) {
        Console.Write("Enter second Real num[<20]:");
        realTwo = double.Parse(Console.ReadLine());
      }

      Console.Write("Enter second Imaginary num[<20]:");
      imagTwo = double.Parse(Console.ReadLine());

      //Error
      while(imagTwo > 20 || imagTwo < 1) {
        Console.Write("Enter second Imaginary num[<20]:");
        imagTwo = double.Parse(Console.ReadLine());
      }

      var x = new ComplexNumStruct(realOne, imagOne);
      var y = new ComplexNumStruct(realTwo, imagTwo);

      Program.displayResults(ref x, ref y);

    }

    //METHODS
    ////////////////////////////////////////////////////////////////////////
    public static void displayResults(ref ComplexNumStruct x, ref ComplexNumStruct y) {

      Console.WriteLine();
      Console.WriteLine("Results:");
      Console.WriteLine($" {x} + {y} = {x + y}");
      Console.WriteLine($" {x} - {y} = {x - y}");
      Console.WriteLine($" {x} * {y} = {x * y}");
    }
  }
}

/*
 Sample Output

Enter first Real num[<20]:3
Enter first Imaginary num[<20]:4
Enter second Real num[<20]:5
Enter second Imaginary num[<20]:5

Results:
 (3 + 4i) + (5 + 5i) = (8 + 9i)
 (3 + 4i) - (5 + 5i) = (-2 - 1i)
 (3 + 4i) * (5 + 5i) = (-5 + 35i)
*/
