namespace ATM;

class Program
{
    static List<User> users = new List<User>();
    static List<Transaction> transactions = new List<Transaction>();

    static void Main()
    {
        PredefinedUsers();

        Console.WriteLine("Hoş geldiniz! Lütfen kullanıcı adınızı girin: ");
        string username = Console.ReadLine();
        User user = GetUserByUsername(username);

        if (user != null)
        {
            Console.WriteLine($"Merhaba, {user.Username}!");

            while (true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçin:");
                Console.WriteLine("1. Para Çekme");
                Console.WriteLine("2. Para Yatırma");
                Console.WriteLine("3. Bakiye Sorgulama");
                Console.WriteLine("4. Gün Sonu Raporu Al");
                Console.WriteLine("5. Çıkış");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Withdraw(user);
                            break;
                        case 2:
                            Deposit(user);
                            break;
                        case 3:
                            CheckBalance(user);
                            break;
                        case 4:
                            EndOfDayReport(user);
                            break;
                        case 5:
                            Console.WriteLine("Çıkış yapılıyor...");
                            return;
                        default:
                            Console.WriteLine("Geçersiz seçenek. Tekrar deneyin.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen bir sayı seçeneği girin.");
                }
            }
        }
        else
        {
            Console.WriteLine("Kullanıcı kaydı bulunamadı. Lütfen kullanıcı adınızı kontrol edin.");
        }
    }

    static User GetUserByUsername(string username)
    {
        return users.Find(u => u.Username == username);
    }

    static void Withdraw(User user)
    {
        Console.Write("Çekmek istediğiniz tutarı girin: ");
        if (double.TryParse(Console.ReadLine(), out double amount))
        {
            if (user.Balance >= amount)
            {
                user.Balance -= amount;
                transactions.Add(new Transaction(user.Username, "Para Çekme", amount));
                Console.WriteLine($"Başarıyla {amount:C2} çektiniz. Yeni bakiyeniz: {user.Balance:C2}");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye. Tekrar deneyin.");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz tutar. Lütfen bir sayı girin.");
        }
    }

    static void Deposit(User user)
    {
        Console.Write("Yatırmak istediğiniz tutarı girin: ");
        if (double.TryParse(Console.ReadLine(), out double amount))
        {
            user.Balance += amount;
            transactions.Add(new Transaction(user.Username, "Para Yatırma", amount));
            Console.WriteLine($"Başarıyla {amount:C2} yatırdınız. Yeni bakiyeniz: {user.Balance:C2}");
        }
        else
        {
            Console.WriteLine("Geçersiz tutar. Lütfen bir sayı girin.");
        }
    }

    static void CheckBalance(User user)
    {
        Console.WriteLine($"Bakiyeniz: {user.Balance:C2}");
    }

    static void EndOfDayReport(User user)
    {
        string fileName = $"EOD_{DateTime.Now.ToString("ddMMyyyy")}.txt";
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Transaction transaction in transactions)
            {
                writer.WriteLine($"{transaction.Username} - {transaction.Type} - {transaction.Amount:C2}");
            }

            writer.WriteLine($"Toplam bakiye: {user.Balance:C2}");
        }

        Console.WriteLine($"Gün sonu raporu {fileName} dosyasına kaydedildi.");
    }

    static void PredefinedUsers()
    {
        users.Add(new User("user1", "password1", 1000.0));
        users.Add(new User("user2", "password2", 1500.0));
        users.Add(new User("user3", "password3", 2000.0));
    }
}

class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public double Balance { get; set; }

    public User(string username, string password, double balance)
    {
        Username = username;
        Password = password;
        Balance = balance;
    }
}

class Transaction
{
    public string Username { get; }
    public string Type { get; }
    public double Amount { get; }

    public Transaction(string username, string type, double amount)
    {
        Username = username;
        Type = type;
        Amount = amount;
    }
}