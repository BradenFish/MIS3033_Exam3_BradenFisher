using Microsoft.AspNetCore.Mvc;
using MIS3033_Exam3_BradenFisher.Data;
using MIS3033_Exam3_BradenFisher.Models;

namespace MIS3033_Exam3_BradenFisher.Controllers
{
    public class HomeController : Controller
    { 
        Exam3DB db = new Exam3DB();

        public JsonResult GetChartData()
        {
            var r = db.Orders.GroupBy(x => x.TipRatioLevel).Select(x => new { level = x.Key, n = x.Count()});
            return Json(r);
        }

        public JsonResult GetOrders()
        {
            return Json(db.Orders);
        }

        public JsonResult DeleteOrder(string id)
        {
            Message mes = new Message();
            Order order = db.Orders.Where(x => x.Id == id).FirstOrDefault();

            if (order == null) 
            {
                mes.status = "failed";
                mes.message = $"Order ID {id} is not in the database!!";
                return Json(mes);
            }

            db.Orders.Remove(order);
            db.SaveChanges();

            mes.status = "success";
            mes.message = "Order deleted successfully";
            return Json(mes);
        }

        public JsonResult EditOrder(string id, double subtotal, double tip)
        {
            Message mes = new Message();
            Order order = db.Orders.Where(x => x.Id == id).FirstOrDefault();

            if (order == null)
            {
                mes.status = "failed";
                mes.message = $"Order ID {id} is not in the database!!";
                return Json(mes);
            }

            order.Subtotal = subtotal;
            order.Tip = tip;

            order.CalTipRatio();
            order.CalTipRatioLevel();

            db.SaveChanges();

            mes.status = "success";
            mes.status = "Order edited successfully";
            return Json(mes);
        }

        public JsonResult AddOrder(string id, double subtotal, double tip)
        {
            Message mes = new Message();
            Order order = new Order();

            order.Id = id;
            order.Subtotal = subtotal;
            order.Tip = tip;

            order.CalTipRatio();
            order.CalTipRatioLevel();

            db.Orders.Add(order);
            db.SaveChanges();

            mes.status = "success";
            mes.message = "New Order added successfully";
            return Json(mes);
        }

        public IActionResult Chart()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
