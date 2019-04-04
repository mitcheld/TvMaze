using TvMaze.Infrastructure;
using TvMaze.Infrastructure.Models;
using TvMaze.Services.Interfaces;

namespace TvMaze.Services
{
    public class CastMemberService : Service<CastMember>, ICastMemberService
    {
        public CastMemberService(DatabaseContext context) : base(context) { }
    }
}
