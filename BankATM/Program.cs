/*
 * The following C# program simulates an ATM machine.
 * 
 * It reads .txt file of bank accounts, tokenizes them,
 * and adds to a list. It then sorts and searches for the
 * correct account. Withdrawal and deposit is chosen and
 * then the user is asked to proceed or quit.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace BankATM {

    class Program {

        static void Main(string[] args) {

            //Variables
            int acct;
            int size = 0;   //# of acct read from file
            decimal bal;
            decimal amt = 0; //amt to dep/with
            short pin;
            string fName;
            string lName;
            char proc;       //proceed or terminate prog.
            char with_dept;
            bool loop = true;
            bool found = false;

            //1.Declare list of bnk acct here.
            List<BankAcct> list = new List<BankAcct>();

            //2.Read File with accts here.
            Program.readFile(ref list, ref size);

            //3.Sort files
            list.Sort();

            //4.Menu
            do {

                try {
                    Console.Write("Enter acct: ");
                    acct = int.Parse(Console.ReadLine());

                    //search for acct
                    var tmpAcct = new BankAcct(null, null, acct, 0, 0); //tmp acct to find index

                    int index = list.BinarySearch(tmpAcct); // Where acct is in list 

                    if (index > 0) { //If an account is found.
                        found = true;
                    }

                    if (found == false) {
                        Console.WriteLine("Not Found! ");

                        //proceed[y/n]?
                        Console.Write("Continue[y/n]: ");
                        proc = Console.ReadLine()[0];


                        //Error Check
                        while (Char.ToLower(proc) != 'y' && Char.ToLower(proc) != 'n') {

                            Console.Write("Continue[y/n]: ");
                            proc = Console.ReadLine()[0];
                        }

                        //User continue or quit program
                        if (Char.ToLower(proc) == 'y') {
                            continue; //Skip entire program and begin again. Like an ATM.
                        }
                        else {
                            Environment.Exit(0); //Goodbye!
                        }
                    }

                    //enter pin
                    Console.Write("Enter pin: ");
                    pin = short.Parse(Console.ReadLine());

                    if (list[index].getPin() == pin) {

                        //Display account
                        list[index].ToString();

                        //with/depsoit
                        Console.Write("Withdrawal or Deposit[w/d]:");
                        with_dept = Console.ReadLine()[0];

                        //Error Check
                        while (Char.ToLower(with_dept) != 'w' && Char.ToLower(with_dept) != 'd') {

                            Console.Write("Withdrawal or Deposit[w/d]:");
                            with_dept = Console.ReadLine()[0];
                        }

                        //update balance

                        if (Char.ToLower(with_dept) == 'w') {

                            Console.Write("Enter amount: ");
                            amt = decimal.Parse(Console.ReadLine());

                            list[index].withBal(amt); //Update balance
                        }
                        else if (Char.ToLower(with_dept) == 'd') {

                            Console.Write("Enter amount: ");
                            amt = decimal.Parse(Console.ReadLine());

                            list[index].depBal(amt); //Update balance

                        }
                    }
                    else {

                        Console.WriteLine("Incorrect! ");

                        //proceed[y/n]?
                        Console.Write("Continue[y/n]: ");
                        proc = Console.ReadLine()[0];


                        //Error Check
                        while (Char.ToLower(proc) != 'y' && Char.ToLower(proc) != 'n') {

                            Console.Write("Continue[y/n]: ");
                            proc = Console.ReadLine()[0];
                        }

                        //User continue or quit program
                        if (Char.ToLower(proc) == 'y') {
                            continue; //Skip entire program and begin again. Like an ATM.
                        }
                        else {
                            Environment.Exit(0);  //Goodbye!
                        }
                    }

                }
                catch (Exception e) when (e is IndexOutOfRangeException || e is FormatException) {

                    continue; //Skip entire program and begin again. Like an ATM.

                }

                //proceed[y/n]?
                Console.Write("Continue[y/n]: ");
                proc = Console.ReadLine()[0];

                //Error Check
                while (Char.ToLower(proc) != 'y' && Char.ToLower(proc) != 'n') {

                    Console.Write("Continue[y/n]: ");
                    proc = Console.ReadLine()[0];
                }

                //User continue or quit program
                if (Char.ToLower(proc) == 'y') {
                    found = false; // reset bool
                    continue; //Skip entire program and begin again. Like an ATM.
                }
                else {
                    //5.Write File
                    Program.writeFile(ref list, ref size);
                    Environment.Exit(0);  //Goodbye!
                }


            } while (loop);
        }


//METHODS
/////////////////////////////////////////////////////////////////////////////////

//ReadFile
static public void readFile(ref List<BankAcct> list, ref int size) {
/*
 *Pre: Takes list of accounts and size var to count number of account.
 *
 *Post: Locates file, reads, declares tmp Bank Account constructor and
 *adds to list of accounts, increments size++.
 */

 //Variables
 string line;
 string[] lineArr;
 int acct;
 decimal bal;
 short pin;
 string fName;
 string lName;

 System.IO.StreamReader file =
     new System.IO.StreamReader(@"/Users/Dimitrov/C#Projects/BankATM/BankATM/BankData.txt");

    while ((line = file.ReadLine()) != null) { //While lines to read

        lineArr = line.Split(" "); //tokenize

        //Tokenize each line in file. Hardcoded so no need to iterate thru each line.
        fName = lineArr[0];
        lName = lineArr[1];
        acct = int.Parse(lineArr[2]);
        pin = short.Parse(lineArr[3]);
        bal = decimal.Parse(lineArr[4]);

        var tmpAcct = new BankAcct(fName, lName, acct, pin, bal); //Establish account.

        //Add acct to list of accounts in data structure.
        list.Add(tmpAcct);
        size++;
     }

     file.Close();
}

//WriteFile
static public void writeFile(ref List<BankAcct> list, ref int size) {
/*
 * Pre: take in List of bank accounts
 *
 * Post: Writes accounts to .txt file for futur use
 */

    using (StreamWriter writer = new StreamWriter(@"/Users/Dimitrov/C#Projects/BankATM/BankATM/BankData.txt")) {

        for(int i = 0; i < size; i++) {

            writer.WriteLine($"{list[i].getFName()} {list[i].getLName()} {list[i].getAcct()} {list[i].getPin()} {list[i].getBal()}" );
                    
        }
                
    }

}


    } //class program

} //namespace
