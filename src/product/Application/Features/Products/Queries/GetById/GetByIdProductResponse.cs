using Core.Application.Responses;

namespace Application.Features.Products.Queries.GetById;

public class GetByIdProductResponse : IResponse
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public String Description { get; set; }
    public double Amount { get; set; }
    public String CategoryId { get; set; }
}