using System;
using System.Collections.Generic;

namespace AnimalHouseRestAPI.Models;

public partial class Roomstatus
{
    public int RoomstatusId { get; set; }

    public string? RoomstatusName { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
