using System;
using System.Collections.Generic;

namespace AnimalHouseRestAPI.Models;

public partial class Workerpost
{
    public int WorkerpostId { get; set; }

    public string? WorkerpostName { get; set; }

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
