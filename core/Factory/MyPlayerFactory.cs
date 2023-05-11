using System;
using AltV.Net;
using AltV.Net.Elements.Entities;

namespace gamemode.Player;

public class MyPlayerFactory : IEntityFactory<IPlayer>
{
    public IPlayer Create(ICore core, IntPtr playerPointer, ushort id)
    {
        return new MyPlayer(core, playerPointer, id);
    } 
}