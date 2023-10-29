namespace Rastvors.Common.Entities;

public partial class Structure
{
    public int Id { get; set; }

    public int RastvorId { get; set; }

    public int ComponentId { get; set; }

    public double Value { get; set; }

    public virtual Component Component { get; set; } = null!;

    public virtual Rastvor Rastvor { get; set; } = null!;
}
