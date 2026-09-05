namespace Journey.Communication.Responses;
public class ResponseTripsJson
{
    public IList<ResponseShortTripJson> Trips { get; set; } = [];
    public int page {  get; set; }
    public int pageSize { get; set; }
    public int totalItems { get; set; }
    public int totalPages { get; set; } 
}
