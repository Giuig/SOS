﻿using SOS.Core.Interfaces;
using SOS.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Infrastructure.Interfaces
{
    public interface IMissionDAO : ICreate<MissionDTO>, IGetById<MissionDTO>, IGetAll<MissionDTO>, IUpdate<MissionDTO>
    {
    }
}
