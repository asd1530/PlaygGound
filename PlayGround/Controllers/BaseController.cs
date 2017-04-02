using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayGround.Controllers
{
    public class BaseController : Controller
    {
        protected IServiceProvider provider;
        public BaseController(IServiceProvider provider)
        {
            this.provider = provider;
        }
    }
}
