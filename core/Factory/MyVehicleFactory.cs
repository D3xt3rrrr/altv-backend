using AltV.Net;
using AltV.Net.Elements.Entities;
using gamemode.core.Entity.Vehicle;

namespace gamemode.Player;

public class MyVehicleFactory : IEntityFactory<IVehicle>
{
    public IVehicle Create(ICore core, IntPtr playerPointer, ushort id)
    {
        return new MyVehicle(core, playerPointer, id);
    } 
}