using System;
using System.Collections.Generic;

namespace AnimalHouseRestAPI.Models;

public partial class Animal
{
    public int AnimalId { get; set; }

    public string? AnimalName { get; set; }

    public int? AnimalClientid { get; set; }

    public string? AnimalGen { get; set; }

    public int? AnimalBreedid { get; set; }

    public double? AnimalHeight { get; set; }

    public double? AnimalWeight { get; set; }

    public int? AnimalOld { get; set; }

    public virtual Animalbreed? AnimalBreed { get; set; }

    public virtual Client? AnimalClient { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
