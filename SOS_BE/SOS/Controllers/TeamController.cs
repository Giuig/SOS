using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SOS.Core.Domain;
using SOS.Infrastructure.DTO;
using SOS.Infrastructure.Interfaces;
using SOS.Model;
using SOS.Model.RequestModels;

namespace SOS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : Controller
    {
        private readonly ILogger<TeamController> _logger;
        private readonly IMapper _mapper;
        private readonly ITeamDAO _teamDAO;

        public TeamController(ILogger<TeamController> logger, IMapper mapper, ITeamDAO
            teamDAO)
        {
            _logger = logger;
            _mapper = mapper;
            _teamDAO = teamDAO;
        }

        [HttpPost]
        public IActionResult Post(CreateTeamModel teamModel)
        {
            var team = _mapper.Map<Team>(teamModel);
            var teamDTO = _mapper.Map<TeamDTO>(team);
            _teamDAO.Create(teamDTO);
            return Ok();
        }
    }
}
