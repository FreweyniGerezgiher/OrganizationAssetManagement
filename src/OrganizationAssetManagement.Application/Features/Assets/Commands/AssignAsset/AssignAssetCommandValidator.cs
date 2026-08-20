using FluentValidation;

namespace OrganizationAssetManagement.Application.Features.Assets.Commands.AssignAsset;

public class AssignAssetCommandValidator
    : AbstractValidator<AssignAssetCommand>
{
    public AssignAssetCommandValidator()
    {
        RuleFor(x => x.AssetId)
            .NotEmpty()
            .WithMessage("Asset ID is required.");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User ID is required.");
    }
}