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
    public class TeamMemberController : Controller
    {
        private readonly ILogger<TeamMemberController> _logger;
        private readonly IMapper _mapper;
        private readonly ITeamMemberDAO _teamMemberDAO;

        public TeamMemberController(ILogger<TeamMemberController> logger, IMapper mapper, ITeamMemberDAO
            teamMemberDAO)
        {
            _logger = logger;
            _mapper = mapper;
            _teamMemberDAO = teamMemberDAO;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateTeamMemberModel teamMemberModel)
        {
            var teamMember = _mapper.Map<TeamMember>(teamMemberModel);
            var teamMemberDTO = _mapper.Map<TeamMemberDTO>(teamMember);
            await _teamMemberDAO.Create(teamMemberDTO);
            return Created("", teamMemberDTO);
        }

    }
}
