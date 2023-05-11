using AltV.Net.Data;

namespace gamemode;

public class Config
{
    
    // information de la base de donner
    private const string DB_name = "altv";
    private const string DB_user = "root";
    private const string DB_ip= "10.0.0.251";
    private const string DB_pass = "9144tbbw";
    
    // information du joueurs
    private const float firstSpawn_x = 0;
    private const float firstSpawn_y = 0;
    private const float firstSpawn_z = 75;



    public static string getDbStringConnection()
    {
        return "server=" + DB_ip + ";uid=" + DB_user + ";pwd=" + DB_pass + ";database=" + DB_name;
    }
    
    public static Position getFirstPosition()
    {
        return new Position(firstSpawn_x, firstSpawn_y, firstSpawn_z);
    }

}
