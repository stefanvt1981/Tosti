using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TostiBusinessEntities;
using TostiFrontEnd.Components.TostiBackEndClient;

namespace TostiFrontEnd.Controllers
{
    public class TostiController : Controller
    {
        private ITostiBackEndClient _client;

        public TostiController(ITostiBackEndClient client)
        {
            _client = client;
        }

        // GET: Tosti
        public ActionResult Index()
        {
            try
            {
                Console.WriteLine($"Used url: {_client.GetBackendUrl()}");

                var tostis = _client.GetAllTostis();

                return View(_client.GetAllTostis());
            }
            catch(Exception ex)
            {
                return RedirectToPage("Error");
            }
        }

        // GET: Tosti/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(_client.GetTosti(id));
            }
            catch (Exception ex)
            {
                return RedirectToPage("Error");
            }
        }

        // GET: Tosti/Create
        public ActionResult Create()
        {
            try
            {
                return View(new Tosti());
            }
            catch (Exception ex)
            {
                return RedirectToPage("Error");
            }
        }

        // POST: Tosti/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tosti tosti)
        {
            try
            {
                _client.UpsertTosti(tosti);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tosti/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(_client.GetTosti(id));
            }
            catch (Exception ex)
            {
                return RedirectToPage("Error");
            }
        }

        // POST: Tosti/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tosti tosti)
        {
            try
            {
                _client.UpsertTosti(tosti);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tosti/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(_client.GetTosti(id));
            }
            catch (Exception ex)
            {
                return RedirectToPage("Error");
            }
        }

        // POST: Tosti/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Tosti tosti)
        {
            try
            {
                _client.DeleteTosti(tosti);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}