using System;
using System.Collections.Generic;

namespace AnimalHouseRestAPI.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public int? RoomNumber { get; set; }

    public int? RoomTypeid { get; set; }

    public string? RoomImage { get; set; }

    public string? RoomDescription { get; set; }

    public int? RoomStatusid { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Roomstatus? RoomStatus { get; set; }

    public virtual Roomtype? RoomType { get; set; }
}
