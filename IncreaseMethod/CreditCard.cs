using System;
using System.Collections.Generic;
using System.Text;

namespace IncreaseMethod
{
    public delegate void CardHandler(string message);

    public class CreditCard
    {
        public string Number 
        {
            get;
            set;
        }
        public string Owner
        {
            get;
            set;
        }
        public string ExpireDate
        {
            get;
            set;
        }
        public string Pin
        {
            get;
            set;
        }
        public double Limit
        {
            get;
            set;
        }
        public double Money
        {
            get;
            set;
        }
        public double SumMoney
        {
            get;
            set;
        }

        public event CardHandler? OnDeposit;
        public event CardHandler? OnWithdraw;
        public event CardHandler? OnCreditStart;
        public event CardHandler? OnLimitReached;
        public event CardHandler? OnPinChange;

        public CreditCard(string number, string owner, string expireDate, string pin, double limit, double money, double targetMoney)
        {
            Number = number;
            Owner = owner;
            ExpireDate = expireDate;
            Pin = pin;
            Limit = limit;
            Money = money;
            SumMoney = SumMoney;
        }

        public void Deposit(double amount)
        {
            Money += amount;

            if (OnDeposit != null)
            {
                OnDeposit("Поповнення рахунку на суму: " + amount + " грн");
            }

            if (Money >= SumMoney && OnLimitReached != null)
            {
                OnLimitReached("Досягнуто задану суму! Поточний баланс: " + Money + " грн");
            }
        }

        public void Withdraw(double amount)
        {
            bool wasPositive = Money >= 0;

            if (Money + Limit >= amount)
            {
                Money -= amount;

                if (OnWithdraw != null)
                {
                    OnWithdraw("Зняття коштів з рахунку: " + amount + " грн");
                }

                if (wasPositive && Money < 0 && OnCreditStart != null)
                {
                    OnCreditStart("Увага: Розпочато використання кредитних коштів!");
                }
            }
            else
            {
                Console.WriteLine("Помилка: Перевищено кредитний ліміт!");
            }
        }

        public void ChangePin(string oldPin, string newPin)
        {
            if (Pin == oldPin)
            {
                Pin = newPin;
                if (OnPinChange != null)
                {
                    OnPinChange("PIN-код успішно змінено!");
                }
            }
            else
            {
                Console.WriteLine("Помилка: Невірно введено старий PIN!");
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("=== ІНФОРМАЦІЯ ПРО КАРТКУ ===");
            Console.WriteLine("Номер: " + Number);
            Console.WriteLine("Власник: " + Owner);
            Console.WriteLine("Термін дії: " + ExpireDate);
            Console.WriteLine("Кредитний ліміт: " + Limit + " грн");
            Console.WriteLine("Баланс: " + Money + " грн");
            Console.WriteLine("---------------------------");
        }
    }
}
