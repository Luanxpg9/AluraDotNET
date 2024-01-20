using Array_GenericTypes.Exceptions;
using Array_GenericTypes.Models.Account;
using Array_GenericTypes.Util;

namespace Array_GenericTypes.Test;
internal class CheckingAccountListTest
{
    private readonly CheckingAccountList AccountList = new(3);
    private readonly List<string> FailedTests = new();
    private readonly CheckingAccount TestAccount = new(115);

    private void TestNewAccount()
    {
        var acc = new CheckingAccount(112, 4000);
        AccountList.Add(acc);
    }

    private void MaxCapacityList()
    {
        try
        {
            AccountList.Add(TestAccount);
            AccountList.Add(TestAccount);
            AccountList.Add(TestAccount);
            AccountList.Add(TestAccount);
        }
        catch (GenericException ex)
        {
            FailedTests.Add("Failed at maxcapacity with error: " + ex.Message);
        }
        
    }

    private void RemoveFrom()
    {
        try
        {
            AccountList.Remove(TestAccount);
        }
        catch (GenericException ex)
        {
            FailedTests.Add("Failed at RemoveFrom with error: " + ex.Message);
        }
        
    }

    private void AccessByIndex()
    {
        try
        {
            AccountList.Add(TestAccount);
            var size = AccountList.Size - 1;
            _ = AccountList[size];
        }
        catch (GenericException ex)
        {
            FailedTests.Add("Failed at AccessByIndex with error: " + ex.Message);
        }
    }

    public List<string> Exec()
    {
        TestNewAccount();
        MaxCapacityList();
        RemoveFrom();
        AccessByIndex();

        return FailedTests;
    }

}
