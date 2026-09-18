



/*
Основные функции:
‒	Просмотр доступных комнат на выбранную дату
‒	Бронирование комнаты
‒	Отмена бронирования
‒	Просмотр своих бронирований


*/

/// <summary> Прото комната </summary>
record Rooms{
    public int Number; 
    public DateTime Date;

    public bool IsFree; 

}

static class BookingSystem{
    /// <summary> Комнаты </summary>
    private static List<Rooms> FreeRooms = [
        new Rooms() {
            Number = 1, 
            Date = new DateTime(2026, 9, 9), 
            IsFree = true
        },
        new Rooms() {
            Number = 2, 
            Date = new DateTime(2026, 9, 10), 
            IsFree = true
        },
        new Rooms() {
            Number = 3, 
            Date = new DateTime(2026, 9, 11), 
            IsFree = true
        },

    ]; 

    /// <summary> 
    /// Заброненные комнаты
    /// 1 - user id; 
    /// 2 - room id 
    /// </summary>
    private static List<(int, int)> BookedRooms = []; 


    /// <summary> Просмотр доступных комнат на выбранную дату </summary>
    public static List<Rooms> GetFreeRoom(DateTime curen_date){
        return FreeRooms.Where(
            (Rooms i) => {
                if(!i.IsFree)  return false; 

                if(i.Date != curen_date) return false; 

                return true; 
            }
        ).ToList(); 
    }

    /// <summary> Бронирование комнаты </summary>
    /// <param name="curen_date"></param>
    public static void BookRoom(DateTime curen_date, int user_id){
        for(int i = 0; i < FreeRooms.Count; i += 1){

            if(FreeRooms[i].Date == curen_date){
                FreeRooms[i].IsFree = false;
                BookedRooms.Add((user_id, i)); 
                return;
            }
        }
        throw new Exception("Нет комнаты"); 
    }


    /// <summary> Отмена бронирования </summary>
    public static void DeleteBook(int user_id, int id_room){
        for(int i = 0; i < BookedRooms.Count; i += 1){
            var curent_record = BookedRooms[i]; 
            if(
                curent_record.Item1 == user_id && 
                curent_record.Item2 == id_room
            ){
                FreeRooms[id_room].IsFree = true;
                BookedRooms.RemoveAt(i); 
                return;
            }

        }
        throw new Exception("Нет комнаты"); 
    }

    /// <summary> Просмотр своих бронирований </summary>
    public static List<Rooms> ShowBookRooms(int user_id){
        List<Rooms> res = [];
        for(int i = 0; i < BookedRooms.Count; i += 1){
            var curent_record = BookedRooms[i]; 

            if(curent_record.Item1 == user_id ){
                res.Add(
                    FreeRooms[curent_record.Item2]
                ); 
            }
        }

        return res;
    }

}





class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int userId = 101;

        while (true)
        {
            Console.Clear();

            Console.WriteLine("========================================");
            Console.WriteLine("       СИСТЕМА БРОНИРОВАНИЯ КОМНАТ");
            Console.WriteLine("========================================");
            Console.WriteLine($"Текущий пользователь: {userId}");
            Console.WriteLine();

            Console.WriteLine("1. Просмотреть свободные комнаты");
            Console.WriteLine("2. Забронировать комнату");
            Console.WriteLine("3. Мои бронирования");
            Console.WriteLine("4. Отменить бронирование");
            Console.WriteLine("0. Выход");
            Console.WriteLine();

            Console.Write("Выберите действие: ");
            string? command = Console.ReadLine();

            try
            {
                switch (command)
                {
                    case "1":
                        ShowFreeRooms();
                        break;

                    case "2":
                        BookRoom(userId);
                        break;

                    case "3":
                        ShowMyBookings(userId);
                        break;

                    case "4":
                        DeleteBooking(userId);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Неизвестная команда.");
                        Pause();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Ошибка: {ex.Message}");
                Pause();
            }
        }
    }


    /// <summary>
    /// Просмотр свободных комнат
    /// </summary>
    static void ShowFreeRooms()
    {
        Console.Clear();

        Console.WriteLine("========== СВОБОДНЫЕ КОМНАТЫ ==========");
        Console.Write("Введите дату (дд.мм.гггг): ");

        DateTime date = ReadDate();

        var rooms = BookingSystem.GetFreeRoom(date);

        Console.WriteLine();

        if (rooms.Count == 0)
        {
            Console.WriteLine("На выбранную дату свободных комнат нет.");
        }
        else
        {
            Console.WriteLine("Свободные комнаты:");

            foreach (var room in rooms)
            {
                Console.WriteLine(
                    $"  Комната №{room.Number} | " +
                    $"Дата: {room.Date:dd.MM.yyyy} | " +
                    $"Статус: свободна");
            }
        }

        Pause();
    }


    /// <summary>
    /// Бронирование комнаты
    /// </summary>
    static void BookRoom(int userId)
    {
        Console.Clear();

        Console.WriteLine("=========== БРОНИРОВАНИЕ ===========");
        Console.Write("Введите дату (дд.мм.гггг): ");

        DateTime date = ReadDate();

        var rooms = BookingSystem.GetFreeRoom(date);

        if (rooms.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Свободных комнат на эту дату нет.");
            Pause();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Доступные комнаты:");

        foreach (var room in rooms)
        {
            Console.WriteLine($"  №{room.Number}");
        }

        Console.WriteLine();
        Console.Write("Забронировать комнату №");

        int roomNumber = int.Parse(Console.ReadLine()!);

        // В текущей реализации BookingSystem
        // бронируется первая свободная комната на дату.
        var selectedRoom = rooms.FirstOrDefault(
            r => r.Number == roomNumber);

        if (selectedRoom == null)
        {
            Console.WriteLine("Такой комнаты нет.");
            Pause();
            return;
        }

        BookingSystem.BookRoom(date, userId);

        Console.WriteLine();
        Console.WriteLine(
            $"Комната №{roomNumber} успешно забронирована.");
        Console.WriteLine($"Дата: {date:dd.MM.yyyy}");

        Pause();
    }


    /// <summary>
    /// Просмотр собственных бронирований
    /// </summary>
    static void ShowMyBookings(int userId)
    {
        Console.Clear();

        Console.WriteLine("=========== МОИ БРОНИРОВАНИЯ ===========");

        var rooms = BookingSystem.ShowBookRooms(userId);

        Console.WriteLine();

        if (rooms.Count == 0)
        {
            Console.WriteLine("У вас нет активных бронирований.");
        }
        else
        {
            foreach (var room in rooms)
            {
                Console.WriteLine(
                    $"Комната №{room.Number} | " +
                    $"Дата: {room.Date:dd.MM.yyyy}");
            }
        }

        Pause();
    }


    /// <summary>
    /// Отмена бронирования
    /// </summary>
    static void DeleteBooking(int userId)
    {
        Console.Clear();

        Console.WriteLine("========== ОТМЕНА БРОНИРОВАНИЯ ==========");

        var rooms = BookingSystem.ShowBookRooms(userId);

        if (rooms.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("У вас нет активных бронирований.");
            Pause();
            return;
        }

        Console.WriteLine();

        foreach (var room in rooms)
        {
            Console.WriteLine(
                $"Комната №{room.Number} | " +
                $"Дата: {room.Date:dd.MM.yyyy}");
        }

        Console.WriteLine();
        Console.Write("Введите номер комнаты: ");

        int roomNumber = int.Parse(Console.ReadLine()!);

        // Поиск комнаты по номеру
        var selectedRoom = rooms.FirstOrDefault(
            r => r.Number == roomNumber);

        if (selectedRoom == null)
        {
            Console.WriteLine("Бронирование не найдено.");
            Pause();
            return;
        }

        // В исходной структуре id комнаты совпадает
        // с индексом списка только частично.
        BookingSystem.DeleteBook(userId, roomNumber - 1);

        Console.WriteLine();
        Console.WriteLine("Бронирование отменено.");

        Pause();
    }


    /// <summary>
    /// Ввод даты
    /// </summary>
    static DateTime ReadDate()
    {
        while (true)
        {
            string? input = Console.ReadLine();

            if (DateTime.TryParse(input, out DateTime date))
            {
                return date.Date;
            }

            Console.Write("Неверный формат. Введите дату ещё раз: ");
        }
    }


    /// <summary>
    /// Ожидание действия пользователя
    /// </summary>
    static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Нажмите Enter для продолжения...");
        Console.ReadLine();
    }
}