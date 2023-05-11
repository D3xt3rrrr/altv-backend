using System.Runtime.CompilerServices;
using gamemode.core.Database;
using Npgsql;

namespace gamemode.Player;

public class Accounts
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int admin_level { get; set; }
    
    public Accounts(string email, string password, int admin_level)
    {
        this.Email = email;
        this.Password = password;
        this.admin_level = admin_level;
    }

    public Accounts(int id, string email, string password, int admin_level)
    {
        this.Id = id;
        this.Email = email;
        this.Password = password;
        this.admin_level = admin_level;
    }

    public bool Connect()
    {
        if (!new Ban(this).verify())
            return false;
        
        List<Accounts> accountList = Postgresql.FetchAll<Accounts>("SELECT * from account where email=@email", new NpgsqlParameter[]
        {
            new NpgsqlParameter("@email", Email)
        });
        
        
        if (accountList.Count > 1)
            throw new Exception("<--- PostgreSql : found more than 1 player --->");
        if (accountList[0].Email == Email)
            if (BCrypt.Net.BCrypt.Verify(Password + "sjfkdsakj433i##@$#", accountList[0].Password))
                return true;

        return false;
    }

    public bool Create()
    {
        List<Accounts> accountList = Postgresql.FetchAll<Accounts>("SELECT * from account where email=@email", new NpgsqlParameter[]
        {
            new NpgsqlParameter("@email", Email)
        });
        
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(Password + "sjfkdsakj433i##@$#");

        if (accountList.Count > 0)
            throw new Exception("<--- PostgreSQL : already have 1 player --->");
        else if (accountList.Count == 0)
        { 
            Postgresql.Execute( "INSERT INTO account (email, password) VALUES (@email , @password)", new NpgsqlParameter[]
            {
                new NpgsqlParameter("@email", Email),
                new NpgsqlParameter("@password", passwordHash)
            });
            

            int id = Postgresql.Id("SELECT currval('account_id_seq');");
            Console.WriteLine(id);
            return true;
        }
        
        return false;
    }

    public bool isAdmin()
    {
        if (admin_level == 4)
            return true;

        return false;
    }
}