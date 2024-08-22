using Core.Features.Queries.GetTableSpecifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Queries.DeleteTableSpecifications;
    public class DeleteTableSpecificationsQuery : IRequest<DeleteTableSpecificationsResponse>
{
        public Guid TableSpecificationId { get; set; }
    }


