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
    public class DeleteActivity
    {

        public class Command : IRequest {

            public required string Id { get; set; }
        }

        public class Handler:IRequestHandler<Command> {
            private readonly AppDBContext _context;
            public Handler(AppDBContext appDBContext )
            {
                this._context = appDBContext;

            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Id, cancellationToken);
                if (activity == null) throw new Exception("Activity Not Found");

               _context.Activities.Remove(activity);    

                await _context.SaveChangesAsync();
            }


        }
    }
}
