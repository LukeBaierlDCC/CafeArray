using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeArray
{
    public class Wallet
    {
        private double balance;

        public Wallet(double balance)
        {
            this.balance = balance;
        }

        public void AddMoney(double amount)
        {
            balance += amount;
        }

        public bool MakePayment(double amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public double GetBalance()
        {
            return balance;
        }
    }

}
