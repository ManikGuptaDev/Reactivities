using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Commands
{
    public class CreateActivity
    {

        public class Command : IRequest<string> {


            public required Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command, string  > { 
        
            private readonly AppDBContext _dBContext;
            public Handler(AppDBContext dBContext) { 
            _dBContext = dBContext;
            }

            public async Task<string> Handle(Command request, CancellationToken cancellationToken) {

                 _dBContext.Activities.Add(request.Activity);

                await _dBContext.SaveChangesAsync(cancellationToken);

                return request.Activity.Id;

            }

        }
    }
}
