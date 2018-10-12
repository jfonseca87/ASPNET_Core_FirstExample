using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebApp_ASPNETCore.Data;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp_ASPNETCore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookRepository _bookRepository;

        public CustomerController(ICustomerRepository customerRepository, IBookRepository bookRepository)
        {
            _customerRepository = customerRepository;
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            List<CustomerViewModel> lstCustomersVM = new List<CustomerViewModel>();

            IEnumerable<Customer> lstCustomers = _customerRepository.GetAll();

            if (!lstCustomers.Any())
            {
                return View("Empty");
            }

            foreach (var customer in lstCustomers)
            {
                lstCustomersVM.Add(
                    new CustomerViewModel
                    {
                        Customer = customer,
                        BookCount = _bookRepository.Count(x => x.BorrowedId == customer.CustomerId)
                    });
            }

            return View(lstCustomersVM);

        }

        public IActionResult Delete(int id)
        {
            Customer customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                ViewBag.Message = "Customer not found";
                return View();
            }

            _customerRepository.Delete(customer);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _customerRepository.Create(customer);

            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            Customer customer = _customerRepository.GetById(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            _customerRepository.Update(customer);

            return RedirectToAction("List");
        }
    }
}