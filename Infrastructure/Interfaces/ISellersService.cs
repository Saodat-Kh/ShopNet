using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface ISellersService
{
    List<Sellers> GetAllSellers();
    Sellers GetSellerById(int id);
    bool CreateSeller(Sellers seller);
    bool UpdateSeller(Sellers seller);
    bool DeleteSeller(int id);
}