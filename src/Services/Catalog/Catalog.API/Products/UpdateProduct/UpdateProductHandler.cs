using BuildingBlocks.CQRS;
using Catalog.API.Exceptions;
using Catalog.API.Models;
using Marten;

namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price)
    : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess); 
        
public class UpdateProductHandler
    (IDocumentSession session, ILogger<UpdateProductHandler> logger)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateProductHandler.Handle called with {@Command}", request);

        var product = await session.LoadAsync<Product>(request.Id, cancellationToken);

        if (product is null)
            throw new ProductNotFoundException();

        product.Name = request.Name;
        product.Categories = request.Category;
        product.Description = request.Description;
        product.ImageFile = request.ImageFile;
        product.Price = request.Price;
        
        session.Update(product);
        await session.SaveChangesAsync();

        return new UpdateProductResult(true);
    }
}