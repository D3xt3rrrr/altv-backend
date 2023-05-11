using AltV.Net;
using gamemode.core.Database;
using Npgsql;

namespace gamemode.Player;

public class MyPlayer : AltV.Net.Elements.Entities.Player
{
    public int db_Id { get; set; }
    public int AccountId { get; set; }
    public Accounts Account { get; set; }
    private String Name;
    private string LastName;
    public float x, y, z;
    public bool LoggedIn { get; set; }
  
    public MyPlayer(ICore core, IntPtr nativePointer, ushort id) : base(core, nativePointer, id)
    {
        this.LoggedIn = false;
    }

    public bool Connect(string email, string password)
    {
        List<Accounts> accountList = Postgresql.FetchAll<Accounts>("SELECT * from player where email=@email", new NpgsqlParameter[]
        {
            new NpgsqlParameter("@email", "name")
        });
        
        if (accountList.Count > 1)
            throw new Exception("<--- Mysql : found more than 1 player");
        else if (accountList.Count == 0)
            throw new Exception("<--- Mysql : no player was found --->");

        if (email == accountList[0].Email && password == accountList[0].Password)
        {
            this.db_Id = accountList[0].Id;
           // Spawn spawn = new Spawn(this);
            return true;
        }

        return false;
    }

    public void Disconnect()
    {
        
    }

    public void Create()
    {
        
    }

   

    
}