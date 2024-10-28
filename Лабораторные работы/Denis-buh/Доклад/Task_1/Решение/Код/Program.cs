



class Program{
    static void Main(){
        // Создаем обьект-платформу
        YouTube platform = new YouTube(); 
        // Создаем объект-интерфейс 
        // (в конструктор передаем ранее созданную платформу) 
        BaseUser inter = new BaseUser(platform);

        // Работаем с платформой через интерфейс
        string res;
        res = inter.description("https://www.youtube.com/watch?v=dQw4w9WgXcQ"); // Получаем описание каково-то видео
        Console.WriteLine($"Description: {res}");
        res = inter.video("https://www.youtube.com/watch?v=dQw4w9WgXcQ");// Скачиваем какое-то видео
        Console.WriteLine($"Downloaded video: {res}");
    }
}