using System;
using System.Collections.Generic;

namespace AnimalHouseRestAPI.Models;

public partial class Animalbreed
{
    public int AnimalbreedId { get; set; }

    public int? AnimalTypeid { get; set; }

    public string? AnimalbreedName { get; set; }

    public virtual Animaltype? AnimalType { get; set; }

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
}
