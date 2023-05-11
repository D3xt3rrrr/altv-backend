using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Enums;
using gamemode.Player;

namespace gamemode.core.Entity.Player;

public class Connect : IScript
{

    [ScriptEvent(ScriptEventType.PlayerConnect)]
    public static void OnPlayerConnect(MyPlayer player, string reason)
    {
        Console.WriteLine("ensjdfjkfdakjasiufaauhfdkhj");
        player.Model = (uint)PedModel.FreemodeMale01;
        player.Spawn(new Position(0, 0, 75), 0);
    }
}