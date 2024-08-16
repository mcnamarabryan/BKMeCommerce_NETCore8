using BKMeCommerce.DataAccess.Repository.IRepository;
using BKMeCommerce.Models;
using BKMeCommerce.Models.ViewModels;
using BKMeCommerce.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Collections.Generic;

namespace BKMeCommerceWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult Index()
        {
            List<Company> companyList = _unitOfWork.Company.GetAll().ToList();
            return View(companyList);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> categoryList = _unitOfWork.Category
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            CompanyViewModel companyVM = new CompanyViewModel
            {
                Company = new Company()
            };
            if (id == null || id == 0)
            {
                return View(companyVM);
            }
            else
            {
                companyVM.Company = _unitOfWork.Company.Get(u => u.Id == id);
                return View(companyVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(CompanyViewModel companyVM, IFormFile file)
        {
            ModelState.Remove("file");
            if (ModelState.IsValid)
            {
                if (companyVM.Company.Id == 0)
                {
                    _unitOfWork.Company.Add(companyVM.Company);
                }
                else
                {
                    _unitOfWork.Company.Update(companyVM.Company);
                }
                _unitOfWork.Save();
                return RedirectToAction("Index", "Company");
            }
            else
            {
                return View(companyVM);
            }
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> companyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = companyList });
        }

        public IActionResult Delete(int? id)
        {
            var companyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            if (companyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Company deleted" });
        }
        #endregion
    }
}
