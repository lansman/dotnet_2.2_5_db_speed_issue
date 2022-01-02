using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5AspnetSimple.Controllers
{
    [Route("api/Test/[action]")]
    public class TestController : Controller
    {
        private readonly IServiceProvider _serviceProvider;

        public TestController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // GET
        public IActionResult Resolve()
        {
            var sw = Stopwatch.StartNew();

            sw.Restart();
            var dbRw = _serviceProvider.GetRequiredService<MyDbContext>();
            sw.Stop();
            var sw1 = sw.Elapsed.ToString();

            return Ok(new
            {
                Time = sw1
            });
        }

        public IActionResult ResolveCount()
        {
            var sw = Stopwatch.StartNew();

            sw.Restart();
            var _ = _serviceProvider.GetRequiredService<MyDbContext>().YOUR_TABLE.Count();
            sw.Stop();
            var sw1 = sw.Elapsed.ToString();

            return Ok(
                new
                {
                    Time = sw1
                });
        }
    }
}