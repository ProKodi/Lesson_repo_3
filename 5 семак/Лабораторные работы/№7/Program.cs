



using System.Runtime.CompilerServices;
// dotnet add package MySql.Data
using MySql.Data.MySqlClient;



/// <summary> Класс для работы с БД </summary>

class DB : IDisposable
{
    public static DB this_db;

    /// <summary> Статический конструктор для объявления стат полей </summary>
    static DB(){
        DB.this_db = new DB( "localhost", "root", "123oihoihtfr43fe" );
    }


    protected MySqlConnection connection;

    /// <summary> Конструктор БД </summary>
    /// <param name="server">Сервер с БД</param>
    /// <param name="user">Пользователь</param>
    /// <param name="password">Пароль пользователя</param>
    /// <param name="database">Имя БД (можно не указывать если хотим сделать свою)</param>
    protected DB(string server, string user, string password){

        string connectionString = $"Server={server};Database=student;User ID={user};Password={password};";
        

        this.connection = new MySqlConnection(connectionString);
        // Открываем подключение к БД
        this.connection.Open();
    }


    /*public List<(string, int)> GetInform(){
        // Пример запроса
        string query = "SELECT * FROM disciplines";

        List<(string, int)> res = new List<(string, int)>();

        using var command = new MySqlCommand(query, this.connection);
        using var reader = command.ExecuteReader();
        while (reader.Read()){
            res.Add( ( (string)reader["name"], (int)reader["age"] ) );
        }
        return res;
    }*/
    

    public void Dispose(){ 
        // Закрываем подключение к БД
        this.connection.Close(); 
    }


}



class Program{
    public static void Main(){
        using (DB.this_db){

            /*foreach ((string, int) i in DB.this_db.GetInform())
            {
                Console.WriteLine($"Name: {i.Item1}, age: {i.Item2}");
            }*/
        }
    }
}

/*
Разработать  главную  экранную  форму  с  четырьмя  кнопками.  

Первая  для отображения данных таблицы Студент и ввода новых данных в таблицу.
    Отображение данных в виде таблички
    Внизу строчка для добавления данных в БД
    Слева от строчки кнопка для сохранения + обновление таблички

Новая форма: Сделать тоже самое как в 1, вывсети только id и name + не добавлять функционал для добавление данных

Вторая для  открытия  третьей  формы,  третья– четвертой.  
Четвертая  - выход  из программы.  
Для  каждой  кнопки  прописать  соответствующий  код  либо 
открытие новой формы, либо – закрытие главной формы.

*/