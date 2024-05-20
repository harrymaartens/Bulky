using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface ICompanyRepositry : IRepository<Company>
    {
        void Update(Company obj);        
    }
}
