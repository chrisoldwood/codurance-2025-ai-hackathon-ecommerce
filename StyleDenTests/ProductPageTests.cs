namespace StyleDenTests;

using System.Collections.Generic;

using Bunit;
using Microsoft.Extensions.DependencyInjection;
using StyleDen.Components.Pages;

internal class fakeProductService : IProductService
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
public class ProductPageTests : TestContext
{
    [Fact]
    public void Products_page_contains_list_of_products()
    {

        Services.AddSingleton<IProductService>(new fakeProductService());

        var productPageComponent = RenderComponent<Home>();
        
        var productsTable = productPageComponent.Find("#products-table");

        Assert.Contains("Shirt", productsTable.InnerHtml);
    }
}
