/*****************************************************************************
 * Author: BalkanBasileus
 * 
 * Program Description:
 *  
 *
 *
 *****************************************************************************/
using System;
using System.Collections.Generic;

namespace HashTables {

  class Program {

    //Options in main menu
    private enum options {
      ONE = 1,
      TWO = 2,
    }

    //MAIN
    static void Main(string[] args) {

      //Main Variables
      int input;
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
            continue; //begin again at try statement
          }
          
          break;

          //Case TWO  
          case options.TWO:
          Program.readFile(ref hashTable);
          Program.optionTWO(ref hashTable, ref proceed);

          if (proceed == 'y') {
            hashTable.Clear(); //reset
            continue; //begin again at try statement
          }

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
    /////////////////////////////////////////////////////////////////////////////////
    
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

      //Display Table Header 
      Console.WriteLine();
      Console.WriteLine($"Sorted HashTable: ");
      Console.WriteLine();

      //Header
      Console.WriteLine($" {"Key",-10}{"Value",14}");

      //Display Table
      foreach (var Key in hashTable.Keys) {

        Console.WriteLine($"{Key,-10}{hashTable[Key],15}");

      }
      Console.WriteLine();
      Console.WriteLine("Words: " + hashTable.Count);

      //Proceed?
      Console.Write("Continue[y/n]: ");
      proceed = Console.ReadLine()[0];

      //Error check
      while (Char.ToLower(proceed) != 'y' && Char.ToLower(proceed) != 'n') {

        Console.Write("Continue[y/n]: ");
        proceed = Console.ReadLine()[0];
      }

      //Write Header for main. Will reprompt menu w/ this on top.
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
      /*Pre: Takes hash table and menu driven char by ref.
       *
       *Post: Displays contents of hash table read from file by 'readFile' method.
       */

      //Display Table Header 
      Console.WriteLine();
      Console.WriteLine($"Sorted HashTable: ");
      Console.WriteLine();

      //Header
      Console.WriteLine($" {"Key",-21}{"Value",0}");

      //Display Table
      foreach (var Key in hashTable.Keys) {

        Console.WriteLine($"{Key,-22}{hashTable[Key],-1}");

      }
      Console.WriteLine();
      Console.WriteLine("Words: " + hashTable.Count);

      //Proceed?
      Console.Write("Continue[y/n]: ");
      proceed = Console.ReadLine()[0];

      //Error check
      while (Char.ToLower(proceed) != 'y' && Char.ToLower(proceed) != 'n') {

        Console.Write("Continue[y/n]: ");
        proceed = Console.ReadLine()[0];
      }

      //Write Header for main. Will reprompt menu w/ this on top.
      if (Char.ToLower(proceed) == 'y') {
        Console.WriteLine("///////////////////////////////////////");
        proceed = 'y';
      }
      else {
        Console.WriteLine("///////////////////////////////////////");
        Environment.Exit(0);
      }
    }
    

    //Readfile method
    public static void readFile(ref SortedDictionary<string, int> hashTable) {
      /*Pre: Take hash table by ref. 
       *
       *Post: Reads file by line, splits line, tokenizes words and populates
       *    hash table. Increments quantity if word repeats
       */

      //Local Vars
      string line;
      string[] stringArray;

      System.IO.StreamReader file = new
        System.IO.StreamReader(@"/Users/Dimitrov/Projects/HashTables/HashTables/data.txt");

      //Read Line. Tokenize. Map to hash table. Inc value.
      while( (line = file.ReadLine() ) != null) {

        //tokenize using .split()
        stringArray = System.Text.RegularExpressions.Regex.Split(line, @" ");

        foreach (var word in stringArray) {

          var key = word.ToLower(); //lower case

          //if hash table contains word
          if (hashTable.ContainsKey(key)) {
            hashTable[key]++; //inc value
          }
          else { // add new word with a count of 1 to dic.
            hashTable.Add(key, 1);
          }
        }

      }
      file.Close();
    }

  }
}
