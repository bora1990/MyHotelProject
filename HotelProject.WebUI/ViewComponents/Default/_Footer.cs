﻿using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _Footer : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
