using BulkyBook.DataAcces.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class CompanyRepositry : Repository<Company>, ICompanyRepositry
    {
        private ApplicationDbContext _db;
        public CompanyRepositry(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }       

        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }
    }
}
