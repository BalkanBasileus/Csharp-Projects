using System;
using System.Collections.Generic;

namespace HashTables {

  class Program {
    //Options in main menu
    private enum options {
      ONE = 1,
      TWO = 2,
    }

    static void Main(string[] args) {

      //Main Variables
      int input = 0;
      bool terminate = false;
      char proceed = ' ';

      //Objects
      SortedDictionary<string, int> hashTable = new SortedDictionary<string, int>();

      Console.WriteLine("////////////////Welcome////////////////");
      do {
        try {
          //Prompt
          Console.WriteLine("MENU ");
          Console.WriteLine("1) Hash String ");
          Console.WriteLine("2) Hash File ");
          Console.WriteLine();

          Console.Write("Choose Option: ");
          input = int.Parse(Console.ReadLine());

          //Error Check
          while (input < 1 || input > 2) {
            Console.Write("Choose Option: ");
            input = int.Parse(Console.ReadLine());
          }

          //Execute Options
          switch ((options)input) {

          //Case ONE
          case options.ONE:

          Program.optionONE(ref hashTable, ref proceed);
          if (proceed == 'y') {
            hashTable.Clear(); //reset
            continue;
          }
          
          break;

          //Case TWO  
          case options.TWO:

          break;
          }

        }
        catch (Exception e) when (e is IndexOutOfRangeException || e is FormatException) {
          Console.WriteLine("///////////////////////////////////////");
          continue; // Skip remainder of code and begin again at try statement.
        }



      } while (!terminate);
    }

    //METHODS
    /////////////////////////////////////////////////////////////////////////////

    //Readfile method
    public void readFile() { }

    //Display hash table method
    public static void optionONE(ref SortedDictionary<string, int> hashTable, ref char proceed) {
      /*Pre:
       *
       *Post:
       */

      //Local Variables
      string sInput;

      Console.Write("Enter String to hash: ");
      sInput = Console.ReadLine();

      //Covert to string and tokenize
      string[] words = sInput.Split(" ");

      foreach (var word in words) {

        var key = word.ToLower(); //lower case

        //if hash table contains word
        if (hashTable.ContainsKey(key)) {
          hashTable[key]++; //inc value
        }
        else { // add new word with a count of 1 to dic.
          hashTable.Add(key, 1);
        }
      }

      //Display Hash Table 
      Console.WriteLine();
      Console.WriteLine($"Sorted HashTable: ");
      Console.WriteLine();

      Console.WriteLine($" {"Key",-10}{"Value",14}");

      foreach (var Key in hashTable.Keys) {

        Console.WriteLine($"{Key,-10}{hashTable[Key],15}");

      }
      Console.WriteLine();
      Console.WriteLine("Size; " + hashTable.Count);

      //Proceed?
      Console.Write("Continue[y/n]: ");
      proceed = Console.ReadLine()[0];

      //Error check
      while (Char.ToLower(proceed) != 'y' && Char.ToLower(proceed) != 'n') {

        Console.Write("Continue[y/n]: ");
        proceed = Console.ReadLine()[0];
      }

      if (Char.ToLower(proceed) == 'y') {
        Console.WriteLine("///////////////////////////////////////");
        proceed = 'y';
      }
      else {
        Console.WriteLine("///////////////////////////////////////");
        Environment.Exit(0);
      }
    }

    //optonTWO Method
    public static void optionTWO(ref SortedDictionary<string, int> hashTable, ref char proceed) {
      /*Pre:
       *
       *Post:
       */
    }
  }
}
