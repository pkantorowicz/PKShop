using System.Collections.Generic;

namespace CompanyCars.Core.Domain
{
    public class Routes : BaseEntity
    {
        public int CarId { get; set; }
        public double Mileage { get; set; }
        public IEnumerable<Routes> MileageRoutes { get; set; }
    }
}
