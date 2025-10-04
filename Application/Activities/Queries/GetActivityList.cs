using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities.Queries
{
    public class GetActivityList
    {

        public class Query : IRequest<List<Activity>> { }


        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly AppDBContext _dbContext;
            public Handler(AppDBContext appDBContext) { 
            _dbContext = appDBContext;
             }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
               return await _dbContext.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}
