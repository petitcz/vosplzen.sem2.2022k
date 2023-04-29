using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace VOSPlzen.Sem2h1k.Controllers
{
    [ApiController]
    [Route("crypto")]
    public class CryptoController : ControllerBase
    {
        [HttpGet]
        [Route("info")]
        public IActionResult GetInfo(int version = 0)
        {
            var result = GetVersionInfos()
                .Where(x => x.Version == version).ToList();

            return new JsonResult(result);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateInfo(VersionInfo versionInfo)
        {
            var result = GetVersionInfos();

            result.Add(versionInfo);

            return new JsonResult(result);

        }

        private List<VersionInfo> GetVersionInfos()
        {
            var list = new List<VersionInfo>();

            for (int i = 1; i < 10; i++)
            {
                list.Add(new VersionInfo()
                {
                    Created = DateTime.Now.AddDays(i),
                    Name = "Version: " + i.ToString(),
                    Version = i
                });
            }

            return list;
        }


    }
}
