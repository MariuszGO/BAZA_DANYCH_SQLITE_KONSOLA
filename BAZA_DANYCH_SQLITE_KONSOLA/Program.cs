using System.Data.SQLite;
Console.WriteLine("Hello, World!");


string connectionString = "Data Source=database.db;Version=3;";


using (SQLiteConnection conn = new SQLiteConnection(connectionString))
{
    conn.Open();


    string createTableQuery = @"CREATE TABLE IF NOT EXISTS Uczniowie1 (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            imie TEXT NOT NULL,
                                            nazwisko TEXT NOT NULL
                                            );";

    using (SQLiteCommand cmd = new SQLiteCommand(createTableQuery, conn))
    {
        cmd.ExecuteNonQuery();
    }


    Console.WriteLine("Podaj imię:");
    string im = Console.ReadLine();
    Console.WriteLine("Podaj nazwisko:");
    string naz = Console.ReadLine();

    
    string insertQuery = "INSERT INTO Uczniowie1 (imie, nazwisko) VALUES (@imie, @nazwisko);";

    using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
    {
        cmd.Parameters.AddWithValue("@imie", im);
        cmd.Parameters.AddWithValue("@nazwisko", naz);
        cmd.ExecuteNonQuery();
    }

    Console.WriteLine("Dane zostały zapisane do bazy danych.");
}