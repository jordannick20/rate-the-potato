using DotNetEnv;
using Microsoft.Data.Sqlite;

namespace Boilerplate.Models;

public class ReviewModel
{
    private string CONNECTION_STRING;

    public ReviewModel()
    {
        Env.Load();
        CONNECTION_STRING = Env.GetString("CONNECTION_STRING");
    }

    public List<Review> Reviews { get; set; } = new List<Review>();

    public void GetReviews()
    {
        try
        {
            using var connection = new SqliteConnection(CONNECTION_STRING);

            Reviews.Clear();

            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
                "SELECT * FROM tblreview ORDER BY id DESC";

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Reviews.Add(new Review
                {
                    Id = reader.GetInt32(0),
                    Rating = reader.GetInt32(1),
                    First = reader.GetString(2),
                    Last = reader.GetString(3),
                    Comment = reader.GetString(4)
                });
            }
        }
        catch
        {
            Reviews = new List<Review>();
        }
    }

    public void AddReview(Review review)
    {

        using var Connection = new SqliteConnection(CONNECTION_STRING);

        Connection.Open();

        using var Command = Connection.CreateCommand();

        Command.CommandText = "INSERT INTO tblreview (rating,first,last,comment) VALUES (@rating,@first,@last,@comment)";

        Command.Parameters.AddWithValue("@rating", review.Rating);
        Command.Parameters.AddWithValue("@first", review.First);
        Command.Parameters.AddWithValue("@last", review.Last);
        Command.Parameters.AddWithValue("@comment", review.Comment);

        Command.ExecuteNonQuery();

    }

}