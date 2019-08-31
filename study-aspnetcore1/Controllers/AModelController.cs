using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using study_aspnetcore1.Models;

namespace study_aspnetcore1.Controllers
{
    [Route("amodel")]
    public class AModelController : Controller
    {
        private DataContext Context { get; set; }

        public AModelController(DataContext context)
        {
            this.Context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult List()
        {
            var list = Context.AModels.ToList();
            return View(list);
        }

        [HttpGet]
        [Route("{id:long}")]
        public IActionResult Item(long id)
        {
            var item = Context.AModels.SingleOrDefault(m => m.ID == id);
            return View(item);
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            var item = new AModel();
            return View(item);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(AModel model)
        {
            var emptyModel = new AModel();

            if (await TryUpdateModelAsync<AModel>(
                emptyModel,
                "",
                m => m.A1, m => m.A2))
            {
                Context.AModels.Add(emptyModel);
                Context.SaveChanges();
                return RedirectToAction("List");
            }

            return null;
        }

        [HttpGet]
        [Route("{id:long}/edit")]
        public IActionResult Edit(long id) {
            var item = Context.AModels.SingleOrDefault(m => m.ID == id);
            return View(item);
        }

        [HttpPost]
        [Route("{id:long}/edit")]
        public async Task<IActionResult> Edit(AModel model)
        {
            var editModel = Context.AModels.SingleOrDefault(m => m.ID == model.ID);

            if (await TryUpdateModelAsync<AModel>(
                editModel,
                "",
                m => m.A1, m => m.A2))
            {
                // Context.AModels.Update(editModel);
                Context.SaveChanges();
                return RedirectToAction("List");
            }

            return null;
        }

        [HttpPost]
        [Route("{id:long}/delete")]
        public IActionResult Delete(AModel model)
        {
            Context.AModels.Remove(model);
            Context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
