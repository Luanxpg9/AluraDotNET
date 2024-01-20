// See https://aka.ms/new-console-template for more information

const string FILEPATH = "accounts.txt";
var stream = new FileStream(FILEPATH, FileMode.Open, FileAccess.Read);


var accounts = File.ReadAllLines(FILEPATH);

foreach (var account in accounts)
{
    Console.WriteLine(account);
}

