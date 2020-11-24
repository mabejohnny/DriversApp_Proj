using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TruckDriverApp.Data;
using TruckDriverApp.Models;
using TruckDriverApp.ViewModels;

namespace TruckDriverApp.Controllers
{
    [Authorize(Roles = "Driver")]
    public class DriversController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public DriversController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Drivers
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var driver = _context.Drivers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (driver == null)
            {
                return RedirectToAction(nameof(Create));
            }

            driver = await _context.Drivers
            .Include(c => c.IdentityUser)
            .FirstOrDefaultAsync(m => m.Id == driver.Id);

            return View(driver);

        }

        // GET: Drivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers
                .Include(d => d.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // GET: Drivers/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,EmailAddress")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                driver.IdentityUserId = userId;

                _context.Add(driver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", driver.IdentityUserId);
            return View(driver);
        }

        // GET: Drivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", driver.VehicleId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", driver.IdentityUserId);
            return View(driver);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,EmailAddress,EntryTime,ExitTime,Notes,Rating,IdentityUserId,VehicleId,ProfileId")] Driver driver)
        {
            if (id != driver.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverExists(driver.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", driver.VehicleId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", driver.IdentityUserId);
            return View(driver);
        }

        // GET: Drivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers
                .Include(c => c.Vehicle)
                .Include(d => d.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.Id == id);
        }

        //public IActionResult ShowFacilityMap()
        //{
        //    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var driver = _context.Drivers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
        //    var facility = _context.Facilitys.Where(c => c.OwnerId == contractor.Id);
        //    var reservations = new List<Reservation>();
        //    foreach (var item in spots)
        //    {
        //        reservations.AddRange(_context.Reservations.Where(c => c.OwnedSpotID == item.ID).ToList());
        //    }
        //    return View(reservations);

        //}

        //GET: DriversController/AddVehicle/
        public ActionResult AddVehicle(int? id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Drivers.Where(c => c.IdentityUserId == userId).FirstOrDefault();


            if (customer == null)
            {
                return RedirectToAction("Create");
            }
            else
            {
                return View();
            }
        }

        //POST: DriversController/AddVehicle/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddVehicle([Bind("TruckMake,TruckModel,TruckYear, TruckColor, TruckLicensePlate, TruckNotes")] Vehicle vehicle)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var driver = _context.Drivers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            vehicle.VehicleId = driver.Id;
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        //GET: DriversController/ViewVehicles/
        public ActionResult ViewVehicles(int? id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var driver = _context.Drivers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (driver == null)
            {
                return NotFound();
            }
            var vehicles = _context.Vehicles.Where(c => c.VehicleId == driver.Id).SingleOrDefault();

            if (vehicles == null)
            {
                return NotFound();
            }
            return View(vehicles);

        }

        public ActionResult AllFacilitys()
        {

            var facility = _context.Facilitys;

            if (facility == null)
            {
                return NotFound();
            }

            return View(facility);
        }

        //GET: DriversController/SearchFacility/
        public ActionResult SearchFacility()
        {
            return View();

        }

        //POST: DriversController/SearchFacility/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchFacility(string zipCode)
        {
            
            var facility = _context.Facilitys.Where(c => c.ZipCode == zipCode).FirstOrDefault();

            return View(facility);
        }

        public IActionResult New()
        {
            return View();
        }

        public ActionResult ViewFacility(int? Id)
        {
            var facility = _context.Facilitys.Where(c => c.Id == Id).SingleOrDefault();
            //Enumerable.Repeat(Id, 1);
            return View(facility);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ViewFacility(int? Id)
        //{

        //    var facility = _context.Facilitys.Where(c => c.Id == Id).SingleOrDefault();

        //    return View(facility);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(ProfileViewModel model)
        {
            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var driver = _context.Drivers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Profile profile = new Profile
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    FullName = model.FirstName + " " + model.LastName,
                    Gender = model.Gender,
                    Age = model.Age,
                    AboutMe = model.AboutMe,
                    Position = model.Position,
                    ProfilePicture = uniqueFileName,
                };
                //profile.Id += driver.Id;
                _context.Add(profile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private string UploadedFile(ProfileViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public ActionResult ViewProfile()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var driver = _context.Drivers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (driver == null)
            {
                return NotFound();
            }
            var profiles = _context.Profiles.Where(c => c.Id == driver.Id);

            if (profiles == null)
            {
                return NotFound();
            }
            return View(profiles);

        }

        //[HttpPost]
        //public ActionResult PostRating(int rating, int mid)
        //{
        //    StarRating rt = new StarRating();
        //    rt.Rate = rating;
        //    rt.CustomerId = mid;

        //    _context.Ratings.Add(rt);
        //    _context.SaveChanges();

        //    return Ok();

        //}
    }
}
