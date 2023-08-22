using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Infrastructure.Persistance;
using PhoneBook.Infrastructure.Repositories;
using PhoneBook.Infrastructure.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PhoneBookDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("PhoneBook")));

            services.AddScoped<PhoneBookSeeder>();

            services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();
        }

    }
}
