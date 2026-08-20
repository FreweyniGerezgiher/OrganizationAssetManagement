using MediatR;
using OrganizationAssetManagement.Application.Common.DTOs;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Application.Common.Models;
using OrganizationAssetManagement.Domain.Entities;
using OrganizationAssetManagement.Domain.Enums;

namespace OrganizationAssetManagement.Application.Features.Assets.Commands.AssignAsset;

public class AssignAssetCommandHandler
    : IRequestHandler<AssignAssetCommand, AssetAssignmentDto>
{
    private readonly IAssetRepository _assetRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAssetAssignmentRepository _assignmentRepository;
    private readonly IAssetHistoryRepository _historyRepository;

    public AssignAssetCommandHandler(
        IAssetRepository assetRepository,
        IUserRepository userRepository,
        IAssetAssignmentRepository assignmentRepository,
        IAssetHistoryRepository historyRepository)
    {
        _assetRepository = assetRepository;
        _userRepository = userRepository;
        _assignmentRepository = assignmentRepository;
        _historyRepository = historyRepository;
    }

    public async Task<AssetAssignmentDto> Handle(
        AssignAssetCommand request,
        CancellationToken cancellationToken)
    {
        var asset = await _assetRepository.GetByIdAsync(request.AssetId);

        if (asset == null)
        {
            throw new Exception("Asset was not found.");
        }

        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            throw new Exception("User was not found.");
        }

        if (asset.Status != AssetStatus.Available)
        {
            throw new Exception(
                "Only available assets can be assigned.");
        }

        if (asset.OrganizationUnitId.HasValue &&
            user.OrganizationUnitId != asset.OrganizationUnitId)
        {
            throw new Exception(
                "Asset and user must belong to the same organization unit.");
        }

        var activeAssignment =
            await _assignmentRepository.GetActiveByAssetIdAsync(
                request.AssetId);

        if (activeAssignment != null)
        {
            throw new Exception(
                "Asset is already assigned.");
        }

        var now = DateTime.UtcNow;

        var assignment = new AssetAssignment
        {
            Id = Guid.NewGuid(),
            AssetId = asset.Id,
            UserId = user.Id,
            AssignedAt = now,
            CreatedAt = now
        };

        await _assignmentRepository.AddAsync(assignment);

        asset.Status = AssetStatus.Assigned;

        await _assetRepository.UpdateAsync(asset);

        var history = new AssetHistory
        {
            Id = Guid.NewGuid(),
            AssetId = asset.Id,
            Action = "Assigned",
            Description = "Asset assigned to user.",
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