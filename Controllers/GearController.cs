﻿using System.Linq;
using System;
using GearOptimizer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GearOptimizer.Controllers
{
    public class GearController : Controller
    {
        private IHostingEnvironment _environment;
        private readonly GearOptimizerDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public GearController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, GearOptimizerDbContext db, IHostingEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _environment = environment;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_db.Gears.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Gear newGear)
        {
            _db.Gears.Add(newGear);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Gear thisGear = _db.Gears.FirstOrDefault(gear => gear.Id == id);
            return View(thisGear);
        }
        [HttpPost]
        public IActionResult Edit(Gear editedGear)
        {
            _db.Entry(editedGear).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var deleteGear = _db.Gears.FirstOrDefault(gear => gear.Id == id);
            return View(deleteGear);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var deleteGear = _db.Gears.FirstOrDefault(gear => gear.Id == id);
            _db.Gears.Remove(deleteGear);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var gearDetails = _db.Gears.FirstOrDefault(gear => gear.Id == id); ;
            return View(gearDetails);
        }
    }
}
