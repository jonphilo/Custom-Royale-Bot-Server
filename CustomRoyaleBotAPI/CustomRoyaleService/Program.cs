using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRoyaleService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApp.Start<Startup>(url: "http://localhost:8080/");
            Console.WriteLine("Running on http://loaclhost:8080/");
            Console.ReadKey();
        }
    }
}
