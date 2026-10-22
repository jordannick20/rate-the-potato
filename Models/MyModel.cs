using DotNetEnv;
using MySqlConnector;

namespace Boilerplate.Models;

public class MyModel
{
    private string CONNECTION_STRING;

    public MyModel()
    {
        Env.Load();
        CONNECTION_STRING = Env.GetString("CONNECTION_STRING");
    }

    /*         public List<Test> Tests { get; set; } = new List<Test>();

            // this should be async
            public void GetTests()
            {
                using var connection = new MySqlConnection(CONNECTION_STRING);

                connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM tblreview";

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Tests.Add(new Test
                    {
                        Id = reader.GetInt32("id"),
                       // Field1 = reader.GetInt32("field1"),
                       // Field2 = reader.GetString("field2")
                    });
                }
            }  */
}