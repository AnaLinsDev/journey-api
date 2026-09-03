using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Communication.Responses;
public class ResponseTripsJson
{
    public IList<ResponseShortTripJson> Trips { get; set; } = [];
}
