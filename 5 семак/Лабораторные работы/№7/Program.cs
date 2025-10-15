



using System.Runtime.CompilerServices;
// dotnet add package MySql.Data
using MySql.Data.MySqlClient;



/// <summary> Класс для работы с БД </summary>

class DB: IDisposable{
    public static DB this_db;

    /// <summary> Статический конструктор для объявления стат полей </summary>
    static DB(){
        DB.this_db = new DB();
    }


    protected MySqlConnection connection; 

    protected DB(){
        // Сервер с БД
        string server = "localhost"; 
        // Пользователь
        string user = "root";
        // Пароль пользователя
        string password = "123oihoihtfr43fe";
        // Имя БД (можно не указывать если хотим сделать свою)
        string database = "student";

        // Строка подключения
        string connectionString = $"Server={server};Database={database};User ID={user};Password={password};";
        // Если имени Бд нет string connectionString = $"Server={server};User ID={user};Password={password};";

        this.connection = new MySqlConnection(connectionString);
        // Открываем подключение к БД
        this.connection.Open();
    }

    public void Dispose(){ 
        // Закрываем подключение к БД
        this.connection.Close(); 
    }




    public List<(string, int)> GetInform(){
        // Пример запроса
        string query = "SELECT * FROM disciplines";

        List<(string, int)> res = new List<(string, int)>();

        using var command = new MySqlCommand(query, this.connection);
        using var reader = command.ExecuteReader();
        while (reader.Read()){
            res.Add( ( (string)reader["name"], (int)reader["age"] ) );
        }
        return res;
    }



}



class Program{
    public static void Main(){
        using (DB.this_db){
            foreach((string, int) i in DB.this_db.GetInform()){
                Console.WriteLine($"Name: {i.Item1}, age: {i.Item2}");
            }
        }
    }
}

