using Core.Application.Dtos;

namespace Application.Features.Products.Queries.GetList;

public class GetListProductListItemDto : IDto
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public String Description { get; set; }
    public double Amount { get; set; }
    public String CategoryId { get; set; }
}