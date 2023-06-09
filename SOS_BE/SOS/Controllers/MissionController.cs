﻿using AutoMapper;
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
    public class MissionController : Controller
    {
        private readonly ILogger<MissionController> _logger;
        private readonly IMapper _mapper;
        private readonly IMissionDAO _missionDAO;

        public MissionController(ILogger<MissionController> logger, IMapper mapper, IMissionDAO
            missionDAO)
        {
            _logger = logger;
            _mapper = mapper;
            _missionDAO = missionDAO;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateMissionModel missionModel)
        {
            var mission = _mapper.Map<Mission>(missionModel);
            var missionDTO = _mapper.Map<MissionDTO>(mission);
            await _missionDAO.Create(missionDTO);
            return Created("", missionDTO);
        }
    }
}
