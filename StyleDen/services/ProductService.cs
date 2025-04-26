
public class ProductService : IProductService
{
    public IReadOnlyCollection<Product> GetAllProducts()
    {
        return  new List<Product>(){
            new Product{ID = 1, Name="Shirt", Price=10},
            new Product{ID = 2, Name="Shorts", Price=25},
            new Product{ID = 3, Name="Socks", Price=5},
        };
    }
}