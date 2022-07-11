using System;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getNume()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void consoleMessage(ConsoleColor color, string message)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Please choose from one of the following options");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
            Console.ResetColor();
        }

        void deposit(cardHolder currentUser)
        {
            consoleMessage(ConsoleColor.Yellow, "How much $$ would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            consoleMessage(ConsoleColor.Green, "Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            consoleMessage(ConsoleColor.Yellow, "How much $$ would you like to withdraw? ");
            double withdrawal = Double.Parse(Console.ReadLine());
            if(currentUser.getBalance() < withdrawal)
            {
                consoleMessage(ConsoleColor.Red, "Insufficient balance in your account :( ");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                consoleMessage(ConsoleColor.Green, "Success, new balance " + currentUser.getBalance() + "Thank you for Coming :)");
            }
        }

        void balance(cardHolder currentUser)
        {
            consoleMessage(ConsoleColor.Cyan, "Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("5502289", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new cardHolder("2235478", 2549, "Ashley", "Jones", 321.13));
        cardHolders.Add(new cardHolder("2265879", 3658, "Frida", "Dickerson", 105.59));
        cardHolders.Add(new cardHolder("2154798", 7894, "Muneeb", "Harding", 851.84));
        cardHolders.Add(new cardHolder("2545565", 2547, "Dawn", "Smith", 54.27));

        //promt user

        consoleMessage(ConsoleColor.Green, "Welcoome to SimpleATM");
        Console.WriteLine("Please insert your Debit card: ");
        string debitCardNum = "";
        cardHolder currentUser;
        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not recongnized. Please try again"); }
            }catch
            {
                Console.WriteLine("Card not recongnized. Please try again");
            }
        }

        Console.WriteLine("Please Enter your Pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //check db
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect Pin. Please try again"); }
            }
            catch
            {
                Console.WriteLine("Incorrect Pin. Please try again");
            }
        }

        Console.WriteLine("Welcome {0} :)", currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please Choose an Option");
            }

            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }



        } while (option != 4);

    }

}