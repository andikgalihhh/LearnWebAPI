using MediatR;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Queries.DeleteTableSpecifications;

public class DeleteTableSpecificationHandler : IRequestHandler<DeleteTableSpecificationsQuery, DeleteTableSpecificationsResponse>
{
    private readonly ITableSpecificationRepository _tableSpecificationRepository;
    public DeleteTableSpecificationHandler(ITableSpecificationRepository tableSpecificationRepository)
    {
        _tableSpecificationRepository = tableSpecificationRepository;
    }
    public async Task<DeleteTableSpecificationsResponse> Handle(DeleteTableSpecificationsQuery query, CancellationToken cancellationToken)
    {
        var tableSpecification = _tableSpecificationRepository.GetById(query.TableSpecificationId);

        if (tableSpecification is null)
            throw new KeyNotFoundException("Table specification not found.");

        _tableSpecificationRepository.Remove(tableSpecification);
        await _tableSpecificationRepository.SaveChangesAsync(cancellationToken);

        return new DeleteTableSpecificationsResponse
        {
            TableId = tableSpecification.TableId,
        };
    }
}

