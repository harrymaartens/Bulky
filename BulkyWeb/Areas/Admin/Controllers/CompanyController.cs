using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            
            return View(objCompanyList);
        }


        // Upsert is een combinatie van UpdateInsert
        public IActionResult Upsert(int? id)
        {            
            if (id == null || id == 0)
            {
                // Create
                return View(new Company());
            }
            else
            {
                // Update we gebruiken Get i.p.v. GetAll omdat het om 1 Company gaat.
                Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
                return View(companyObj);
            }            
        }

        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {           
            if (ModelState.IsValid)
            {
                if (CompanyObj.Id == 0) 
                {
                    _unitOfWork.Company.Add(CompanyObj);
                }
                else 
                {
                    _unitOfWork.Company.Update(CompanyObj);
                }
                                
                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }
            else
            {                
                return View(CompanyObj);
            }            
        }       

        [HttpPost]
        public IActionResult Edit(Company obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Company.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Company updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }


		[HttpDelete]
		public IActionResult Delete(int? id)
		{
			var CompanyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);

			if (CompanyToBeDeleted == null)
			{
				return Json(new { success = false, message = "Error while deleting" });
			}
			
			_unitOfWork.Company.Remove(CompanyToBeDeleted);
			_unitOfWork.Save();

			return Json(new { success = true, message = "Delete Successful" });
		}

		#endregion
	}
}
