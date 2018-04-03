using CompanyCars.Core.Exceptions;
using System;

namespace CompanyCars.Core.Domain.Products
{
    public class Route 
    {
        public Product ProductId { get; protected set; }
        public string Name { get; set; }
        public double StartValue { get; set; }
        public double MileageBefore { get; protected set; }
        public double MileageAfter { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected Route()
        {
        }

        protected Route(Product productId, string name, double startValue, 
            double mileageBefore, double mileageAfter)
        {
            ProductId = productId;
            SetName(name);
            SetStartValue(startValue);
            SetMileageBefore(mileageBefore);
            SetMileageAfter(mileageAfter);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new CompanyCarsException("RouteName can not be empty");
            }
            if (name.Length > 100)
            {
                throw new CompanyCarsException("RouteName can not be longer than 100 character.");
            }
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetMileageBefore(double mileageBefore)
        {
            if (mileageBefore < 0)
            {
                throw new CompanyCarsException("MileageBefore can not be lower than 0");
            }

            MileageBefore = mileageBefore;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetMileageAfter(double mileageAfter)
        {
            if (mileageAfter < 0)
            {
                throw new CompanyCarsException("MileageAfter can not be lower than 0");
            }

            MileageAfter = mileageAfter;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetStartValue(double startValue)
        {
            if (startValue < 0)
            {
                throw new CompanyCarsException("startValue can not be lower than 0");
            }

            StartValue = startValue;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Route Create(Product productId, string name,  double startValue, 
            double mileageBefore, double mileageAfter)
            => new Route(productId, name, startValue, mileageBefore, mileageAfter);
    }
}
