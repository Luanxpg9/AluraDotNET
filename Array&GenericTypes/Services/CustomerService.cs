using Array_GenericTypes.Exceptions;
using Array_GenericTypes.Models.Account;
using System.Text.Json;

namespace Array_GenericTypes.Service;
internal class CustomerService
{
    private readonly string SAVEFILE;
    private readonly List<CheckingAccount> _accountList;

    public CustomerService(string savefile = "accounts.json") 
    {   
        SAVEFILE = savefile;
        _accountList = LoadListFromFile();
    }

    private static void PrintHeader()
    {
        Console.Clear();
        Console.WriteLine("===================================");
        Console.WriteLine("======== Customer Services ========");
        Console.WriteLine("===================================");
        Console.WriteLine("===     1- Register Account     ===");
        Console.WriteLine("===     2- List Accounts        ===");
        Console.WriteLine("===     3- Remove Account       ===");
        Console.WriteLine("===     4- Order Accounts       ===");
        Console.WriteLine("===     5- Search Account       ===");
        Console.WriteLine("===     6- Leave System         ===");
        Console.WriteLine("\n\n");
        Console.Write("Type desired option: ");
    }

    private void RegisterAccount()
    {
        Console.Clear();
        Console.Clear();
        Console.WriteLine("===================================");
        Console.WriteLine("====== Account Registration =======");
        Console.WriteLine("===================================");
        Console.WriteLine("\nEnter the account info\n");
        Console.Write("Bank Agency: ");
        string? agencyInput = Console.ReadLine();

        if (agencyInput is null)
        {
            Console.WriteLine("Invalid agency");
            return;
        }

        if (!int.TryParse(agencyInput, out int agencyNumber))
        {
            Console.WriteLine("Invalid Agency, Try typing only numbers");
            return;
        }

        Console.Write("\nAccount Balance: ");
        string? balanceInput = Console.ReadLine();
        double balanceNumber = 0.0;

        if (balanceInput != null && !double.TryParse(balanceInput, out balanceNumber))
        {
            Console.WriteLine("Invalid balance. The value must be written in numbers only!");
            return;
        }

        CheckingAccount newAccount = new(agencyNumber, balanceNumber);

        _accountList.Add(newAccount);
        Console.WriteLine("Account registered!");
        Console.ReadKey();
    }

    private CheckingAccount? FindAccount()
    {
        Console.Clear();
        Console.WriteLine("===================================");
        Console.WriteLine("=========== Find Account ==========");
        Console.WriteLine("===================================\n");

        if (_accountList.Count == 0)
        {
            Console.WriteLine("No Account has been registered...");
            Console.ReadKey();
            return null;
        }

        Console.Write("Please enter the Bank Account number: ");

        string? userInput = Console.ReadLine();

        if (userInput == null)
        {
            Console.WriteLine("Invalid Bank Account number! Please try again");
            Console.ReadKey();
            return null;
        }

        CheckingAccount? foundAccount = _accountList.Find(x => x.Number.Equals(userInput));

        if (foundAccount == null)
        {
            Console.WriteLine("Account not found! have you typed the right Account number?");
            Console.ReadKey();
            return null;
        }

        Console.WriteLine($"Account found: {foundAccount}");
        Console.ReadKey();
        return foundAccount;
    }

    private void OrderAccounts()
    {
        _accountList.Sort();
        Console.WriteLine("List is now ordered");
        Console.ReadKey();
    }

    private void RemoveAccount()
    {
        Console.Clear();
        Console.WriteLine("===================================");
        Console.WriteLine("========== Remove Account =========");
        Console.WriteLine("===================================\n");

        var foundAccount = FindAccount();

        if (foundAccount == null) return;

        _accountList.Remove(foundAccount);
        Console.WriteLine("Account Removed successfully");
        Console.ReadKey();
    }

    private void ListAccounts()
    {
        Console.Clear();
        Console.WriteLine("===================================");
        Console.WriteLine("=========== Account List ==========");
        Console.WriteLine("===================================\n");

        if (_accountList.Count == 0)
        {
            Console.WriteLine("No Account has been registered...");
            Console.ReadKey();
            return;
        }

        foreach (CheckingAccount account in _accountList)
        {
            Console.WriteLine("=== Account Info ===");
            Console.WriteLine($"-> Agency: {account.Agency}");
            Console.WriteLine($"-> Number: {account.Number}");
            Console.WriteLine($"-> Balance: ${account.Balance}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        Console.ReadKey();
    }

    public bool SaveListOnDisk()
    {
        if (!_accountList.Any())
        {
            return true;
        }

        var accountsJson = JsonSerializer.Serialize<List<CheckingAccount>>(_accountList);
        File.WriteAllText(SAVEFILE, accountsJson);

        return true;
    }

    public List<CheckingAccount> LoadListFromFile()
    {
        List<CheckingAccount>? loadedAccounts = new();
        string accountsJson;
        try
        {
            accountsJson = File.ReadAllText(SAVEFILE);
        }
        catch
        {
            return loadedAccounts;
        }

        loadedAccounts =
            JsonSerializer.Deserialize<List<CheckingAccount>>(accountsJson);

        if (loadedAccounts == null)
            return new List<CheckingAccount>();

        return loadedAccounts;
    }

    public void Exec()
    {
        try
        {
            char option = '0';

            while (option != '6')
            {
                PrintHeader();

                string? userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                    option = '6';
                else
                    option = userInput[0];

                switch (option)
                {
                    case '1':
                        RegisterAccount();
                        break;
                    case '2':
                        ListAccounts();
                        break;
                    case '3':
                        RemoveAccount();
                        break;
                    case '4':
                        OrderAccounts();
                        break;
                    case '5':
                        FindAccount();
                        break;
                    case '6':
                        SaveListOnDisk();
                        Console.WriteLine("Byee :)");
                        break;
                    default:
                        SaveListOnDisk();
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }
        catch (GenericException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
