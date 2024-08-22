using Core.Features.Queries.GetTableSpecifications;
using MediatR;
using Persistence.Models;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Queries.AddTableSpecifications;

public class AddTableSpecificationsHandler : IRequestHandler<AddTableSpecificationsQuery, AddTableSpecificationsResponse>
{
    private readonly ITableSpecificationRepository _tableSpecificationRepository;
    public AddTableSpecificationsHandler(ITableSpecificationRepository tableSpecificationRepository)
    {
        _tableSpecificationRepository = tableSpecificationRepository;
    }
    public async Task<AddTableSpecificationsResponse> Handle(AddTableSpecificationsQuery query, CancellationToken cancellationToken)
    {
     
        var newTableSpecification = new TableSpecification
        {
            ChairNumber = query.ChairNumber,
            TableNumber = query.TableNumber,
            TablePic = query.TablePic,
            TableType = query.TableType
        };

        _tableSpecificationRepository.Add(newTableSpecification);
        await _tableSpecificationRepository.SaveChangesAsync(cancellationToken);
           
        return new AddTableSpecificationsResponse
        {
            TableId = newTableSpecification.TableId,
            TableNumber = newTableSpecification.TableNumber,
            ChairNumber = newTableSpecification.ChairNumber,
            TablePic = newTableSpecification.TablePic,
            TableType = newTableSpecification.TableType,
        };
    }

    public Task<GetTableSpecificationsResponse> Handle(GetTableSpecificationsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

