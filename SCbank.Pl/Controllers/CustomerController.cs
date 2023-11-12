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
using System.Xml.Linq;

namespace SCbank.Pl.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public CustomerController(  IMapper mapper,IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index([FromForm]CustomerFilterParams Prams)
        {
            // give filterPrams to CustomerSpectification to give includes and whereCondition its value
            var spec = new CustomerSpectification(Prams);
            //GetAllSpec function in genericRepository class in repository project get all customers with types and apply filter 
            //by buildQuery function
            var customers = await unitOfWork.Repositary<Customer>().GetAllSpec(spec);
            var mappedCustomer = mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);
            // get all customer types and send it to view using ViewBag
            ViewBag.Types = await unitOfWork.Repositary<CustomerType>().GetAll();
            return View(mappedCustomer);
        }

        //Details like Update and delete action so can use  Details for get Details, Update and delete by using string ViewName
        // get Details for customers
        public async Task<IActionResult> Details(int? id, string ViewName = "Details")
        {
            if (id == null)
                return NotFound();
            var spec = new CustomerSpectification(id);
            //GetByIdspec function in genericRepository class in repository project get customer by id include customer's type
            var customer = await unitOfWork.Repositary<Customer>().GetByIdspec(spec);
            if (customer == null)
                return NotFound();
            var MappedCustomer = mapper.Map<Customer, CustomerViewModel>(customer);
            return View(ViewName, MappedCustomer);
        }
        //get details for customer then return update view

        public async Task<IActionResult> Update(int? id)
        {
            // get all customer types
            ViewBag.Types = await unitOfWork.Repositary<CustomerType>().GetAll();
            return await Details(id, "Update");
        }
        // get the updates from view and update customer in database
        [HttpPost]
        public IActionResult Update([FromRoute] int id, CustomerViewModel customer)
        {
            if (id != customer.Id)
                return BadRequest();
            var MappedCustomer = mapper.Map<CustomerViewModel, Customer>(customer);
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.Repositary<Customer>().update(MappedCustomer);
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(customer.Id);
        }
        //get customer from view to delete this customer in database
        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int? Id,CustomerViewModel customer)
        {
            var spec = new CustomerSpectification(Id);
            // why delete TrueCustomerData Not customer because if user try to change TypeId value of Customer Id 
            // I will gain unwanted results So i make sure From data by get it from database by using True id from route then delete
            var TrueCustomerData = await unitOfWork.Repositary<Customer>().GetByIdspec(spec);
            //var MappedCustomer = mapper.Map<CustomerViewModel, Customer>(customer);
            try
            {
                unitOfWork.Repositary<Customer>().delete(TrueCustomerData);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                return View(customer);
            }

        }
        // get Details for customer and return to delete view
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Types = await unitOfWork.Repositary<CustomerType>().GetAll();
            return View();
        }
        //create a new  customer in database
        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel customer)
        {
            customer.Id = 0;
            if (ModelState.IsValid)
            { 
                var Mappedcustomer = mapper.Map<CustomerViewModel, Customer>(customer);
                Mappedcustomer.TimeOfCreation = DateTime.Now;
                await unitOfWork.Repositary<Customer>().Create(Mappedcustomer);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Types = await unitOfWork.Repositary<CustomerType>().GetAll();
                ViewBag.Errors = ModelState.Values.Where(v => v.Errors.Count > 0);
                return View(customer);
            }

        }

    }
}
