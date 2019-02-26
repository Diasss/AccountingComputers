using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.Computers.Model;

namespace Accounting.Computers.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceEquipment serviceEquipment = new ServiceEquipment();
            serviceEquipment.DbName = @"\\sd\City\SDP-181\Задание 03\sdp-181\comp.db";
            serviceEquipment.RegisterDException(PrintException);
            serviceEquipment.RegisterDSuccessful(PrintSuccessful);

            //Equipment equipment = new Equipment();
            //equipment.Model = "MAKDONALDS";
            //equipment.Name = "Apple";
            //equipment.TypeEquipment = TypeEquipment.notebook;
            //serviceEquipment.AddEquipment(equipment);

            Software software = new Software();
            software.Name = "PhpStorm";
            software.Price = 1000;
            software.Publisher = "Jetbrains";
            software.StartDate = DateTime.Now;
            software.Distribution = Distribution.paid;
            software.Equipment = serviceEquipment.FindEquipmentByName("Apple")[0];

            ServiceSoftware softwareService = new ServiceSoftware();
            softwareService.RegisterDSuccessful(PrintSuccessful);
            softwareService.RegisterDException(PrintException);
            softwareService.RegisterDSentInfo(PrintInfo);

            softwareService.DbName = @"\\sd\City\SDP-181\Задание 03\sdp-181\comp.db";
            softwareService.AddSoftware(software);
        }

        public static void PrintSuccessful(string mesg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mesg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintException(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintInfo(Software soft) {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} было установлено {1}", soft.Name, soft.Equipment?.Name??"");
            Console.ForegroundColor = ConsoleColor.White;

        }

    }
}
