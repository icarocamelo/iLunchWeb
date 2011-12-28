using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iLunch.Dominio;
using iLunch.Repository.Interfaces;

namespace iLunchWeb.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;
        private ICollection<Order> _orders = null; 

        public OrderController(IOrderRepository orderRepository)
        {
            _repository = orderRepository;
        }

        //
        // GET: /Pedido/

        public ActionResult Index()
        {
            using (_repository)
            {
                _orders = GetLista(); //_repository.GetAll();
            }

            return View(_orders);
        }

        private ICollection<Order> GetLista()
        {
            var meals = new List<Meal>();
            var meal1 = new Meal() { Id = 1, Description = "Arroz com Carne"};
            var meal2 = new Meal() { Id = 2, Description = "Arroz com Carne" };
            var meal3 = new Meal() { Id = 3, Description = "Arroz com Carne" };
            
            meals.Add(meal1);
            meals.Add(meal2);
            meals.Add(meal3);

            _orders = new List<Order>(); //_repository.GetInterval(0, 10);    
            _orders.Add(new Order() {Id = 1, Description = "Teste 1", Price = 5, Meals = meals});
            _orders.Add(new Order() { Id = 2, Description = "Teste 2", Price = 10, Meals = meals });
            _orders.Add(new Order() { Id = 3, Description = "Teste 3", Price = 15, Meals = meals });

            return _orders;
        }

        public ActionResult Details(int id)
        {
            Order order = null;

            using (_repository)
            {
                _orders = GetLista();
                order = _orders.Where(x => x.Id == id).SingleOrDefault(); //_repository.GetById(id);
            }

            return View(order);
        }

    }
}
