using BulkyBook.DataAcces.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class CategoryRepositry : Repository<Category>, ICategoryRepositry
    {
        private ApplicationDbContext _db;
        public CategoryRepositry(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }       

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
