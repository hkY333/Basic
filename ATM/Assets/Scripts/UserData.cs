[System.Serializable]
public class UserData
{
    public string name;
    public ulong cash;
    public ulong balance;

    public UserData(string newName, ulong newCash, ulong newBalance)
    {
        name = newName;
        cash = newCash;
        balance = newBalance;
    }
}