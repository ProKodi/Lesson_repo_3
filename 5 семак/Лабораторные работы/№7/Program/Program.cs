



public class Program{
    public static async Task Main(){
        using (DataBase.SinglDataBase)
        {
            /*Console.WriteLine($"Средний балл по всем студентам: {await DataBase.SinglDataBase.AvgAll()}");

            Console.WriteLine($"Средний балл по каждому студенту:");
            foreach(var i in  await DataBase.SinglDataBase.AvgAny()){
                Console.WriteLine($"\t{i.Item1}\t: {i.Item2}");
            }
            */
            /*
            foreach (var i in await DataBase.SinglDataBase.FindStudent()){
                Console.WriteLine(i);
            }
            */
            foreach (var i in await DataBase.SinglDataBase.GetStudent()){
                Console.WriteLine(i);
            }

        }
        // Тут БД больше нет (она закрыта)
    }
}