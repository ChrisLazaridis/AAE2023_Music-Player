namespace AAE2023_Music_Player;

public class DbConnection(string name)
{
    // This class is used to make the connection to the database more secure by hiding the connection string from the main thread 
    public string ConnectionString { get; } = $"Data Source={name};Version=3;";
}