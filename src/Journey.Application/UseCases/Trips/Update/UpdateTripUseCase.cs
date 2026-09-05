using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Trips.Update;
public class UpdateTripUseCase
{
    public void Execute(Guid id, RequestUpdateTripJson request)
    {
        Validate(request);

        var dbContext = new JourneyDbContext();

        var trip = dbContext.Trips
            .FirstOrDefault(trip => trip.Id == id);

        if (trip == null)
        {
            throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);
        }

        if (request.Name is not null)
            trip.Name = request.Name;

        if (request.StartDate is not null)
            trip.StartDate = request.StartDate.Value;

        if (request.EndDate is not null)
            trip.EndDate = request.EndDate.Value;

        dbContext.SaveChanges();
    }
    
    private void Validate(RequestUpdateTripJson request)
    {
        var validator = new UpdateTripValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
