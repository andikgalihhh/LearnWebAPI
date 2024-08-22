using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Queries.UpdateTableSpesifications;

public class UpdateTableSpecificationsQuery : IRequest<UpdateTableSpecificationsResponse>
{
    public Guid TableSpecificationId { get; set; }
    public int TableNumber { get; set; }
    public int ChairNumber { get; set; }
    public string TablePic { get; set; }
    public string TableType { get; set; }
}

