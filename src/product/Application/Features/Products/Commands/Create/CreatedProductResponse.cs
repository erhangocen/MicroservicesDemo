using Core.Application.Responses;

namespace Application.Features.Products.Commands.Create;

public class CreatedProductResponse : IResponse
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public String Description { get; set; }
    public double Amount { get; set; }
    public String CategoryId { get; set; }
}