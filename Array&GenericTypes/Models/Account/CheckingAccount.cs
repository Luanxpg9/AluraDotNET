using System.Diagnostics;

namespace Array_GenericTypes.Models.Account;

[DebuggerDisplay("Bank: {BankId}")]
internal class CheckingAccount : IComparable<CheckingAccount>
{
    public int Agency { get; }
    public string Number { get; }
    public double Balance { get; }

    public static int TotalCreated { get; private set; }

    public CheckingAccount(int agency, double balance = 0.0, string? number = null)
    {
        Agency = agency;
        Number = number ?? new Random().NextInt64(9999).ToString("D" + 4) + "-X";
        Balance = balance;
        TotalCreated += 1;
    }

    public override string ToString() => $"Agency: '{Agency}'\t Account Number: '{Number}'";

    public int CompareTo(CheckingAccount? other)
    {
        if (other == null)
        {
            return 1;
        }

        if (Agency == other.Agency)
        {
            return Number.CompareTo(other.Number);
        }

        return Agency.CompareTo(other.Agency);
    }
}

