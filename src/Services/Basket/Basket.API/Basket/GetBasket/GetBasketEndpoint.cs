using Carter;

namespace Basket.API.Basket.GetBasket;

// public record GetBasketRequest(string UserName);

public record GetBasketResponse(ShoppingCart ShoppingCart);

public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        throw new NotImplementedException();
    }
}