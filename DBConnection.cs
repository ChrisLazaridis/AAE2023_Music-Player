namespace AAE2023_Music_Player;

public class DbConnection(string name)
{
    public string ConnectionString { get; } = $"Data Source={name};Version=3;";
}