using CQRSMediatR.Api.Services;
using MediatR;
using FluentValidation;
using CQRSMediatR.Api.DTOs;

namespace CQRSMediatR.Api.Application.Flows.Queries;

public class CreateFlowValidator : AbstractValidator<CreateFlowRequest>
{

    public CreateFlowValidator()
    {
        RuleFor(flow => flow.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

        RuleFor(flow => flow.ApplicationId)
            .NotEmpty().WithMessage("ApplicationId is required.");

        RuleFor(flow => flow.Channels)
            .NotEmpty().WithMessage("Channels list must not be empty.")
            .Must(channels => channels != null && channels.Count > 0)
            .WithMessage("Channels list cannot be null or empty.");

        RuleForEach(flow => flow.Channels).SetValidator(new ChannelDtoValidator());
    }
}

public class ChannelDtoValidator : AbstractValidator<ChannelDto>
{
    public ChannelDtoValidator()
    {
        RuleFor(channel => channel.ChannelType)
            .IsInEnum().WithMessage("ChannelType must be a valid enum value.");

        RuleFor(channel => channel.Country)
            .IsInEnum().WithMessage("Country must be a valid enum value.");

        RuleFor(channel => channel.Priority)
            .GreaterThanOrEqualTo(0).WithMessage("Priority must be a non-negative number.");
    }
}