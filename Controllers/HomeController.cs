using Hotels.Data;
using Hotels.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO.Pipelines;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hotels.Controllers
{
    public class HomeController : Controller
    {
        // Example Mon W3 Start
        private readonly ApplicationDbContext _context;

         public HomeController(ApplicationDbContext context)
         {
            _context = context;
         }
        // Example Mon W3 End

        // Example Mon W3 Start
         public IActionResult CreateNewRecord(Hotel hotels)
         {

			// Example Mon W4 Start
			if (ModelState.IsValid)
            {
				_context.hotel.Add(hotels);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
            var hotel=_context.hotel.ToList();
            return View("Index", hotel);
			//Example Mon W4 End
		}
		// Example Mon W3 End     

		// Example Tue W3 Start
		//Delete
		public IActionResult Delete(int Id)
         {
            var hoteldelete = _context.hotel.SingleOrDefault(x=>x.Id==Id);//Search
            _context.hotel.Remove(hoteldelete); //Delete
            _context.SaveChanges();//save

            return RedirectToAction("Index");
         }
        //Edit

        public IActionResult Edit(int Id)
        {
            var hoteledit = _context.hotel.SingleOrDefault(x => x.Id == Id);
            return View(hoteledit);
        }
        //Update

         public IActionResult Update(Hotel hotel)
         {
            // Example Mon W4 Start
            if (ModelState.IsValid)
            {
                _context.hotel.Update(hotel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit");
            //Example Mon W4 End
        }
        // Example Tue W3 End



        //Assignment 3 Start
        [HttpPost]
		public IActionResult Index(string City)
		{
            var SearchCity= _context.hotel.Where(x => x.City.Contains(City));
            if (SearchCity == null) 
            {
				var hotel = _context.hotel.ToList();
				return View(hotel);
			}
			 else
            {
                var hotel=SearchCity.ToList();
				return View(hotel);
			}
		}

		public IActionResult Index()
        {
            // Example Tue W3 Start
               var hotel = _context.hotel.ToList();

               return View(hotel); //(hotel) = ارسلت الاوبجكت للكلاس
          // Example Tue W3 End
        }
        //Assignment 3 End

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}