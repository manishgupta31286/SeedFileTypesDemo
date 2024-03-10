using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SeedFileTypesDemo
{
    internal class JsonProcessor: IWrite,IRead<List<Employee>>
    {
        public async Task WriteAsync(string filePath, Employee employee)
        {
            List<Employee> employees;
            employees = await this.ReadAsync(filePath);

            if (employees == null)
            {
                employees = new List<Employee>();
            }

            employees.Add(employee);

            var json = JsonConvert.SerializeObject(employees);

            using (var writer = new StreamWriter(filePath))
            {
                await writer.WriteLineAsync(json);
            }
        }

        public async Task<List<Employee>> ReadAsync(string filePath)
        {
            string json = string.Empty;
            using (var reader = new StreamReader(filePath))
            {
                json = await reader.ReadToEndAsync();
            }
            var data = JsonConvert.DeserializeObject<List<Employee>>(json);
            return data;
        }
        
    }
}
