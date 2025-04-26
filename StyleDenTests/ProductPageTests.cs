namespace StyleDenTests;

using System.Collections.Generic;
using AngleSharp.Html.Dom.Events;
using Bunit;
using Microsoft.AspNetCore.Components.Web;
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

        var productsPageComponent = RenderComponent<Home>();
        
        var productsTable = productsPageComponent.Find("#products-table");

        Assert.Contains("Shirt", productsTable.InnerHtml);
    }

    [Fact]
    public void Clicking_a_product_navigates_to_the_product_details_page()
    {
        Services.AddSingleton<IProductService>(new fakeProductService());

        var visiblePageComponent = RenderComponent<Home>();

        var product = visiblePageComponent.Find("#product-2");
        Assert.NotNull(product);

        product.ClickAsync(new MouseEventArgs());
        var productDetailsPage = visiblePageComponent.FindComponent<ProductDetails>();

        Assert.NotNull(productDetailsPage);
    }
}
