using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace BankATM {

    public class StaticUtility /*IComparable<BankAcct> */{


        static public void readFile(ref List<BankAcct> list) {
        /*
         * Read .txt file containing bank accounts
         */

            StreamReader fileReader; //reads data from .txt file
            FileStream input = new FileStream("BankData.txt", FileMode.Open,FileAccess.Read); //create filestream

            //Set file from where to read
            fileReader = new StreamReader(input);

            BankAcct tmpAcct;


        }

        static public void writeFile(ref List<BankAcct> list) { }

        static public void sortFile(ref List<BankAcct> list) {
        }/*
            list.Sort((x, y) => x.getAcct.CompareTo(y.getAcct));

        }

        public int sortAcctAscending(BankAcct acct, BankAcct acctTwo) {

            return acct.CompareTo(acctTwo);
        }

        public int CompareTo(BankAcct acct) {
            // A null value means that this object is greater.
            if (acct.getAcct > 0)
                return 1;

            else
                return this.CompareTo(acct);
        }
*/
    }
}
