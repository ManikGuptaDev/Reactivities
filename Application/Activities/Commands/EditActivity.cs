using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Application.Activities.Commands
{
    public class EditActivity
    {

        public class Command : IRequest {

            public required Domain.Activity Activity { get; set; }
        }

        public class Handler:IRequestHandler<Command> {
            private readonly AppDBContext _context;
            public Handler(AppDBContext appDBContext )
            {
                this._context = appDBContext;

            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity.Id, cancellationToken);
                if (activity == null) throw new Exception("Activity Not Found");

                activity.Title = request.Activity.Title;
                activity.Venue = request.Activity.Venue;
                activity.City = request.Activity.City;

                await _context.SaveChangesAsync();
            }


        }
    }
}
