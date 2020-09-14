using System;
namespace BankATM {

    public class BankAcct: IComparable<BankAcct>{ 

        //Class Variables
        private string fName;
        private string lName;
        private int acct;
        private decimal bal;
        private short pin;

        //Constructor
        public BankAcct(string fName, string lName, int acct, short pin, decimal bal) {
            this.fName = fName;
            this.lName = lName;
            this.acct = acct;
            this.pin = pin;
            this.bal = bal;
        }

        //Getters
        public decimal getBal() {
            return bal;
        }

        public int getAcct() {
            return acct;
        }

        public string getFName() {
            return fName;
        }

        public string getLName() {
            return lName;
        }

        public short getPin() {
            return pin;
        }

        //Setters
        public void depBal(decimal balAmt) {
            //update acct balance
            bal += balAmt;
        }

        public void withBal(decimal balAmt) {
            //update acct balance

            if ( (bal - balAmt) > 0) { //If withdrawal !greater than bal

                bal -= balAmt;
            }
            else {
                Console.WriteLine("Insufficient funds! ");
            }
        }

        public int CompareTo(BankAcct obj) {
            //Comparator to sort accounts
            return acct.CompareTo(obj.acct);

        }
        
        public  void ToString() {

            //Display profile
            Console.WriteLine("//////////////////////");
            Console.WriteLine($"Name: {fName + " " + lName, 15}");
            Console.WriteLine($"Acct: {acct, 15}");
            Console.WriteLine($"Baln: {bal, 15:C}");
            Console.WriteLine("//////////////////////");
        }
    }
}
