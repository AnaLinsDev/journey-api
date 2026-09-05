using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Trips.GetAll;
public class GetAllTripsUseCase
{
    public ResponseTripsJson Execute(int page, int pageSize, string sortBy, string order)
    {
        var dbContext = new JourneyDbContext();

        var totalItems = dbContext.Trips.Count();

        var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

        ValidateQueries(page, pageSize, totalPages, sortBy, order);

        var query = dbContext.Trips.AsQueryable();

        if (sortBy.ToLower() == "startdate")
        {
            query = order.ToLower() == "asc"
                ? query.OrderBy(trip => trip.StartDate)
                : query.OrderByDescending(trip => trip.StartDate);
        }

        var trips = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new ResponseTripsJson
        {
            Trips = trips.Select(trip => new ResponseShortTripJson
            {
                Id = trip.Id,
                Name = trip.Name,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate,
            }).ToList(),

            page = page,
            pageSize = pageSize,
            totalItems = totalItems,
            totalPages = totalPages
        };
    }

    public void ValidateQueries(int page, int pageSize, int totalPages, string sortBy, string order)
    {
        var allowedSortFields = new[]
        {
            "startdate"
        };

        var allowedOrder = new[]
       {
            "asc",
            "desc"
        };

        if (!(sortBy.ToLower() == "startdate"))
            throw new ErrorOnValidationException(
                [ResourceErrorMessages.INVALID_SORT_FIELD]);
        

        if (!allowedOrder.Contains(order.ToLower()))
            throw new ErrorOnValidationException(
                [ResourceErrorMessages.INVALID_ORDER_FIELD]);
        

        if (page < 1)
            throw new ErrorOnValidationException(
                [ResourceErrorMessages.PAGE_MUST_BE_GREATER_THAN_ZERO]);

        if (pageSize < 1)
            throw new ErrorOnValidationException(
                [ResourceErrorMessages.PAGE_SIZE_MUST_BE_GREATER_THAN_ZERO]);

        if (pageSize > 20)
            throw new ErrorOnValidationException(
                [ResourceErrorMessages.PAGE_GREATER_THAN_MAX_ALLOWED]);

        if (page > totalPages && totalPages > 0)
            throw new ErrorOnValidationException(
                [ResourceErrorMessages.PAGE_GREATER_THAN_TOTAL_PAGES]);
    }

}
