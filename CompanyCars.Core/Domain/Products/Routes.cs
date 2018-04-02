using System.Collections.Generic;

namespace CompanyCars.Core.Domain.Products
{
    public class Routes 
    {
        public int CarId { get; set; }
        public double Mileage { get; set; }
        public IEnumerable<Routes> MileageRoutes { get; set; }
    }
}
