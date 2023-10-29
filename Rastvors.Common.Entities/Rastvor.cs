using System;
using System.Collections.Generic;

namespace Rastvors.Common.Entities;

public partial class Rastvor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Value { get; set; }

    public virtual ICollection<Structure> Structures { get; set; } = new List<Structure>();

    public bool IsCorrectStructure()
    {
        if (Structures == null || Structures.Count == 0)
        {  
            return false; 
        }
        if (Structures.FirstOrDefault(x => x.ComponentId == 1) == null) 
        {
            return false;
        }
        if(Structures.Sum(x=>x.Value) != 100)
        { 
            return false; 
        }

        return true;
    }
}
