using FluentValidation;

namespace OrganizationAssetManagement.Application.Features.Assets.Commands.UpdateAsset;

public class UpdateAssetCommandValidator
    : AbstractValidator<UpdateAssetCommand>
{
    public UpdateAssetCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.AssetTag)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.SerialNumber)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleFor(x => x.Status)
            .IsInEnum();

        RuleFor(x => x.OrganizationUnitId)
            .Must(id => id == null || id != Guid.Empty)
            .WithMessage("Organization unit ID must be a valid GUID.");
    }
}