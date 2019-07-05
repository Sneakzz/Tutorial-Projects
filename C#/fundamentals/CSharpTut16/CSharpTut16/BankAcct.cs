using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut16
{
    class BankAcct
    {
        private Object acctLock = new object();
        double Balance { get; set; }
        string Name { get; set; }

        public BankAcct(double bal)
        {
            this.Balance = bal;
        }

        public double Withdraw(double amt)
        {
            if ((this.Balance - amt) < 0)
            {
                Console.WriteLine($"Sorry ${this.Balance} in Account");
                return this.Balance;
            }

            lock (this.acctLock)
            {
                if (this.Balance >= amt)
                {
                    Console.WriteLine("Removed {0} and {1} left in Account",
                        amt, (this.Balance - amt));
                    this.Balance -= amt;
                }

                return this.Balance;
            }
        }

        // You can only point at methods without arguments and that return nothing.
        public void IssueWithdraw()
        {
            this.Withdraw(1);
        }
    }
}
