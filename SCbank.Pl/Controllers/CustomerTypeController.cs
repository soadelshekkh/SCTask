using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SCbank.Core.Entities;
using SCbank.Core.Repositories;
using SCbank.Core.Specifications;
using SCbank.Pl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCbank.Pl.Controllers
{
    public class CustomerTypeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public CustomerTypeController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var Types = await unitOfWork.Repositary<CustomerType>().GetAll();
            var mappedType = mapper.Map<IEnumerable<CustomerType>, IEnumerable<CustomerTypeViewModel>>(Types);
            return View(mappedType);
        }

        public async Task<IActionResult> Details(int? id, string ViewName = "Details")
        {
            if (id == null)
                return NotFound();
            var customertype = await unitOfWork.Repositary<CustomerType>().GetById(id);
            if (customertype == null)
                return NotFound();
            var Mappedtype = mapper.Map<CustomerType, CustomerTypeViewModel>(customertype);
            return View(ViewName, Mappedtype);
        }
        public async Task<IActionResult> Update(int? id)
        {
            return await Details(id, "Update");
        }
        [HttpPost]
        public IActionResult Update([FromRoute] int id, CustomerTypeViewModel type)
        {
            if (id != type.Id)
                return BadRequest();
            var MappedType = mapper.Map<CustomerTypeViewModel, CustomerType>(type);
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.Repositary<CustomerType>().update(MappedType);
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(type.Id);
        }
        [HttpPost]
        public IActionResult Delete(CustomerTypeViewModel type)
        {
           
            var Mappedtype = mapper.Map<CustomerTypeViewModel, CustomerType>(type);
            try
            {
                unitOfWork.Repositary<CustomerType>().delete(Mappedtype);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                return View(type);
            }

        }
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerTypeViewModel type)
        {
            if (ModelState.IsValid)
            {
                var Mappedtype= mapper.Map<CustomerTypeViewModel, CustomerType>(type);
                await unitOfWork.Repositary<CustomerType>().Create(Mappedtype);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Errors = ModelState.Values.Where(v => v.Errors.Count > 0);
                return View(type);
            }

        }
    }
}
