using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface ICategoriesService
{
    List<Categories> GetAllCategories();
    Categories GetCategoriesById(int id);
    bool CreateCategories(Categories categories);
    bool UpdateCategories(Categories categories);
    bool DeleteCategories(int id);
}

 