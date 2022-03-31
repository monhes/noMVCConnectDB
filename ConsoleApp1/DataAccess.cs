using ConsoleApp1.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DataAccess
    {
         
         
        string connectstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MinimalAPIUserDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void printUser()
        {
            Console.WriteLine("test");
            using IDbConnection connection = new SqlConnection(connectstring);

            var doe = connection.Query<UserModel>("dbo.spUser_Get", new {Id = 1 }, commandType: CommandType.StoredProcedure).ToList();
            
            foreach (var item in doe)
            {
                Console.WriteLine(item.FirstName);
            }
            Console.WriteLine("type : " + doe.GetType());
            Console.WriteLine("Asyn Type"+ GetPeople().Result.GetType());
            foreach (var item in GetPeople().Result)
            {
                Console.WriteLine("Last Name: "+item.LastName);
            }
        }

        async Task<IEnumerable<UserModel>> GetPeople()
        { 
            using IDbConnection connection = new SqlConnection(connectstring);
            return await connection.QueryAsync<UserModel>("dbo.spUser_GetAll", new {}, commandType: CommandType.StoredProcedure);
        }
    }
}
