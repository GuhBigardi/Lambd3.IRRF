using FluentValidator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lambda3.IRRF.API.Controllers
{
    public class BaseController : Controller
    {
        public async Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                return Ok(new
                {
                    sucess = true,
                    data = result
                });
            }
            else
            {
                return BadRequest(new
                {
                    sucess = false,
                    data = notifications
                });
            }
        }
    }
}
