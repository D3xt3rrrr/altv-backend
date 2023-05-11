using System.Reflection;
using Npgsql;

namespace gamemode.core.Database;

public class Postgresql
{
    private static string connString = "Host=altv-postgres;Username=altv;Password=9144tbbw;Database=altv";
    private static NpgsqlConnection PostgresConn = new NpgsqlConnection(connString);
    

    public static void Open()
    {
        PostgresConn.Open();
    }

    public static void Close()
    {
        PostgresConn.Close();
    }


    public static void Execute(string query, NpgsqlParameter[] arrayParams)
    {
        NpgsqlCommand command = new NpgsqlCommand(query, PostgresConn);
        command.Connection = PostgresConn;

        if (arrayParams != null)
        {
            for (var i = 0; i < arrayParams.Length; i++)
            {
                command.Parameters.Add(arrayParams[i]);
            }
        }
        
        command.ExecuteNonQuery();
    }

    public static List<T> FetchAll<T>(string query, NpgsqlParameter[] arrayParams)
    {
        List<T> listItems = new List<T>();

        NpgsqlCommand command = new NpgsqlCommand(query);
        command.Connection = PostgresConn;

        if (arrayParams != null)
        {
            for (var i = 0; i < arrayParams.Length; i++)
            {
                command.Parameters.Add(arrayParams[i]);
            }
        }

        NpgsqlDataReader reader = command.ExecuteReader();
        int rowLenght = reader.FieldCount;

        while (reader.Read())
        {
            Object[] args = new object[rowLenght];

            for (var i = 0; i < rowLenght; i++)
                args[i] = reader.GetValue(i);

            listItems.Add((T)Activator.CreateInstance(typeof(T), args));
        }

        reader.Close();
        return listItems;
    }
    
    public static T Fetch<T>(string query, NpgsqlParameter[] arrayParams)
    {
        NpgsqlCommand command = new NpgsqlCommand(query);
        command.Connection = PostgresConn;

        if (arrayParams != null)
        {
            for (var i = 0; i < arrayParams.Length; i++)
            {
                command.Parameters.Add(arrayParams[i]);
            }
        }

        NpgsqlDataReader reader = command.ExecuteReader();
        int rowLenght = reader.FieldCount;
        Object[] args = new object[rowLenght];

        if (rowLenght == 1)
        {
            Console.WriteLine("entrer");
            while (reader.Read())
            {
                for (var i = 0; i < rowLenght; i++)
                    args[i] = reader.GetValue(i);
            }
        }

        reader.Close();
        return (T)Activator.CreateInstance(typeof(T), args);
    }


    public static int Id(string query) 
    {
        NpgsqlCommand command = new NpgsqlCommand(query);
        command.Connection = PostgresConn;

        NpgsqlDataReader reader = command.ExecuteReader();
        int rowLenght = reader.FieldCount;

        int id = 0;

        while (reader.Read())
            id = Convert.ToInt32(reader.GetValue(0));
        
        reader.Close();
        
        return id;
    }
}