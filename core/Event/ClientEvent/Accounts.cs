using System.Data;
using AltV.Net;
using gamemode.Player;

namespace gamemode.core.Event.ClientEvent;

public class Accounts
{
    [ClientEvent("account:login")]
    public void Login(MyPlayer myPlayer, string email, string password)
    {
        
    }

    [ClientEvent("account:register")]
    public void Create(MyPlayer player, string email, string password)
    {
        Player.Accounts newAccount = new Player.Accounts(email, password, 0);
        if (newAccount.Create())
        {
            player.Create();
            player.AccountId = newAccount.Id;
        }
    }
}