using InvocingApp.Data.Domains;
using InvoiceApp.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InvoicingApp.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyService _companyRepository;

        public CompanyController(ICompanyService companyRepository)
        {
            _companyRepository = companyRepository;
        }
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllCompany()
        {
            return View();
        }

        ///<Summary>
        ///Gets a list of Company
        ///</Summary>
        ///<Returns></Returns>
        [HttpGet]
        public JsonResult GetCompanies()
        {
            try
            {
                var allcompany = _companyRepository.GetAllCompany().Select(x => new
                {
                    x.Id,
                    x.CompanyName,
                    x.Address,
                    x.Customers,
                    x.Email,
                    x.Invoices,
                    x.PhoneNumber,
                    x.Products,
                });

                if (allcompany == null)
                {
                    return null;
                }
                return Json(allcompany, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet); 
            }
        }

        ///<Summary>
        ///Gets a Company Entity using the Id
        ///</Summary>
        ///<Param name="Id"></Param>
        ///<Returns></Returns>
        [HttpGet]
        public JsonResult GetCompanyById (long Id)
        {
            var companyresult = _companyRepository.GetCompanyById(Id);
            return Json(companyresult, JsonRequestBehavior.AllowGet);
        }
        ///<Summary>
        ///Add a new or edit a new company
        ///</Summary>
        ///<Param name="company"></Param>
        ///<Returns>string</Returns>
        [HttpPost]
        public JsonResult PostCompanyObject(Company company)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new HttpStatusCodeResult(HttpStatusCode.BadRequest), JsonRequestBehavior.AllowGet);
                _companyRepository.PostCompany(company);
                return Json(string.Format($"{company.CompanyName} has been created"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
        }
        ///<Summary>
        ///update company by entity
        ///</Summary>
        ///<Param name="company"></Param>
        ///<Returns></Returns>
        [HttpPut]
        public JsonResult UpdateCompanyObject(Company company)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new HttpStatusCodeResult(HttpStatusCode.BadRequest), JsonRequestBehavior.AllowGet);
                _companyRepository.UpdateCompanyObject(company);
                return Json(string.Format($"{company.CompanyName} has been updated"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
        }
        ///<Summary>
        ///update company by Id
        ///</Summary>
        ///<Param name="Id"></Param>
        ///<Returns></Returns>

        [HttpPut]
        public JsonResult UpdateCompanyById(long Id)
        {
            try
            {
                _companyRepository.UpdateCompanyById(Id);
                var entity = _companyRepository.GetCompanyById(Id);
                return Json(string.Format($"{entity.CompanyName} has been updated"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
        }
        ///<Summary>
        ///Delete company by Id
        ///</Summary>
        ///<Param name="Id"></Param>
        ///<Returns></Returns>
        [HttpDelete]
        public JsonResult RemoveCompanyById(long Id)
        {
            try
            {
                _companyRepository.RemoveCompanyById(Id);
                return Json(string.Format($"Company object has been deleted"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
           
        }

    }
}