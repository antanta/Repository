using Domain;
using Repository.EntityFramework;
using Repository.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Repository;
using Repository.Azure;

namespace MainApplication
{
    class Program
    {
        static Program()
        {
            //DependencyInjection
            repoCreator = new AzureRepositoryCreator();
            repoCreator = new FileRepositoryCreator();
            repoCreator = new EntityFrameworkRepositoryCreator();
        }

        static void Main(string[] args)
        {
            Repository<Student> repository = repoCreator.GetRepository<Student>();

            var s = new Student
            {
                Id = 1,
                Name = "antanta"
            };

            repository.Insert(s);
            repository.SaveChanges();

            foreach (var item in repository.Items)
            {
                Console.WriteLine("{0} {1}", item.Id, item.Name);
            }
            Console.ReadLine();
        }

        static IRepositoryCreator repoCreator;
    }
}
