using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using gamemode.core.Entity.Vehicle;
using gamemode.Player;

namespace gamemode.core.System.Command;

public class VehicleCmd : IScript
{
    [AltV.Net.Resources.Chat.Api.Command("veh")]
    public static void Spawn(MyPlayer player, string VehiculeName)
    {
        MyVehicle newVehicle = new MyVehicle(player.Core, Alt.Hash(VehiculeName),
            new Position(player.Position.X, player.Position.Y + 1.5f, player.Position.Z), player.Rotation);
        //modification use enum VehicleModType
        //newVehicle.SetMod(VehicleModType.WindowTint);
        //IVehicle veh = Alt.CreateVehicle(Alt.Hash(VehiculeName), new Position(player.Position.X, player.Position.Y + 1.5f, player.Position.Z), player.Rotation); 
        if (newVehicle != null)
        {
            player.SendChatMessage("New vehicle " + VehiculeName);
        }
    }
}