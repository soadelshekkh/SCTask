using Microsoft.Extensions.Logging;
using SCbank.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SCbank.Repositary.DbContexts
{
    public class ScBankDataSeed
    {
        public static async Task seedAsync(ScBankDbContext context, ILoggerFactory loggerFactory)
        {
            if (!context.Customers.Any())
            {
                try
                {
                    var CustomerData = File.ReadAllText("../SCbank.Repositary/Data/Dataseed/Customer.json");
                    var Customers = JsonSerializer.Deserialize<List<Customer>>(CustomerData);
                    foreach (var customer in Customers)
                    {
                        context.Set<Customer>().Add(customer);
                    }
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<ScBankDataSeed>();
                    logger.LogError(ex, ex.Message);
                }
            }
            if (!context.CustomerTypes.Any())
            {
                try
                {
                    var customerTypes = File.ReadAllText("../SCbank.Repositary/Data/Dataseed/CustomerType.json");
                    var Types = JsonSerializer.Deserialize<List<CustomerType>>(customerTypes);
                    foreach (var Type in Types)
                    {
                        context.Set<CustomerType>().Add(Type);
                    }
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<ScBankDataSeed>();
                    logger.LogError(ex, ex.Message);
                }
            }
        }
        }
    }
