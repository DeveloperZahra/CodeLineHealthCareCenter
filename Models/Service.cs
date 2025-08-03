using CodeLineHealthCareCenter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeLineHealthCareCenter
{
    public class Service 
    {
        // ===================== Static Storage for All Services =====================
        public static List<Service> Services = new List<Service>();

        // ===================== Properties =====================
        public int ServiceId { get; set; }       // Unique ID for the service
        public string ServiceName { get; set; }  // Name of the service
        public int ClinicId { get; set; }        // The clinic this service belongs to
        public decimal Price { get; set; }       // Price of the service

        // ===================== Constructors =====================
        public Service(int serviceId, string serviceName, int clinicId, decimal price)
        {
            ServiceId = serviceId;
            ServiceName = serviceName;
            ClinicId = clinicId;
            Price = price;
        }

        // Default constructor for flexibility
        public Service() { }

        // ===================== Methods =====================

        // Add a new service
        public static void AddService(Service service)
        {
            Services.Add(service);

            Console.WriteLine($"Service '{service.ServiceName}' added successfully.");
        }

        // Remove a service by ID
        public static bool RemoveService(int serviceId)
        {
            var service = Services.FirstOrDefault(s => s.ServiceId == serviceId);
            if (service != null)
            {
                Services.Remove(service);
                Console.WriteLine("Service removed successfully.");
                return true;
            }

            Console.WriteLine("Service not found.");
            return false;
        }

        // Get all services for a specific clinic
        public static List<Service> GetServicesByClinicId(int clinicId)
        {
            return Services.Where(s => s.ClinicId == clinicId).ToList();
        }
    }
}
