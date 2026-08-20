using MediatR;
using OrganizationAssetManagement.Application.Common.DTOs;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Application.Common.Models;
using OrganizationAssetManagement.Domain.Entities;
using OrganizationAssetManagement.Domain.Enums;

namespace OrganizationAssetManagement.Application.Features.Assets.Commands.ReturnAsset;

public class ReturnAssetCommandHandler
    : IRequestHandler<ReturnAssetCommand, AssetAssignmentDto>
{
    private readonly IAssetRepository _assetRepository;
    private readonly IAssetAssignmentRepository _assignmentRepository;
    private readonly IAssetHistoryRepository _historyRepository;

    public ReturnAssetCommandHandler(
        IAssetRepository assetRepository,
        IAssetAssignmentRepository assignmentRepository,
        IAssetHistoryRepository historyRepository)
    {
        _assetRepository = assetRepository;
        _assignmentRepository = assignmentRepository;
        _historyRepository = historyRepository;
    }

    public async Task<AssetAssignmentDto> Handle(
        ReturnAssetCommand request,
        CancellationToken cancellationToken)
    {
        var asset = await _assetRepository.GetByIdAsync(request.AssetId);

        if (asset == null)
        {
            throw new Exception("Asset was not found.");
        }

        var assignment =
            await _assignmentRepository.GetActiveByAssetIdAsync(
                request.AssetId);

        if (assignment == null)
        {
            throw new Exception(
                "Asset does not have an active assignment.");
        }

        var now = DateTime.UtcNow;

        assignment.ReturnedAt = now;

        await _assignmentRepository.UpdateAsync(assignment);

        asset.Status = AssetStatus.Available;

        await _assetRepository.UpdateAsync(asset);

        var history = new AssetHistory
        {
            Id = Guid.NewGuid(),
            AssetId = asset.Id,
            Action = "Returned",
            Description = "Asset returned by user.",
            ActionDate = now,
            CreatedAt = now
        };

        await _historyRepository.AddAsync(history);

        return new AssetAssignmentDto
        {
            Id = assignment.Id,
            AssetId = assignment.AssetId,
            UserId = assignment.UserId,
            AssignedAt = assignment.AssignedAt,
            ReturnedAt = assignment.ReturnedAt
        };
    }
}