using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeLineHealthCareCenter
{
    class Service
    {
        protected List<Department> departments = new List<Department>(); // List to store departments

        public Service(List<Department> departments) // Constructor to initialize the service with a list of departments
        {
            this.departments = departments;
        }

        protected List<Service> services = new List<Service>(); // List to store services

        // Add a new service to the list
        public virtual void Add(Service service)
        {
            services.Add(service); // Add the service to the list
            Console.WriteLine(" Service added successfully."); 
        }

        // Get all services
        public virtual List<Service> GetAll()
        {
            return services;
        }

        // Find service based on a matching condition
        public virtual Service GetBy(Predicate<Service> match)
        {
            return services.Find(match); // Find the first service that matches the condition
        }

        // Remove service based on a matching condition
        public virtual bool Remove(Predicate<Service> match)
        {
            var service = services.Find(match); // Find the first service that matches the condition
            if (service != null)
            {
                services.Remove(service); // Remove the service from the list
                Console.WriteLine(" Service removed.");
                return true;
            }
            Console.WriteLine(" Service not found.");
            return false;
        }

        // Print all services using a custom action
        public virtual void PrintAll(Action<Service> printAction)
        {
            if (services.Count == 0) 
            {
                Console.WriteLine(" No services found.");
                return;
            }

            foreach (var service in services) 
            {
                printAction(service); // Call the provided action to print each service
            }
        }



    }
}
