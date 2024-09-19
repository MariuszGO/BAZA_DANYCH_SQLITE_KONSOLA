using System.Data.SQLite;
Console.WriteLine("Hello, World!");


string connectionString = "Data Source=database.db;Version=3;";





int wybor = 0;

do
{

    Console.WriteLine("Podaj co chcesz zrobić: 1. Zapisz 2. Odczytaj 3. Zakończ");
    wybor = Convert.ToInt32(Console.ReadLine());

    if (wybor == 1)
    {



        using (SQLiteConnection conn = new SQLiteConnection(connectionString))
        {
            conn.Open();


            string createTableQuery = @"CREATE TABLE IF NOT EXISTS osoby (
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


            string insertQuery = "INSERT INTO osoby (imie, nazwisko) VALUES (@imie, @nazwisko);";

            using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@imie", im);
                cmd.Parameters.AddWithValue("@nazwisko", naz);
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Dane zostały zapisane do bazy danych.");

        }
    }

    if (wybor == 2)
    {

        string connectionString1 = "Data Source=database.db;Version=3;";

        using (SQLiteConnection conn1 = new SQLiteConnection(connectionString1))
        {
            conn1.Open();


            string selectQuery = "SELECT * FROM osoby;";

            using (SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn1))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("Zawartość tabeli Osoby:");


                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string im1 = reader.GetString(1);
                        string na = reader.GetString(2);

                        Console.WriteLine($"ID: {id}, Imię: {im1}, Nazwisko: {na}");
                    }
                }
            }
        }

    }

}while(wybor != 3);
   
