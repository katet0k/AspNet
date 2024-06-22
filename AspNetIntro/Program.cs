using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html";

    await context
    .Response
    .WriteAsync("<!DOCTYPE html><html lang=\"en\"><head>    <meta charset=\"UTF-8\"> <Link href='/css/style.css' rel='stylesheet'>   <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">  <title>Document</title></head><body>   " 
    +"<div class=\"Conteiner1\">"

    + "<div class=\"Conteiner2\">"

    + "<img class=\"Photo\" src='img/photo1.jpeg' alt=\"no photo\">"

    + "<a class=\"Interesting\" href='https://github.com/katet0k'>Github.Katet0k</a>"
    + "<a class=\"Skils\" href='/skils'>Мої навички</a>"

    +" </div>"

    + "<div class=\"Conteiner3\">"

    + " <p class=\"NameP\">Призвище та ім'я</p><hr>"
    + "<p class=\"Name\">Kostiuchenko Kateryna</p>"

    + "<p class=\"NameP\">Звідки я</p><hr>"
    +"<p class=\"Where\">Vinnitsa</p>"

    + "<p class=\"NameP\">Де навчаюсь</p><hr>"
    + "<p class=\"Study\">Комп'ютерна академія Step</p>"

    +"</div>"

        + " </div></body>\r\n</html>");
});


app.MapGet("/skils", async context =>
{
    context.Response.ContentType = "text/html";

    await context
    .Response
    .WriteAsync("<!DOCTYPE html><html lang=\"en\"><head>    <meta charset=\"UTF-8\"> <Link href='/css/style.css' rel='stylesheet'>   <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">  <title>Document</title></head><body>   "
    + "<div class=\"Conteiner1\">"

    + "<div class=\"Conteiner2\">"

    + "<img class=\"Photo\" src='img/photo1.jpeg' alt=\"no photo\">"

    + "<a class=\"Interesting\" href='https://github.com/katet0k'>Github.Katet0k</a>"
    + "<a class=\"Skils\" href='/'>Повернутись</a>"
    +"</div>"

    + "<div class=\"Conteiner3\">"

    + " <p class=\"NameP\">Мої навички</p><hr>"
     +
    "<ul>" +
    "<p>C++</p>" +
    "<p>C#</p>" +
    "<p>JavaScript</p>" +
    "<p>HTML&CSS</p>" +
    "<p>ADO.NET, EF Core, Dapper</p>" +
    "<p>MS SQL Server</p>" +
    "<p>Angular і React</p>" +
    "</ul>"

    + "</div>"

    + " </div> \r\n</body>\r\n</html>");
});


app.Run();
