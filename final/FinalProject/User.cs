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
    public User(string name, string password)
    {
        _name = name;
        _password = password;
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
        bool userFound = false;
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split("~");
            string dbName = parts[0];
            string dbPassword = parts[1];
            Console.WriteLine($"_name{_name} dbName {dbName} _password {_password} dbPassword {dbPassword}");
            if(_name.ToLower() == dbName.ToLower() && _password == dbPassword)
            {   
                userFound = true;
                Console.WriteLine("Login Successful.");
                return;
            }
        }

        if(userFound == false)
        {
            throw new CustomException(CustomException.ErrorCode.UserNotFound, "User not found");
        }

        Console.WriteLine("Sign up to enjoy cheap products.");
    }

}