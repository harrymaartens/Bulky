using BulkyBook.DataAcces.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepositry : Repository<Product>, IProductRepositry
    {
        private ApplicationDbContext _db;
        public ProductRepositry(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        // Explicit Update, hier geef je aan welke velden geupdate worden. Omdat dit betrekking heeft 
        // op een individuele repositry namelijk Product entity en NIET in de generieke repositry.
        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Author = obj.Author;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }

        // Algemene Update, deze werkt ook goed
        //public void Update(Product obj)
        //{
        //    _db.Products.Update(obj);
        //}
    }
}
