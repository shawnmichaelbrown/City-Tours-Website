using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IItineraryDAO
    {
        List<Itinerary> RetrieveItineraries(int userId);
        bool AddItinerary(Itinerary itinerary);
        bool DeleteItinerary(int id);
        bool EditItinerary(Itinerary itinerary);
    }
}
