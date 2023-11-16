//using Hotels.Data;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace Hotels.Controllers
//{
//    public class ShoppingController1 : Controller
//    { 
//    private readonly ApplicationDbContext _context;

//    public ShoppingController1(ApplicationDbContext context)
//    {
//        _context = context;

//    }
        
    
//        public IActionResult Index()
//        {
//        var hotel = _context.hotel.ToList();
//            return View(hotel);
//        }
//        public IActionResult Rooms(int Id)
//        { 
//          var rooms= _context.rooms.Where(p=>p.IdHotel==Id).ToList();
//        }
//    }
//}
