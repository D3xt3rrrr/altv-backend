using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace gamemode.core.Entity.Vehicle;
public class MyVehicle : AltV.Net.Elements.Entities.Vehicle
{
    public int MyData { get; set; }

    // This constructor is used for creation via constructor
    public MyVehicle(ICore core, uint model, Position position, Rotation rotation) : base(core, model, position, rotation)
    {
        MyData = 7;
    }

    // This constructor is used for creation via entity factory
    public MyVehicle(ICore core, IntPtr nativePointer, ushort id) : base(core, nativePointer, id)
    {
        MyData = 6;
    }
}