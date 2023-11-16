using Hotels.Data;
using Hotels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;



namespace Hotels.Controllers
{
	public class DashboardController : Controller
	{
		// Example Thu W3 Start
		private readonly ApplicationDbContext _context;

		public DashboardController(ApplicationDbContext context)
		{
			_context = context;

		}
		// Example Thu W3 end

		// Example Thu W3 Start
		public IActionResult CreateNewHotel(Hotel hotels)
		{
			// Example Mon W4 Start
			if (ModelState.IsValid)
			{
				_context.hotel.Add(hotels);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			var hotel = _context.hotel.ToList();
			return View("Index", hotel);
			//Example Mon W4 End
		}
		// Example Thu W3 End

		//xcnxzbcbhxqagdiz
		[Authorize]
		public IActionResult Index()
		{
			var currentuser = HttpContext.User.Identity.Name;
			ViewBag.CurrentUser = currentuser;
			//CookieOptions option = new CookieOptions();
			//option.Expires = DateTime.New.AddMinutes(20);
			//Response.Cookies.Append("UserName", currentuser, option);
			HttpContext.Session.SetString("UserName", currentuser);
			// Example Thu W3 Start
			var hotel = _context.hotel.ToList();
			return View(hotel);
			// Example Thu W3 end
		}

		// Example Thu W3 Start
		public IActionResult Delete(int Id)
		{
			var hotelDel = _context.hotel.SingleOrDefault(x => x.Id == Id);
			if (hotelDel != null)
			{
				_context.hotel.Remove(hotelDel);
				_context.SaveChanges();
				TempData["Del"] = "Ok";
			}
			return RedirectToAction("Index");
		}
		// Example Thu W3 end

		////////////////////////////////////////////////////////
		public IActionResult EditRooms(int Id)
		{
			var hotel = _context.hotel.ToList();
			ViewBag.hotel = hotel;
			var rooms = _context.rooms.ToList();
			ViewBag.rooms = rooms;
			var Roomedit = _context.rooms.SingleOrDefault(x => x.Id == Id);
			return View(Roomedit);
		}
		public IActionResult UpdateRooms(Rooms rooms)
		{
			_context.rooms.Update(rooms);
			_context.SaveChanges();
			return RedirectToAction("Rooms");
		}

		//

		public IActionResult EditRoomDetails(int Id)
		{
			var hotel = _context.hotel.ToList();
			ViewBag.hotel = hotel;
			var rooms = _context.rooms.ToList();
			ViewBag.rooms = rooms;
			var RoomDetailsedit = _context.roomDetails.SingleOrDefault(x => x.Id == Id);
			return View(RoomDetailsedit);
		}
		public IActionResult UpdateRoomDetails(RoomDetails roomDetails)
		{
			_context.roomDetails.Update(roomDetails);
			_context.SaveChanges();
			return RedirectToAction("RoomDetails");
		}
		//////////////////////////////////////////////////
		
		// Example Assignment W4 Start
		public IActionResult Edit(int Id)
		{
			var hoteledit = _context.hotel.SingleOrDefault(x => x.Id == Id);
			return View(hoteledit);
		}
		public IActionResult Update(Hotel hotel)
		{
			if (ModelState.IsValid)
			{
				_context.hotel.Update(hotel);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Edit");
		}
		//Example Assignment W4 End

		// Example Sun W4 Start
		[HttpPost]
		public async Task<IActionResult> Index(string City)
		{
			var hotel = _context.hotel.Where(x => x.City.Equals(City));
			return View(hotel);
		}
		//Example Sun W4 End

		// Example Sun% mon W4 Start
		public IActionResult Rooms()
		{
			var hotel = _context.hotel.ToList();
			ViewBag.hotel = hotel;
			//ViewBag.CurrentUser = Request.Cookies["UserName"];
			ViewBag.CurrentUser = HttpContext.Session.GetString("UserName");
			var rooms = _context.rooms.ToList();
			return View(rooms);
		}
		public IActionResult CreateNewRooms(Rooms rooms)
		{
			_context.rooms.Add(rooms);
			_context.SaveChanges();
			return RedirectToAction("Rooms");
		}
		//Example Sun W4 End

		//Example Mon W4 Start
		public async Task<IActionResult> RoomDetails()
		{
			var hotel = _context.hotel.ToList();
			ViewBag.hotel = hotel;
			var rooms = _context.rooms.ToList();
			ViewBag.rooms = rooms;
			var roomDetails = _context.roomDetails.ToList();
			return View(roomDetails);
		}
		public IActionResult CreateNewRoomDetails(RoomDetails roomDetails)
		{
			_context.roomDetails.Add(roomDetails);
			_context.SaveChanges();
			return RedirectToAction("roomDetails");
		}
        //Example Mon W4 End

        // Example W4 Wed Start
        public async Task<string> SendEmail()
		{
			var Message = new MimeMessage();
			Message.From.Add(new MailboxAddress("Test Message", "sahagd765@gmail.com"));
			Message.To.Add(MailboxAddress.Parse("sshahd765@gmail.com"));
			Message.Subject="Test Email From My Project In Asp.net Core MVC";
			Message.Body = new TextPart("Plaint")
			{
			 Text= "Welcome In My App"
			};

            using(var client=new SmtpClient())
            {
				try
				{
					client.Connect("smtp.gmail.com", 587); 
					client.Authenticate("sahagd765@gmail.com", "xcnxzbcbhxqagdiz");
					await client.SendAsync(Message);
					client.Disconnect(true);
				}
				catch(Exception e) 
				{ 
					return e.Message.ToString();
				}
            }
            return "Ok";
		}
        //Example W4 Wed End
    }
}
