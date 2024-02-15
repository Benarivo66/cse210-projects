public class User
{
    private string _name;
    private string _password;
    private string _userType;
    private string _filePath;

    public User(string name, string password, string userType)
    {
        _name = name;
        _password = password;
        _userType = userType;
        _filePath = "UserDB.txt";
    }
    public void SignUp()
    {
        using (StreamWriter writer = new StreamWriter(_filePath))
        {
            string userInfo = $"{_name}~{_password}~{_userType}";
            writer.WriteLine(userInfo);
        }
        Console.WriteLine("Sign up Successful");
    }

    public void Login()
    {
        string[] lines = System.IO.File.ReadAllLines(_filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split("~");
            string dbName = parts[0];
            string dbPassword = parts[1];
            if(_name == dbName && _password == dbPassword)
            {
                Console.WriteLine("Login Successful.");
                return;
            }
        }

        Console.WriteLine("Sign up to enjoy cheap products.");
    }

}