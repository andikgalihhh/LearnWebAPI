using Core.Features.Queries.GetTableSpecifications;
using MediatR;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Core.Features.Queries.UpdateTableSpesifications;

public class UpdateTableSpecificationsHandler : IRequestHandler<UpdateTableSpecificationsQuery, UpdateTableSpecificationsResponse>
{
    private readonly ITableSpecificationRepository _tableSpecificationRepository;

    public UpdateTableSpecificationsHandler(ITableSpecificationRepository tableSpecificationRepository)
    {
        _tableSpecificationRepository = tableSpecificationRepository;
    }
    public async Task<UpdateTableSpecificationsResponse> Handle(UpdateTableSpecificationsQuery query, CancellationToken cancellationToken)
    {
        var tableSpecification = _tableSpecificationRepository.GetById(query.TableSpecificationId);

        if (tableSpecification is null)
            throw new KeyNotFoundException("Table specification not found.");

        tableSpecification.TableNumber = query.TableNumber;
        tableSpecification.ChairNumber = query.ChairNumber;
        tableSpecification.TablePic = query.TablePic;
        tableSpecification.TableType = query.TableType;

        await _tableSpecificationRepository.SaveChangesAsync(cancellationToken);

        return new UpdateTableSpecificationsResponse
        {
            TableId = tableSpecification.TableId,
            TableNumber = tableSpecification.TableNumber,
            ChairNumber = tableSpecification.ChairNumber,
            TablePic = tableSpecification.TablePic,
            TableType = tableSpecification.TableType,
        };
    }

}

