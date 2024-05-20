using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IProductRepositry : IRepository<Product>
    {
        void Update(Product obj);        
    }
}
