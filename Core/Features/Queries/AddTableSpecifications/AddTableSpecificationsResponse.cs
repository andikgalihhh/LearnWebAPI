using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Queries.AddTableSpecifications;

public class AddTableSpecificationsResponse
{
    public Guid TableId { get; set; }
    public int TableNumber { get; internal set; }
    public int ChairNumber { get; internal set; }
    public string TablePic { get; internal set; }
    public string? TableType { get; internal set; }
}

