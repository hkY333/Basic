[System.Serializable]
public class UserData
{
    public string id;
    public string password;
    public string name;
    public ulong cash;
    public ulong balance;

    public UserData(string newID, string newPassword, string newName, ulong newCash, ulong newBalance)
    {
        id = newID;
        password = newPassword;
        name = newName;
        cash = newCash;
        balance = newBalance;
    }
}