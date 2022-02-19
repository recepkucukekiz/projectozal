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
    [Authorize(Roles ="Admin")]
    public class RepairsController : Controller
    {
        private IRepairService _repairService; //injection
        private IStatusRepository _statusRepository;

        public RepairsController(IRepairService repairService, IStatusRepository statusRepository) //constructer for injection
        {
            this._repairService = repairService;
            this._statusRepository = statusRepository;
        }

        // GET: Repairs
        public IActionResult Index()
        {
            ViewBag.Status = this.GetStatus();
            return View(_repairService.GetAll());
        }

        // GET: Repairs/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = _repairService.GetById((int)id);
            if (repair == null)
            {
                return NotFound();
            }
            ViewBag.Status = this.GetStatus();
            return View(repair);
        }

        // GET: Repairs/Create
        [Authorize(Roles="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Repairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Admin")]
        public IActionResult Create([Bind("Id,DeviceName,Price,Description,Date,RepairStatue")] Repair repair)
        {
            repair.RepairNum = new Random().Next(100000,999999);
            if (ModelState.IsValid)
            {
                repair.RepairStatue = 0;
                _repairService.Create(repair);
                return RedirectToAction(nameof(Index));
            }
            return View(repair);
        }

        // GET: Repairs/Edit/5
        [Authorize(Roles="Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = _repairService.GetById((int)id);
            if (repair == null)
            {
                return NotFound();
            }
            ViewBag.Status = this.GetStatus();
            return View(repair);
        }

        // POST: Repairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Admin")]
        public IActionResult Edit(int id, [Bind("Id,DeviceName,Price,Description,Date,RepairNum,RepairStatue")] Repair repair)
        {
            if (id != repair.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repairService.Update(repair);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Status = this.GetStatus();
            return View(repair);
        }

        // GET: Repairs/Delete/5
        [Authorize(Roles="Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = _repairService.GetById((int)id);
            if (repair == null)
            {
                return NotFound();
            }

            return View(repair);
        }

        // POST: Repairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repairService.Delete(_repairService.GetById((int)id));
            return RedirectToAction(nameof(Index));
        }

        private List<string> GetStatus()
        {
            var temp = new List<string>();
            foreach (var item in _statusRepository.GetAll())
            {
                temp.Add(item.Name);
            }
            return temp;
        }
    }
}
