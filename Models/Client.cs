using System;
using System.Collections.Generic;

namespace AnimalHouseRestAPI.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string ClientName { get; set; } = null!;

    public string ClientLogin { get; set; } = null!;

    public string ClientPassword { get; set; } = null!;

    public decimal ClientPhone { get; set; }

    public string? ClientEmail { get; set; }

    public string? ClientImage { get; set; }

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
