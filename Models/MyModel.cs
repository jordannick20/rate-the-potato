using DotNetEnv;
using MySqlConnector;
using Superpower.Parsers;

namespace Boilerplate.Models;

public class MyModel
{
    private string CONNECTION_STRING;

    public MyModel()
    {
        Env.Load();
        CONNECTION_STRING = Env.GetString("CONNECTION_STRING");
    }

    public List<Review> Reviews { get; set; } = new List<Review>();

    public void GetReviews()
    {
        using var connection = new MySqlConnection(CONNECTION_STRING);

        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM tblreview";

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Reviews.Add(new Review
            {
                Id = reader.GetInt32("id"),
                Rating = reader.GetInt32("rating"),
                First = reader.GetString("first"),
                Last = reader.GetString("last"),
                Comment = reader.GetString("comment")

            });
        }
    }

    public async Task AddReview(Review Reviews)
    {
        using var Connection = new MySqlConnection(CONNECTION_STRING);

        Connection.Open();

        using var Command = Connection.CreateCommand();

        Command.CommandText = "INSERT INTO tblGrades (categoryID,courseName,courseDescription,grade,comments) VALUES (@categoryID,@courseName,@courseDescription,@grade,@comments)";

        Command.Parameters.AddWithValue("@id", Reviews.Id);
        Command.Parameters.AddWithValue("@rating", Reviews.Rating);
        Command.Parameters.AddWithValue("@first", Reviews.First);
        Command.Parameters.AddWithValue("@last", Reviews.Last);
        Command.Parameters.AddWithValue("@comment", Reviews.Comment);

        await Command.ExecuteNonQueryAsync();
    }

}