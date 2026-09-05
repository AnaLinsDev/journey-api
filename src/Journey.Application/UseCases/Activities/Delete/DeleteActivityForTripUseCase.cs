using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Activities.Delete;
public class DeleteActivityForTripUseCase
{
    public void Execute(Guid tripId, Guid activityId)
    {
        var dbContext = new JourneyDbContext();

        var trip = dbContext.Trips.Include(trip => trip.Activities)
            .FirstOrDefault(trip => trip.Id == tripId);

        if (trip == null)
        {
            throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);
        }

        var activity = trip.Activities.FirstOrDefault(activity => activity.Id == activityId);

        if (activity == null)
        {
            throw new NotFoundException(ResourceErrorMessages.ACTIVITY_NOT_FOUND);
        }

        trip.Activities.Remove(activity);
        dbContext.SaveChanges();
    }
}
