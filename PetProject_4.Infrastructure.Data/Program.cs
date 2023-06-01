using System;
using PetProject_4.Domain.Models;
using PetProject_4.Infrastructure.Data.Models;

namespace PetProject_4.Infrastructure.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando la DB si no existe...");
            UsersContext db = new UsersContext();
            db.Database.EnsureCreated();
            UserProject project = db.UserProjects.FirstOrDefault(x => x.ProjectId == 12);
            Console.WriteLine(project.Description);
            Console.WriteLine("Listo!!!!!");
            Console.ReadKey();
        }
    }
}