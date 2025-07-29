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
        public virtual void Add(Service service)
        {
            services.Add(service); // Add the service to the list
            Console.WriteLine(" Service added successfully."); 
        }




    }
}
