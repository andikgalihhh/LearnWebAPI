using Core.Features.Queries.GetTableSpecifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Queries.AddTableSpecifications;

public class AddTableSpecificationsQuery : IRequest<AddTableSpecificationsResponse>
{
    public int TableNumber { get; set; }
    public int ChairNumber { get; set; }
    public string TablePic { get; set; }
    public string TableType { get; set; }

}

