using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using System;

namespace Recodme.RD.Lennyouse.PresentationLayer.App
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
