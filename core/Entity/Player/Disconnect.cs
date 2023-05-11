using System;
using AltV.Net;
using AltV.Net.Elements.Entities;
using gamemode.Database;
using gamemode.Player;

namespace gamemode.Database;


public class Disconnect : IScript
{
    [ScriptEvent(ScriptEventType.PlayerDisconnect)]
    public static void PlayerDisconect(MyPlayer player, string reason)
    { 
      //  Console.WriteLine(player.Position.X);
       // SavePlayer.Save(player);
    } 
}