using Sheet4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sheet4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        const double TAX = 0.15;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Class1 order)
        {
            double[] subPrice = new double [] {3.99, 4.99, 5.99,6.99,4.99};
            String subName = Enum.GetName(typeof(Class1.subTypes), order.Subs);
            var typeprice = subPrice[(int)order.Subs];

            double[] sizePrice = new double[] { 3.99, 2.99, 1.99, 0.99 };
            String subSize = Enum.GetName(typeof(Class1.subSize), order.size);
            var sizeprice = sizePrice[(int)order.size];

            double[] subMealPrice = new double[] { 0.0, 2.50, 2.99 };
            String subMeal = Enum.GetName(typeof(Class1.mealType), order.Meal);
            var mealprice = subMealPrice[(int)order.Meal];

            double TypeNSizeTotal = Math.Round(typeprice * sizeprice,2);
            double subTotal = TypeNSizeTotal + mealprice;
            double tax = Math.Round(subTotal * TAX,2);
            double Total = Math.Round(tax + subTotal,2);

            ViewBag.subName = subName;
            ViewBag.subSize = subSize;
            ViewBag.subMeal = subMeal;
            ViewBag.typeprice = typeprice;
            ViewBag.sizeprice = sizeprice;
            ViewBag.mealprice = mealprice;
            ViewBag.TypeNSizeTotal = TypeNSizeTotal;
            ViewBag.subTotal = subTotal;
            ViewBag.tax = tax;
            ViewBag.Total = Total;

            return View("Receipt");


        }
    }
}