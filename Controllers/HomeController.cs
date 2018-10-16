using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("FullCount") > 100
            && HttpContext.Session.GetInt32("EnergyCount") > 100
            && HttpContext.Session.GetInt32("HappyCount") > 100)
            {
                int? FullCount = HttpContext.Session.GetInt32("FullCount");
                ViewBag.FullCount = FullCount;
                int? HappyCount = HttpContext.Session.GetInt32("HappyCount");
                ViewBag.HappyCount = HappyCount;
                int? MealCount = HttpContext.Session.GetInt32("MealCount");
                ViewBag.MealCount = MealCount;
                int? EnergyCount = HttpContext.Session.GetInt32("EnergyCount");
                ViewBag.EnergyCount = EnergyCount;
                string image = "win.gif";
                HttpContext.Session.SetString("Image", image);
                string Image = HttpContext.Session.GetString("Image");
                ViewBag.Image = Image;
                TempData["message"] = "You win! So what now? ...";
            }
            else if (HttpContext.Session.GetInt32("FullCount") == 0
            || HttpContext.Session.GetInt32("HappyCount") == 0)
            {
                int? FullCount = HttpContext.Session.GetInt32("FullCount");
                ViewBag.FullCount = FullCount;
                int? HappyCount = HttpContext.Session.GetInt32("HappyCount");
                ViewBag.HappyCount = HappyCount;
                int? MealCount = HttpContext.Session.GetInt32("MealCount");
                ViewBag.MealCount = MealCount;
                int? EnergyCount = HttpContext.Session.GetInt32("EnergyCount");
                ViewBag.EnergyCount = EnergyCount;
                string image = "dead.gif";
                HttpContext.Session.SetString("Image", image);
                string Image = HttpContext.Session.GetString("Image");
                ViewBag.Image = Image;
                TempData["message"] = "RIP... time to find another victim";
            }
            if(HttpContext.Session.GetInt32("FullCount") == null)
            {
                HttpContext.Session.SetInt32("FullCount", 20);
                int? FullCount = HttpContext.Session.GetInt32("FullCount");
                ViewBag.FullCount = FullCount;
                HttpContext.Session.SetInt32("HappyCount", 20);
                int? HappyCount = HttpContext.Session.GetInt32("HappyCount");
                ViewBag.HappyCount = HappyCount;
                HttpContext.Session.SetInt32("MealCount", 3);
                int? MealCount = HttpContext.Session.GetInt32("MealCount");
                ViewBag.MealCount = MealCount;
                HttpContext.Session.SetInt32("EnergyCount", 50);
                int? EnergyCount = HttpContext.Session.GetInt32("EnergyCount");
                ViewBag.EnergyCount = EnergyCount;
                string image = "win.gif";
                HttpContext.Session.SetString("Image", image);
                string Image = HttpContext.Session.GetString("Image");
                ViewBag.Image = Image;
            }
            else {
                int? FullCount = HttpContext.Session.GetInt32("FullCount");
                ViewBag.FullCount = FullCount;
                int? HappyCount = HttpContext.Session.GetInt32("HappyCount");
                ViewBag.HappyCount = HappyCount;
                int? MealCount = HttpContext.Session.GetInt32("MealCount");
                ViewBag.MealCount = MealCount;
                int? EnergyCount = HttpContext.Session.GetInt32("EnergyCount");
                ViewBag.EnergyCount = EnergyCount;
                string Image = HttpContext.Session.GetString("Image");
                ViewBag.Image = Image;
            }
            return View("Index");
        }
        [HttpGet]
        [Route("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost("feed")]
        public IActionResult Feed()
        {
            Random rand = new Random();
            int? FullCount = HttpContext.Session.GetInt32("FullCount");
            int? MealCount = HttpContext.Session.GetInt32("MealCount");
            int Chance = rand.Next(1,5);

            if (MealCount <1){
                TempData["message"] = "No meals available. Get back to work!";
                string image = "cry.gif";
                HttpContext.Session.SetString("Image", image);
                string Image = HttpContext.Session.GetString("Image");
            }
            else if (Chance == 1){
                int mealcount = MealCount.GetValueOrDefault() -1;
                HttpContext.Session.SetInt32("MealCount", mealcount);
                TempData["message"] = "Noooooo...";
                string image = "no.gif";
                HttpContext.Session.SetString("Image", image);
                string Image = HttpContext.Session.GetString("Image");
            }
            else{
                int Feed = rand.Next(5,11);
                int fullcount = FullCount.GetValueOrDefault() +Feed;
                HttpContext.Session.SetInt32("FullCount", fullcount);
                int mealcount = MealCount.GetValueOrDefault() -1;
                HttpContext.Session.SetInt32("MealCount", mealcount);

                TempData["message"] = "Nom nom nom... Fullness +" + Feed + ", Meals -1";

                string image = "eat.gif";
                HttpContext.Session.SetString("Image", image);
                string Image = HttpContext.Session.GetString("Image");
            }
            return RedirectToAction("Index");
        }

        [HttpPost("play")]
        public IActionResult Play()
        {
            Random rand = new Random();
            int? HappyCount = HttpContext.Session.GetInt32("HappyCount");
            int? EnergyCount = HttpContext.Session.GetInt32("EnergyCount");
            int Chance = rand.Next(1,5);

            if (EnergyCount <5){
                TempData["message"] = "Insufficient energy to play. Time to sleep zZzZz";
                string image = "cry.gif";
                HttpContext.Session.SetString("Image", image);
                string Image = HttpContext.Session.GetString("Image");
            }
            else if (Chance == 1){
                int energycount = EnergyCount.GetValueOrDefault() -5;
                HttpContext.Session.SetInt32("EnergyCount", energycount);
                TempData["message"] = "Noooooo...";
                string image = "no.gif";
                HttpContext.Session.SetString("Image", image);
                string Image = HttpContext.Session.GetString("Image");
            }
            else{
                int Happy = rand.Next(5,11);
                int happycount = HappyCount.GetValueOrDefault() +Happy;
                HttpContext.Session.SetInt32("HappyCount", happycount);
                int energycount = EnergyCount.GetValueOrDefault() -5;
                HttpContext.Session.SetInt32("EnergyCount", energycount);

                TempData["message"] = "RAWR!!! Happiness +" + Happy + ", Energy -5";

                string image = "aggretsukoPlay.gif";
                HttpContext.Session.SetString("Image", image);
                string Image = HttpContext.Session.GetString("Image");
            }
            return RedirectToAction("Index");
        }

        [HttpPost("work")]
        public IActionResult Work()
        {
            Random rand = new Random();
            int? MealCount = HttpContext.Session.GetInt32("MealCount");
            int? EnergyCount = HttpContext.Session.GetInt32("EnergyCount");

            if (EnergyCount <5){
                TempData["message"] = "Insufficient energy to work. Time to sleep zZzZz";
                string image = "cry.gif";
                HttpContext.Session.SetString("Image", image);
                string Image = HttpContext.Session.GetString("Image");
            }
            else{
                int Meal = rand.Next(1,4);
                int mealcount = MealCount.GetValueOrDefault() +Meal;
                HttpContext.Session.SetInt32("MealCount", mealcount);
                int energycount = EnergyCount.GetValueOrDefault() -5;
                HttpContext.Session.SetInt32("EnergyCount", energycount);

                TempData["message"] = "Work work, more work? Meals +" + Meal + ", Energy -5";

                string image = "aggretsukoWork.gif";
                HttpContext.Session.SetString("Image", image);
                string Image = HttpContext.Session.GetString("Image");
            }
            return RedirectToAction("Index");
        }

        [HttpPost("sleep")]
        public IActionResult Sleep()
        {
            Random rand = new Random();
            int? FullCount = HttpContext.Session.GetInt32("FullCount");
            int? HappyCount = HttpContext.Session.GetInt32("HappyCount");
            int? EnergyCount = HttpContext.Session.GetInt32("EnergyCount");

            if (FullCount <5 || HappyCount <5){
                TempData["message"] = "Insufficient fullness or happiness to sleep. Time to eat or play";
                string image = "cry.gif";
                HttpContext.Session.SetString("Image", image);
                string Image = HttpContext.Session.GetString("Image");
            }
            else{
                int energycount = EnergyCount.GetValueOrDefault() +15;
                HttpContext.Session.SetInt32("EnergyCount", energycount);
                int fullcount = FullCount.GetValueOrDefault() -5;
                HttpContext.Session.SetInt32("FullCount", fullcount);
                int happycount = HappyCount.GetValueOrDefault() -5;
                HttpContext.Session.SetInt32("HappyCount", happycount);

                TempData["message"] = "zZzzZzzZz... Energy +15, Fullness -5, Happiness -5";

                string image = "aggretsukoSleep.gif";
                HttpContext.Session.SetString("Image", image);
                string Image = HttpContext.Session.GetString("Image");
            }
            return RedirectToAction("Index");
        }
    }
}
