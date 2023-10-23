using System;
using System.Collections.Generic;

namespace AnimalHouseRestAPI.Models;

public partial class Roomtype
{
    public int RoomtypeId { get; set; }

    public string? RoomtypeName { get; set; }

    public string? RoomtypeDescription { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
