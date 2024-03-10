using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SeedFileTypesDemo
{
    internal class CsvProcessor : IWrite, IRead<List<Employee>>
    {
        public async Task<List<Employee>> ReadAsync(string filePath)
        {
            List<Employee> employees = new List<Employee>();
            string data;
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = await reader.ReadLineAsync();
                    string[] fields = line.Split(',');

                    Employee employee = new Employee
                    {
                        Id = fields[0],
                        FirstName = fields[1],
                        LastName = fields[2],
                    };
                    employees.Add(employee);
                }
            }
            return employees;
        }

        public async Task WriteAsync(string filePath, Employee employee)
        {
            using (var writer = new StreamWriter(filePath, true))
            {
                string csvdata = $"{employee.Id},{employee.FirstName},{employee.LastName}";
                await writer.WriteLineAsync(csvdata);
            }
        }
    }
}
