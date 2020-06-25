using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new RestaurantContext();
            ctx.Database.EnsureCreated();
        }
    }
}
