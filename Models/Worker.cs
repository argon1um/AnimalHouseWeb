using System;
using System.Collections.Generic;

namespace AnimalHouseRestAPI.Models;

public partial class Worker
{
    public int WorkerId { get; set; }

    public string? WorkerName { get; set; }

    public int? WorkerPostid { get; set; }

    public string? WorkerLogin { get; set; }

    public string? WorkerPassword { get; set; }

    public decimal? WorkerPhone { get; set; }

    public string? WorkerEmail { get; set; }

    public string? WorkerImage { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Workerpost? WorkerPost { get; set; }
}
