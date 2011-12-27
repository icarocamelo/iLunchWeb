using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iLunch.Dominio;

namespace iLunchWeb.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Pedido/

        public ActionResult Index()
        {
            List<Order> lst = new List<Order>();
            Order p = new Order() {Id = 1, Description = "Teste 1" };
            Order p1 = new Order() { Id = 2, Description = "Teste 2" };
            Order p2 = new Order() { Id = 3, Description = "Teste 3" };

            lst.Add(p);
            lst.Add(p1);
            lst.Add(p2);

            return View(lst);
        }

    }
}
