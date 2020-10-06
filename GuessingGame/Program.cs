/******************************************
 *C# guessing game program.
 *
 *Menu prompt. Asks user to guess num from
 *1-6 and hints at correct answer. 3 tries.
 *
 *FormatExeption needs to be completed..
 *"Enter guess: "
 *
 ******************************************/
using System;

namespace GuessingGame {

  class Program {

    static void Main(string[] args) {

      //Local Variables
      int guess;
      int tries = 3;
      bool cont = true;
      char proceed;

      Random rand = new Random();

      //Prompt
      Console.WriteLine("*******************");
      Console.WriteLine("Guessing Game![1-6]");
      Console.WriteLine("Attempts: 3");
      Console.WriteLine("*******************");
      do {

         int ans = rand.Next(1, 6);    //Rand 1-6

         //While attempt < 3, play game.
         while (tries != 0) {

           Console.Write("Enter guess: ");
           guess = int.Parse(Console.ReadLine());
                    
           //Error Check
           while(guess < 1 || guess > 6) {

             Console.Write("Enter guess: ");
             guess = int.Parse(Console.ReadLine());
           }

             tries--;

             if (guess == ans) { //If Correct
                Console.WriteLine("Correct!");
                break;
             }
             if (guess < ans) {
                Console.WriteLine("higher..");
             }
             if (guess > ans) {
                Console.WriteLine("Lower..");
             }
             if (tries == 0) { //prompt before close
                Console.WriteLine("Loss! Answer: " + ans);
             }
         }
         //Play again?, if no exit doWhile
         Console.Write("Play Again[y/n]: ");
         proceed = Console.ReadLine()[0];
         tries = 3; //reset 

         //Error Check
         while ( Char.ToLower(proceed) != 'y' && Char.ToLower(proceed) != 'n' ){

            Console.Write("Play Again[y/n]: ");
            proceed = Console.ReadLine()[0];
        }

         //Terminate
         if (proceed == 'n') {
            cont = false;
         }

      } while (cont);

      Console.WriteLine("*******************");
    }
  }
}


/* Sample Output
 
*******************
Guessing Game![1-6]
Attempts: 3
*******************
Enter guess: 2
higher..
Enter guess: 3
Correct!
Play Again[y/n]: y
Enter guess: 3
higher..
Enter guess: 4
Correct!
Play Again[y/n]: n
*******************

*/