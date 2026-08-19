using FluentValidation;

namespace OrganizationAssetManagement.Application.Features.Assets.Commands.CreateAsset;

public class CreateAssetCommandValidator : AbstractValidator<CreateAssetCommand>
{
    public CreateAssetCommandValidator()
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
    }
}