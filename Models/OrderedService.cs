using System;
using System.Collections.Generic;

namespace AnimalHouseRestAPI.Models;

public partial class OrderedService
{
    public int OrderedserviceId { get; set; }

    public DateOnly? OrderedserviceDate { get; set; }

    public int ServiceId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Service Service { get; set; } = null!;
}
