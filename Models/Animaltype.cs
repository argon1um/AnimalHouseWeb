using System;
using System.Collections.Generic;

namespace AnimalHouseRestAPI.Models;

public partial class Animaltype
{
    public int AnimaltypeId { get; set; }

    public string? AnimaltypeName { get; set; }

    public virtual ICollection<Animalbreed> Animalbreeds { get; set; } = new List<Animalbreed>();
}
