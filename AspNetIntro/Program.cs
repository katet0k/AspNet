using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

// Заповнення даними про себе та навички
var aboutMe = new AboutMe
{
    FullName = "Kostiuchenko Kateryna",
    Origin = "Vinnitsa",
    StudyPlace = "Комп'ютерна академія Step",
    Skills = new List<Skill>
    {
        new Skill { Id = 1, Name = "C++", Proficiency = 80 },
        new Skill { Id = 2, Name = "C#", Proficiency = 85 },
        new Skill { Id = 3, Name = "JavaScript", Proficiency = 75 },
        new Skill { Id = 4, Name = "HTML&CSS", Proficiency = 90 },
        new Skill { Id = 5, Name = "ADO.NET, EF Core, Dapper", Proficiency = 70 },
        new Skill { Id = 6, Name = "MS SQL Server", Proficiency = 65 },
        new Skill { Id = 7, Name = "Angular і React", Proficiency = 60 }
    }
};



app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html";

    await context.Response.WriteAsync("<!DOCTYPE html><html lang=\"en\"><head>    <meta charset=\"UTF-8\"> <link href='/css/style.css' rel='stylesheet'>   <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">  <title>Document</title></head><body>   "
        + "<div class=\"Conteiner1\">"

        + "<div class=\"Conteiner2\">"

        + "<img class=\"Photo\" src='img/photo1.jpeg' alt=\"no photo\">"

        + "<a class=\"Interesting\" href='https://github.com/katet0k'>Github.Katet0k</a>"
        + "<a class=\"Skils\" href='/skils'>Мої навички</a>"

        + "</div>"

        + "<div class=\"Conteiner3\">"

        + " <p class=\"NameP\">Призвище та ім'я</p><hr>"
        + "<p class=\"Name\">" + aboutMe.FullName + "</p>"

        + "<p class=\"NameP\">Звідки я</p><hr>"
        + "<p class=\"Where\">" + aboutMe.Origin + "</p>"

        + "<p class=\"NameP\">Де навчаюсь</p><hr>"
        + "<p class=\"Study\">" + aboutMe.StudyPlace + "</p>"

        + "<p class=\"NameP\">Мої навички</p><hr>"
        + "<table class=\"SkillTable\">"
        + "<tr><th>Навичка</th><th>Рівень володіння</th></tr>");

    foreach (var skill in aboutMe.Skills)
    {
        await context.Response.WriteAsync("<tr><td>" + skill.Name + "</td><td><div class='progress'><div class='progress-bar' style='width:" + skill.Proficiency + "%'>" + skill.Proficiency + "%</div></div></td></tr>");
    }

    await context.Response.WriteAsync("</table>"
        + "</div>"
        + " </div></body></html>");
});

app.MapGet("/skils", async context =>
{
    context.Response.ContentType = "text/html";

    await context.Response.WriteAsync("<!DOCTYPE html><html lang=\"en\"><head>    <meta charset=\"UTF-8\"> <link href='/css/style.css' rel='stylesheet'>   <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">  <title>Document</title></head><body>   "
        + "<div class=\"Conteiner1\">"

        + "<div class=\"Conteiner2\">"

        + "<img class=\"Photo\" src='img/photo1.jpeg' alt=\"no photo\">"

        + "<a class=\"Interesting\" href='https://github.com/katet0k'>Github.Katet0k</a>"
        + "<a class=\"Skils\" href='/'>Повернутись</a>"
        + "</div>"

        + "<div class=\"Conteiner3\">"

        + " <p class=\"NameP\">Мої навички</p><hr>"
        + "<table class=\"SkillTable\">"
        + "<tr><th>Навичка</th><th>Рівень володіння</th></tr>");

    foreach (var skill in aboutMe.Skills)
    {
        await context.Response.WriteAsync("<tr><td>" + skill.Name + "</td><td><div class='progress'><div class='progress-bar' style='width:" + skill.Proficiency + "%'>" + skill.Proficiency + "%</div></div></td></tr>");
    }

    await context.Response.WriteAsync("</table>"
        + "</div>"
        + " </div> \r\n</body>\r\n</html>");
});

app.Run();

// Модель "Навичка"
public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Proficiency { get; set; }
}

// Модель інформації про себе з колекцією навичок
public class AboutMe
{
    public string FullName { get; set; }
    public string Origin { get; set; }
    public string StudyPlace { get; set; }
    public List<Skill> Skills { get; set; }
}
