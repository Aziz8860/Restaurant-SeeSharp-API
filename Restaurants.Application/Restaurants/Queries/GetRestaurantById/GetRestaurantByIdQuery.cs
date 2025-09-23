using MediatR;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQuery : IRequest<RestaurantDto?>
{
    // dengan pattern ini jadi bisa gini
    // var query = new GetRestaurantByIdQuery(5); // ✅ safe and clear
    public GetRestaurantByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; }
    

}
