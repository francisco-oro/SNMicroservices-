using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid id) : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product Product);

public class GetProductByIdHandler
{
    
}