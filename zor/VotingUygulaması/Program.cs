namespace VotingUygulaması;

class Program
{
    static List<Category> categories = new List<Category>{
        new Category("Film Kategorileri"),
        new Category("Tech Stack Kategorileri"),
        new Category("Spor Kategorileri")
    };

    static List<User> users = new List<User>();
    static void Main(string[] args)
    {
        Console.WriteLine("Voting Uygulamasına Hoş Geldiniz!");
        while (true)
        {
            Console.WriteLine("\n Kategoriler:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i].Name}");
            }

            Console.Write("Lütfen bir kategori seçin (1, 2, 3) veya 'q' ile çıkış yapın: ");
            string categoryChoice = Console.ReadLine();

            if (categoryChoice.ToLower() == "q")
            {
                ShowVotingResults();
                break;
            }

             if (int.TryParse(categoryChoice, out int categoryIndex) && categoryIndex >= 1 && categoryIndex <= categories.Count)
            {
                Category selectedCategory = categories[categoryIndex - 1];
                Console.WriteLine($"Seçilen Kategori: {selectedCategory.Name}");

                Console.Write("Kullanıcı Adınızı Girin: ");
                string username = Console.ReadLine();

                User user = GetUserByUsername(username);
                if (user == null)
                {
                    user = new User(username);
                    users.Add(user);
                }

                Console.Write("Oy Verin (1 - Evet, 2 - Hayır): ");
                if (int.TryParse(Console.ReadLine(), out int voteChoice) && (voteChoice == 1 || voteChoice == 2))
                {
                    Vote vote = new Vote(user, voteChoice == 1);
                    selectedCategory.Votes.Add(vote);
                    Console.WriteLine("Oyunuz kaydedildi.");
                }
                else
                {
                    Console.WriteLine("Geçersiz oy seçimi.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz kategori seçimi.");
            }

        
        }
    }

    static User GetUserByUsername(string username)
    {
        return users.Find(u => u.Username == username);
    }

    static void ShowVotingResults()
    {
        Console.WriteLine("Voting Sonuçları:");

        foreach (Category category in categories)
        {
            Console.WriteLine($"Kategori: {category.Name}");
            int totalVotes = category.Votes.Count;
            int yesVotes = category.Votes.Count(v => v.IsYes);
            int noVotes = totalVotes - yesVotes;
            double yesPercentage = (double)yesVotes / totalVotes * 100;
            double noPercentage = (double)noVotes / totalVotes * 100;

            Console.WriteLine($"Toplam Oy Sayısı: {totalVotes}");
            Console.WriteLine($"Evet Oy Sayısı: {yesVotes} (%{yesPercentage:F2})");
            Console.WriteLine($"Hayır Oy Sayısı: {noVotes} (%{noPercentage:F2})");

            Console.WriteLine();
        }
    }
}

class Category
{
    public string Name { get; }
    public List<Vote> Votes { get; } = new List<Vote>();

    public Category(string name)
    {
        Name = name;
    }
}

class User
{
    public string Username { get; }

    public User(string username)
    {
        Username = username;
    }
}

class Vote
{
    public User User { get; }
    public bool IsYes { get; }

    public Vote(User user, bool isYes)
    {
        User = user;
        IsYes = isYes;
    }
}

    



