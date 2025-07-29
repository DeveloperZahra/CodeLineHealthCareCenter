using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeLineHealthCareCenter
{
    class Service
    {
        protected List<Service> services = new List<Service>(); // List to store services

        // Add a new service to the list
        public virtual void Add(ServiceModel service)
        {
            services.Add(service);
            Console.WriteLine(" Service added successfully.");
        }




    }
}
