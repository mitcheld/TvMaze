using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvMaze.Infrastructure;
using TvMaze.Models;
using TvMaze.Services.Interfaces;

namespace TvMaze.Services
{
    public class CastMemberService : Service<CastMember> ,ICastMemberService
    {
        public CastMemberService(DatabaseContext context) : base(context) { }

        // Add custom functions below

    }
}
