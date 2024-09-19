using System.Data.SQLite;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


string connectionString = "Data Source=database.db;Version=3;";

// Utwórz bazę danych, jeśli nie istnieje
using (SQLiteConnection conn = new SQLiteConnection(connectionString))
{
    conn.Open();

    // Utwórz tabelę, jeśli nie istnieje
    string createTableQuery = @"CREATE TABLE IF NOT EXISTS People (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            FirstName TEXT NOT NULL,
                                            LastName TEXT NOT NULL
                                            );";

    using (SQLiteCommand cmd = new SQLiteCommand(createTableQuery, conn))
    {
        cmd.ExecuteNonQuery();
    }

    // Pobierz dane od użytkownika
    Console.WriteLine("Podaj imię:");
    string firstName = Console.ReadLine();
    Console.WriteLine("Podaj nazwisko:");
    string lastName = Console.ReadLine();

    // Wstaw dane do bazy danych
    string insertQuery = "INSERT INTO People (FirstName, LastName) VALUES (@FirstName, @LastName);";

    using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
    {
        cmd.Parameters.AddWithValue("@FirstName", firstName);
        cmd.Parameters.AddWithValue("@LastName", lastName);
        cmd.ExecuteNonQuery();
    }

    Console.WriteLine("Dane zostały zapisane do bazy danych.");
}