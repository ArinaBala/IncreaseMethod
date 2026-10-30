namespace IncreaseMethod
{
    internal class Program
    {
        static void Main()
        {
            //1
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string[] testStrings = new string[]
            {
                "{}[]",
                "(())",
                "[{}]",
                "[}",
                "[[{]}]"
            };

            foreach (string text in testStrings)
            {
                bool isValid = text.IsValidBrackets();
                string result = isValid ? "валідний рядок" : "невалідний рядок";
                Console.WriteLine(text + " — " + result);
            }

                //2

               

            CreditCard card = new CreditCard("4441-2222-3333-4444", "Настя буб", "12/28", "1234", 5000, 1000, 3000);

            card.OnDeposit += (msg) => Console.WriteLine("[ПОДІЯ] " + msg);
            card.OnWithdraw += (msg) => Console.WriteLine("[ПОДІЯ] " + msg);
            card.OnCreditStart += (msg) => Console.WriteLine("[ПОДІЯ] " + msg);
            card.OnLimitReached += (msg) => Console.WriteLine("[ПОДІЯ] " + msg);
            card.OnPinChange += (msg) => Console.WriteLine("[ПОДІЯ] " + msg);

            card.PrintInfo();

            card.Deposit(2500);
            card.Withdraw(1500);
            card.Withdraw(2500);
            card.ChangePin("1234", "9876");

            Console.WriteLine();
            card.PrintInfo();
        }
    }
}
