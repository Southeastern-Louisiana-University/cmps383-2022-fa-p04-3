using FA22.P04.Web.Features.Items;
using FA22.P04.Web.Features.Listings;
namespace FA22.P04.Web.Features.Products;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    public virtual ICollection<Listing> Listing { get; set; } = new List<Listing>();
}
