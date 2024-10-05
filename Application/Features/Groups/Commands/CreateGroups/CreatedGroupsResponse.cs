﻿using Core.Application.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Groups.Commands.CreateGroups
{
    public class CreatedGroupsResponse : IResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MatchName { get; set; }
    }
}
