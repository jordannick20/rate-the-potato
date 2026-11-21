using Microsoft.Data.Sqlite;
var builder = WebApplication.CreateBuilder(args);

var dbPath = Path.Combine("/tmp", "app.db");

using (var connection = new SqliteConnection($"Data Source={dbPath}"))
{
    connection.Open();

    var command = connection.CreateCommand();

    command.CommandText =
    @"
    CREATE TABLE IF NOT EXISTS tblreview
    (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        rating INTEGER,
        first TEXT,
        last TEXT,
        comment TEXT
    );
    ";

    command.ExecuteNonQuery();
}

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();