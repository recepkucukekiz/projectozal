#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ozal.business.Abstract;
using ozal.data.Abstract;
using ozal.data.Concrete.EfCore;
using ozal.entity;

namespace ozal.webui.Controllers
{
    public class CaresController : Controller
    {
        private ICareService _careService; //injection
        public CaresController(ICareService careService) //constructer for injection
        {
            this._careService = careService;
        }

        // GET: Cares
        public IActionResult Index()
        {
            return View(_careService.GetAll());
        }

        [HttpGet]
        public IActionResult Search(string q)
        {
            if (q == null)
            {
               return View(_careService.GetAll());
            }

            var ret = _careService.GetSearchResult(q);

            return View(ret);
        }

        // GET: Cares/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _careService.GetById((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Cares/Create
        [Authorize(Roles="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Admin")]
        public IActionResult Create([Bind("Id,Name,Price,Imageurl,Ishome,Description")] Care care)
        {
            if (ModelState.IsValid)
            {
                _careService.Create(care);
                return RedirectToAction(nameof(Index));
            }
            return View(care);
        }

        // GET: Cares/Edit/5
        [Authorize(Roles="Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var care = _careService.GetById((int)id);
            if (care == null)
            {
                return NotFound();
            }
            return View(care);
        }

        // POST: Cares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Admin")]
        public IActionResult Edit(int id, [Bind("Id,Name,Price,Imageurl,Ishome,Description")] Care care)
        {
            if (id != care.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _careService.Update(care);
                return RedirectToAction(nameof(Index));
            }
            return View(care);
        }

        // GET: Cares/Delete/5
        [Authorize(Roles="Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var care = _careService.GetById((int)id);
            if (care == null)
            {
                return NotFound();
            }

            return View(care);
        }

        // POST: Cares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            _careService.Delete(_careService.GetById(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
