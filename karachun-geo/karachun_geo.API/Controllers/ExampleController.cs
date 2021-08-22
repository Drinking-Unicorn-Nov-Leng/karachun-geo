using AutoMapper;
using AutoMapper.Collection;
using AutoMapper.EntityFrameworkCore;
using karachun_geo.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using karachun_geo.Data.Base;
using karachun_geo.BI.Interfaces;

namespace karachun_geo.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ExampleController : BaseController
    {
        private readonly ILogger<ExampleController> _logger;
        private readonly IMapper _mapper;
        private readonly IGeolocation _geolocation;

        public ExampleController(ILogger<ExampleController> logger, IMapper mapper, IGeolocation geolocation)
        {
            _logger = logger;
            _mapper = mapper;
            _geolocation = geolocation;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Coordinates coordinates)
        {
            return Ok(await _geolocation.GetObjectsNearby(coordinates));
        }
    }
}
