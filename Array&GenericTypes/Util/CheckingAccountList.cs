using Array_GenericTypes.Models.Account;
using System.Collections;

namespace Array_GenericTypes.Util;
internal class CheckingAccountList
{
    private CheckingAccount[] _itens;
    private uint _freeIndex;
    public uint Size { get => _freeIndex; }

    public CheckingAccount this[uint index]
    {
        get => Get(index);
    }

    public CheckingAccountList(int arraySize = 5)
    {
        _itens = new CheckingAccount[arraySize];
        _freeIndex = 0;
    }

    public void Add(CheckingAccount account)
    {
        if (_freeIndex == _itens.Length)
        {
            Console.WriteLine($"Array is full");
            IncreaseSize();
        } 

        _itens[_freeIndex] = account;
        Console.WriteLine($"Adding account '{account.Number}' at position {_freeIndex+1}");
        _freeIndex++;
    }

    public CheckingAccount Get(uint index)
    {
        if (index >= Size) throw new ArgumentOutOfRangeException(nameof(index));

        return _itens[index];
    }

    

    public void IncreaseSize(uint sizeToIncrease = 5)
    {
        Console.WriteLine($"Increasing capacity to {_itens.Length+sizeToIncrease}");
        CheckingAccount[] temp = new CheckingAccount[_itens.Length+sizeToIncrease];
        _itens.CopyTo(temp, 0);

        _itens = temp;
    }

    public void ShowAccout(uint index)
    {
        if (index > _freeIndex)
        {
            Console.WriteLine($"Given index is bigger than the list");
            return;
        }

        Console.WriteLine($"Showing account at position {index}:");
        Console.WriteLine($"\t->{_itens[index-1]}");
    }

    public void Remove(CheckingAccount account)
    {
        int accountIndex = -1;

        // Find Account
        for (int i = 0; i < _freeIndex; i++)
        {
            if (account == _itens[i])
            {
                accountIndex = i;
                break;
            }
        }

        if (accountIndex == -1) {
            Console.WriteLine($"Account not found in this list");
            return;
        }

        // Removing account and changing other further account positions
        for (int i = accountIndex; i < _freeIndex-1; i++)
        {
            _itens[i] = _itens[i+1];
        }

        _freeIndex--;
        _itens[_freeIndex] = null!;
        Console.WriteLine($"Account {account.Number} removed at index {accountIndex+1}");
    }

    public IEnumerator GetEnumerator() => _itens.Where(x => x is not null).GetEnumerator();
}
