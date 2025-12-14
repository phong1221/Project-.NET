using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Data.Repositories;
using StoreManagement.Data.Entities;
using StoreManagement.Web.Helpers;

namespace StoreManagement.Web.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IRepository<Payment> _repository;

        public PaymentsController(IRepository<Payment> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            var payments = await _repository.Query()
                .Include(p => p.Order)
                .ThenInclude(o => o.Customer)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
            
            int pageSize = 10;
            return View(PaginatedList<Payment>.Create(payments, pageNumber ?? 1, pageSize));
        }
    }
}
