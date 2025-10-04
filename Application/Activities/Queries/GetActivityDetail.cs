using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities.Queries
{
    public class GetActivityDetail
    {

        public class Query : IRequest<Activity> {
            public string Id { get; set; }
        }


        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly AppDBContext _dbContext;
            public Handler(AppDBContext appDBContext) { 
            _dbContext = appDBContext;
             }

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
             {
               var activity = await _dbContext.Activities.FindAsync(request.Id, cancellationToken);
                if (activity == null)
                {
                    throw new Exception("not found");
                }
                return activity;
            }
        }
    }
}
