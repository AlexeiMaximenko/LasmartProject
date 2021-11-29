using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebDotPainter.Database;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebDotPainter.Entity;

namespace WebDotPainter.Controllers
{
    public class DataController : Controller
    {

        private readonly AppDbContext _db;

        public DataController(AppDbContext context)
        {
            _db = context;
        }
        [HttpGet]
        public IActionResult GetDots()
        {
            return Json(_db.Circle.Include(c => c.Comments).ToList());
        }
        [HttpPost]
        public IActionResult DeleteDot()
        {
            if (!Request.HasFormContentType)
            {
                return Json("Wrong");
            }
            var req = Request.Form.Keys; 
            var circleList = new List<Circle>();
            foreach(var item in req)
            {
                var circle = JsonConvert.DeserializeObject<Circle>(item);
                circleList.Add(circle);
            } 
            try
            {
                foreach(var circle in circleList)
                {
                _db.Circle.Remove(circle);
                _db.SaveChanges();
                }
                return Json(_db.Circle.Include(c => c.Comments).ToList());
            }
            catch(Exception e)
            {
                return Json($"{e.Message}");
            }

        }
    }
}
