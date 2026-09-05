using FluentValidation;
using Journey.Communication.Requests;
using Journey.Exception;

namespace Journey.Application.UseCases.Trips.Update;
public class UpdateTripValidator : AbstractValidator<RequestUpdateTripJson>
{
    public UpdateTripValidator()
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .When(request => request.Name is not null)
            .WithMessage(ResourceErrorMessages.NAME_EMPTY);

        RuleFor(request => request.StartDate)
            .GreaterThanOrEqualTo(DateTime.UtcNow)
            .When(request => request.StartDate is not null)
            .WithMessage(ResourceErrorMessages.DATE_TRIP_MUST_BE_LATER_THAN_TODAY);

        RuleFor(request => request)
            .Must(request => request.EndDate >= request.StartDate)
            .When(request => request.EndDate is not null)
            .WithMessage(ResourceErrorMessages.END_DATE_TRIP_MUST_BE_LATER_THAN_START_DATE);
    }
}
