






using System.Runtime.InteropServices.JavaScript;

class My_server{
    protected WebApplication app;


    public My_server(string[] args){
        WebApplicationBuilder builder = WebApplication.CreateBuilder(new WebApplicationOptions { WebRootPath = ".//Program//wwwroot"});
        
        this.app = builder.Build();


        // Запрещаем кеширование стат файлов
        app.UseStaticFiles(new StaticFileOptions {
            OnPrepareResponse = ctx => {
                // Запрещаем кеширование браузером
                ctx.Context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                ctx.Context.Response.Headers["Pragma"] = "no-cache";
                ctx.Context.Response.Headers["Expires"] = "0";
            }
        });


        this.app.MapGet("/AvgAll", AvgAll);
        this.app.MapGet("/AvgAny", AvgAny);
        this.app.MapGet("/FindStudent", FindStudent);
        this.app.MapGet("/GetStudent", GetStudent);
        

        this.app.MapGet("/", HomePage);
        this.app.MapGet("/AVG", AVG);

        this.app.MapGet("/find_student", find_student);
        this.app.MapGet("/change", change);
    }

    /// <summary> Рассчет по среднему </summary>
    public async Task AvgAll(HttpContext context){
        HttpResponse response = context.Response;
        try {
            await context.Response.WriteAsJsonAsync(new {AVG = await DataBase.SinglDataBase.AvgAll()});
        }
        catch (Exception err) {
            response.StatusCode = 400;
            await response.WriteAsync(err.Message);
        }
    }

    /// <summary> Рассчет по каждому </summary>
    public async Task AvgAny(HttpContext context){
        HttpResponse response = context.Response;
        try {
            List<object> res = [];
            foreach(var i in await DataBase.SinglDataBase.AvgAny()){
                res.Add(new {Name = i.Item1, Mark = i.Item2});
            }
            await context.Response.WriteAsJsonAsync(res);
        }
        catch (Exception err) {
            response.StatusCode = 400;
            await response.WriteAsync(err.Message);
        }
    }

    public async Task FindStudent(HttpContext context){
        HttpResponse response = context.Response;
        try {
            List<object> res = [];
            // TODO - получить букву

            foreach (var i in await DataBase.SinglDataBase.FindStudent()){
                res.Add(new{
                    Name = i.Name, Sex = i.Sex, Parents = i.Parents, Address = i.Address,
                    PhoneNumber = i.PhoneNumber,  passportData = i.passportData,
                    Group = i.Group, Birthday = i.Birthday, DateReceipt = i.DateReceipt,
                    IsFullTime = i.IsFullTime, NumberRecordBook = i.NumberRecordBook,
                    NuberCourse = i.NuberCourse, NameSpecialty = i.NameSpecialty,
                });
            }
            await context.Response.WriteAsJsonAsync(res);
        }
        catch (Exception err) {
            response.StatusCode = 400;
            await response.WriteAsync(err.Message);
        }
    }


    public async Task GetStudent(HttpContext context){
        HttpResponse response = context.Response;
        try {
            List<object> res = [];
            // TODO - получить букву

            foreach ((long id, Strudent i) in await DataBase.SinglDataBase.GetStudent()){
                res.Add(new{
                    ID = id,
                    Name = i.Name, Parents = i.Parents, Address = i.Address,
                    PhoneNumber = i.PhoneNumber,  passportData = i.passportData,
                    Group = i.Group, Birthday = i.Birthday, DateReceipt = i.DateReceipt,
                    IsFullTime = i.IsFullTime, NumberRecordBook = i.NumberRecordBook,
                    NuberCourse = i.NuberCourse, NameSpecialty = i.NameSpecialty,
                });
            }
            await context.Response.WriteAsJsonAsync(new{Strudent = res, Spetialitest = await DataBase.SinglDataBase.GetNameSpetialitest()});
        }
        catch (Exception err) {
            response.StatusCode = 400;
            await response.WriteAsync(err.Message);
        }
    }


    /// <summary> Базовая страница проекта </summary>
    public async Task HomePage(HttpContext context){
        context.Response.Headers.ContentType = "charset=utf-8"; // устанавливаем кодировку
        await context.Response.SendFileAsync("./Program/wwwroot/pages/home/home.html"); // Отображаем HTML страницу
    }

    public async Task AVG(HttpContext context){
        context.Response.Headers.ContentType = "charset=utf-8"; // устанавливаем кодировку
        await context.Response.SendFileAsync("./Program/wwwroot/pages/AVG/AVG.html"); // Отображаем HTML страницу
    }

    


    public async Task find_student(HttpContext context){
        context.Response.Headers.ContentType = "charset=utf-8"; // устанавливаем кодировку
        await context.Response.SendFileAsync("./Program/wwwroot/pages/find_student/find_student.html"); // Отображаем HTML страницу
    }

    public async Task change(HttpContext context){
        context.Response.Headers.ContentType = "charset=utf-8"; // устанавливаем кодировку
        await context.Response.SendFileAsync("./Program/wwwroot/pages/change/change.html"); // Отображаем HTML страницу
    }




    public async Task start(){await this.app.StartAsync();}
}





public class Program{
    public static async Task Main(string[] args){
        using (DataBase.SinglDataBase)
        {
            My_server My_server = new My_server(args);
            await My_server.start();
            await Task.Delay(-1);

            /*Console.WriteLine($"Средний балл по всем студентам: {await DataBase.SinglDataBase.AvgAll()}");

            Console.WriteLine($"Средний балл по каждому студенту:");
            foreach(var i in  await DataBase.SinglDataBase.AvgAny()){
                Console.WriteLine($"/t{i.Item1}/t: {i.Item2}");
            }
            */
            /*
            foreach (var i in await DataBase.SinglDataBase.FindStudent()){
                Console.WriteLine(i);
            }
            */
            /*foreach (var i in await DataBase.SinglDataBase.GetStudent()){
                Console.WriteLine(i);
            }*/

        }
    }
}