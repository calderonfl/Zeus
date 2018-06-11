﻿using System.Threading.Tasks;
using System.Web.Mvc;

namespace Kadabra.UI.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet()]
        public async Task<ActionResult> Index()
        {
            return await Task.Run(() => View());
        }

        [HttpGet()]
        public async Task<ActionResult> Teams()
        {
            return await Task.Run(() => RedirectToActionPermanent("Index", "Team"));
        }

        [HttpGet()]
        public async Task<ActionResult> Countries()
        {
            return await Task.Run(() => RedirectToActionPermanent("Index", "Country"));
        }
    }
}