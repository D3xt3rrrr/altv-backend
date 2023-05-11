using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using gamemode.core.Database;
using gamemode.Player;
using Npgsql;

namespace gamemode.core.System.Command;

public class BanCmd : IScript
{
    [AltV.Net.Resources.Chat.Api.Command("veh")]
    public static void Ban(MyPlayer player, string id)
    {
        // TODO : valider level admin 4
        // TODO : trouver joueur avec id et ban + quit game
        

        List<Accounts> accountList = Postgresql.FetchAll<Accounts>("SELECT * from player where id=@id",
            new NpgsqlParameter[]
            {
                new NpgsqlParameter("@id", player.AccountId)
            });
        
        // Ajouter function is admin
        if (accountList.Count == 1)
            if(accountList[0].admin_level == 4)
                
                
        
        if (id != null)
        {
            player.SendChatMessage("Player ban : " + id);
        }
    }
    
}