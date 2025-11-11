



using System.Runtime.CompilerServices;
// dotnet add package MySql.Data
using MySql.Data.MySqlClient;

using System.Text.RegularExpressions;
using System.Threading.Tasks;





class DataBase: IDisposable{
    /// Одиночка для работы с БД
    public static DataBase SinglDataBase;
    
    /// <summary> Создание одиночки </summary>
    static DataBase(){ SinglDataBase = new DataBase(); }


    /// <summary> Подключение к БД </summary>
    protected MySqlConnection connection; 

    /// <summary> Подключаемся к БД и проверяем что есть БД Lily </summary>
    protected DataBase(){
        // Сервер с БД
        string server = "localhost";
        // Пользователь
        string user = "root";
        // Пароль пользователя
        string password = "123oihoihtfr43fe";
        // Название БД
        string student = "student";

        this.connection = new MySqlConnection($"Server={server};Database={student};User ID={user};Password={password};");
        // Открываем подключение к БД
        this.connection.Open();
    }


    /// <summary> Проверка на наличии SQL инъекций </summary>
    /// <param name="check_string"> Строка для проверки </param>
    public static void SheckSQLIniection(params string?[] strings){
        /*
            Данные для проверки:
            авааа
            ihoho
            fejiршгрр98ihoih
            myemail@gmail.com

            ihoho;
            mye@mail@gmail.com
            (ihoho)
            ihoho or 1=1;
            ihoho--
            ihoho/*
            //ihoho

            Регулярка:
            [\w\sа-я\.]+ 
            [@]{0,1}
            [\w\sа-я\.]+

            ^([\w\sа-я\.]+[@]{0,1}[\w\sа-я\.]+)$
        */

        string pattern = @"^([\w\sа-я\.]+[@]{0,1}[\w\sа-я\.]+)$"; 

        Parallel.ForEach(strings, (chec_str, pls) => {
            if(chec_str == null){ return; }

            if(Regex.IsMatch(chec_str, pattern)){ return; }

            throw new SQLInjection(); 
        });
    }

    /// <summary> Выдать данные о студентах </summary>
    public async Task<List<(long, Strudent)>> GetStudent(){
        Task<MySqlDataReader> command = Task.Run(() =>{
            using var command = new MySqlCommand("""
                SELECT * FROM students; 
                """, this.connection
            );
            return command.ExecuteReader();
        });
        List<(long, Strudent)> res = [];
        using var reader = await command;

        while (reader.Read()){
            res.Add((
                Convert.ToInt64(reader["id"]), 
                new Strudent(
                (string)(reader["name"]), (string)(reader["parents"]),
                (string)(reader["address"]), (string)(reader["phone_number"]),
                (string)(reader["passport_data"]), (string)(reader["group"]),
                Convert.ToDateTime(reader["birthday"]), Convert.ToDateTime(reader["date_receipt"]),
                Convert.ToBoolean(reader["is_full_time"]), Convert.ToInt32(reader["number_record_book"]),
                Convert.ToInt16(reader["nuber_course"]), Convert.ToInt64(reader["id_specialty"])
            )));
        }
        return res;
    }

    /// <summary> Удалить данные о студентах по ID (На вызов добавить обработчик на Exception) </summary>
    public async Task DeleteStudent(params long[] strudent){}

    /// <summary> Изменить данные о студентах (На вызов добавить обработчик на Exception) </summary>
    public async Task SetStudent(params (long, Strudent)[] strudent){}

    /// <summary> Добавить данные о студентах (На вызов добавить обработчик на Exception) </summary>
    public async Task SetStudent(params Strudent[] strudent){}



    /// <summary> Выдать данные о студентах, фамилия  которых начинается на букву П. (На вызов добавить обработчик на Exception) </summary>
    public async Task<List<StrudentSpecialtie>> FindStudent(char firse_char_name = 'П'){
        Task<MySqlDataReader> command = Task.Run(() =>{
            using var command = new MySqlCommand("""
                SELECT 
                    students.name AS stud_name, parents, 
                    address, phone_number, 
                    passport_data, `group`, 
                    birthday, date_receipt, 
                    is_full_time, number_record_book, 
                    nuber_course, specialties.name AS sp_name, 
                    `describe`
                FROM students
                    JOIN specialties 
                    ON students.id_specialty = specialties.id
                    WHERE students.name REGEXP("^П.+$"); 
                """, this.connection
            );
            return command.ExecuteReader();
        });
        List<StrudentSpecialtie> res = [];
        using var reader = await command;

        while (reader.Read())
        {
            res.Add(new StrudentSpecialtie(
                (string)(reader["stud_name"]), (string)(reader["parents"]),
                (string)(reader["address"]), (string)(reader["phone_number"]),
                (string)(reader["passport_data"]), (string)(reader["group"]),
                Convert.ToDateTime(reader["birthday"]), Convert.ToDateTime(reader["date_receipt"]),
                Convert.ToBoolean(reader["is_full_time"]), Convert.ToInt32(reader["number_record_book"]),
                Convert.ToInt16(reader["nuber_course"]), (string)(reader["sp_name"]),
                (string)(reader["describe"])
            ));
        }
        return res;
    }



    /// <summary> Поиск средний балл по всем студентам </summary>
    public async Task<float> AvgAll(){
        Task<MySqlDataReader> command = Task.Run(() =>{
            using var command = new MySqlCommand("""
                SELECT AVG(mark) AS avg_mark  FROM exams;
                """, this.connection
            );
            return command.ExecuteReader();
        });
        using var reader = await command; 

        reader.Read(); // Читаем полученные результаты 
        return reader.GetFloat("avg_mark");
    }

    /// <summary> Поиск средний балл по каждому студенту. </summary>
    public async Task<List<(string, float)>> AvgAny(){
        Task<MySqlDataReader> command = Task.Run(() =>{
            using var command = new MySqlCommand("""
                SELECT name, AVG(mark) AS avg_mark FROM exams
                    JOIN students
                    ON exams.id_student = students.id
                    GROUP BY name;
                """, this.connection
            );
            return command.ExecuteReader();
        });
        List<(string, float)> res = [];
        using var reader = await command; 

        while (reader.Read()) {
            res.Add((
                (string)(reader["name"]),
                Convert.ToSingle(reader["avg_mark"])
            ));
        }
        return res;
    }

    public void Dispose() {
        this.connection.Close();
        this.connection.Dispose();
        Console.WriteLine("- БД");
    }
}