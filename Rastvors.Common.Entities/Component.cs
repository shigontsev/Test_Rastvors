namespace Rastvors.Common.Entities;

public partial class Component
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Structure> Structures { get; set; } = new List<Structure>();
}
