using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villa.Data;
using Villa.Logging;
using Villa.Models;
using Villa.Models.Dto;
using Villa.Repository;
using Villa.Repository.IRepository;

namespace Villa.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class VillaNumberAPIv2Controller : ControllerBase
    {
        private readonly ILogging _logger;
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IVillaNumberRepository _villaNumberRepository;
        private readonly IVillaRepository _villaRepository;

        public VillaNumberAPIv2Controller(ILogging logger, IMapper mapper, IVillaNumberRepository villaNumberRepository, APIResponse response, IVillaRepository villaRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _villaNumberRepository = villaNumberRepository;
            _response = response;
            _villaRepository = villaRepository;
        }

        //[MapToApiVersion("2.0")]
        [HttpGet("GetString")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}