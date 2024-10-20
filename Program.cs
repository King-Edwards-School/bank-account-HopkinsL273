namespace Object_interfaces
{

    class acc
    {
        private string sortcode;
        private int accountnumber;
        private string fname;
        private string sname;
        private string address;
        private double bal;
        public acc(string Pfname, string Psname, int Paccountnumber, string Psortcode, string Paddress)
        {
            fname = Pfname;
            sname = Psname;
            sortcode = Psortcode;
            accountnumber = Paccountnumber;
            address = Paddress;
            bal = 0;

        }
        public void printBal()
        {
            Console.WriteLine($"Balance: £{bal}\n");
        }
        public void printDetails()
        {
            Console.WriteLine($"Forename: {fname}\nSurname: {sname}\nSort Code: {sortcode}\nAccount number: {accountnumber}\nAddress: {address}");
        }
        public bool deposit(double amount)
        {
            bool success = false;
            try
            {
                bal = bal + amount;
            }
            catch
            {

            }
            return success;
        }
        public bool withdraw(double amount)
        {
            bool success = false;
            if (amount > bal)
            {
                Console.WriteLine($"Insufficient funds. \nYou have tried to withdraw £{amount} from this account with £{bal}\n");
            }
            else
            {
                bal = bal - amount;
                success = true;
            }

            return success;
        }

        public string getFname()
        {
            return fname;
        }
        public void setFname(string pfname)
        {
            fname = pfname;
        }
        public string getSname()
        {
            return sname;
        }
        public void setSname(string psname)
        {
            sname = psname;
        }
        public string getAdd()
        {
            return address;
        }
        public void setAdd(string padd)
        {
            address = padd;
        }
        public string getSort()
        {
            return sortcode;
        }
        public double getBal()
        {
            return bal;
        }



    }
    class bank
    {
        private int count;
        private acc[] accs;


        public bank(int size)
        {

            count = 0;
            accs = new acc[size];
        }
        public int newacc(string pfname, string psname, string address)
        {
            Random rnd = new Random();
            int r1 = rnd.Next(10, 100);
            int r2 = rnd.Next(10, 100);
            string currentsortcode = $"40-{r1}-{r2}";
            accs[count] = new acc(pfname, psname, count, currentsortcode, address);
            int tempcount = count;
            count++;
            return tempcount;
        }
        public void printall()
        {
            for (int i = 0; i < count; i++)
            {
                accs[i].printDetails();
                accs[i].printBal();
            }
        }

        public bool UpdateAddress(int paccnum, string padd)
        {
            bool success = false;
            try
            {
                accs[paccnum].setAdd(padd);
                success = true;
            }
            catch
            {
                success = false;
            }
            return success;
        }
        public bool UpdateFname(int paccnum, string pfname)
        {
            bool success = false;
            try
            {
                accs[paccnum].setFname(pfname);
                success = true;
            }
            catch
            {
                success = false;
            }
            return success;
        }

        public bool UpdateSname(int paccnum, string psname)
        {
            bool success = false;
            try
            {
                accs[paccnum].setSname(psname);
                success = true;
            }
            catch
            {
                success = false;
            }
            return success;
        }

        public bool Withdraw(int paccnum, double amount)
        {
            bool x = accs[paccnum].withdraw(amount);
            return x;
        }
        public bool Deposit(int paccnum, double amount)
        {
            bool x = accs[paccnum].deposit(amount);
            return x;
        }

        /*
        bool UpdateAdress(int acc_no,address)
bool UpdateForename(int acc_no, string address)
bool UpdateSurname(int acc_no, address)
bool Withdraw(int acc_no, int amount)
bool Deposit(int acc_no, amount)
        */
    }

    internal class Program
    {
        static void Main(string[] args)
        {


            bank egbank = new bank(10);
            egbank.newacc("me", "test", "lls lane 12123");
            egbank.newacc("This", "account", "lls lane 12123");
            egbank.newacc("si", "duwib", "lls lane 123");

            egbank.Deposit(2, 21221.21);
            egbank.Withdraw(2, 200);
            egbank.Deposit(1, 12);
            egbank.Withdraw(1, 20);
            egbank.UpdateSname(0, "UPDATED SURNAME");
            egbank.UpdateFname(0, "UPDATED FORENAME");
            egbank.UpdateAddress(0, "UPDATED ADDRESS");
            Console.WriteLine("Function to print all accounts & balances: ");
            egbank.printall();



            Console.WriteLine("\n Account 1 demonstrates Updating info, Account 2 demonstrates how you cannot withdraw more than you have, and account 3 demonstrates Deposit & Withdraw");




        }
    }
}

