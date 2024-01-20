namespace Files;
internal class CheckingAccount
{
    public int Number { get; }
    public int Agency { get; }
    public double Balance { get; private set; }
    public Client Holder { get; set; }

    public CheckingAccount(int agency, int number, string holderName)
    {
        Agency = agency;
        Number = number;
        Holder = new Client() { Name = holderName };
    }

    public void Deposit(double value)
    {
        if (value <= 0)
            throw new ArgumentException("Deposit value must be positive.", nameof(value));

        Balance += value;
    }

    public void Withdraw(double value)
    {
        if (value <= 0)
            throw new ArgumentException("Withdraw value must positive", nameof(value));

        if (value > Balance)
            throw new InvalidOperationException("Insufficient funds.");

        Balance -= value;
    }
}
