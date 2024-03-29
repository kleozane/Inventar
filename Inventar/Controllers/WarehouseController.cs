﻿using Inventar.Data;
using Inventar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventar.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly InventarContext _context;
        public WarehouseController(InventarContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var warehouses = await _context.Warehouses.ToListAsync();
            return View(warehouses);
        }

        // GET: WarehouseController/Create
        public async Task<IActionResult> Create()
        {
            var model = new WarehouseForCreation();
            return View(model);
        }

        // POST: WarehouseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WarehouseForCreation model)
        {
            var warehouse = new Warehouse
            {
                Name = model.Name,
                Description = model.Description
            };

            await _context.Warehouses.AddAsync(warehouse);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: WarehouseController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var warehouse = await _context.Warehouses.Where(w => w.Id == id).FirstOrDefaultAsync();
            var model = new WarehouseForModification();

            model.Id = warehouse.Id;
            model.Name = warehouse.Name;
            model.Description = warehouse.Description;

            return View(model);
        }

        // POST: WarehouseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WarehouseForModification model)
        {
            var warehouse = new Warehouse
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            _context.Warehouses.Update(warehouse);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var warehouse = await _context.Warehouses.FirstOrDefaultAsync(x => x.Id == id);

            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
