using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SeedFileTypesDemo
{
    internal class XmlProcessor: IWrite, IRead<List<Employee>>
    {
        public async Task WriteAsync(string filePath, Employee employee)
        {
            List<Employee> employees;
            try
            {
                employees = await this.ReadAsync(filePath);

                if (employees == null)
                {
                    employees = new List<Employee>();
                }
            }
            catch(Exception ex)
            {
                employees = new List<Employee>();
            }

            employees.Add(employee);

            using (var writer = new StreamWriter(filePath))
            {
                var serializer = new XmlSerializer(typeof(List<Employee>));

                serializer.Serialize(writer, employees);
            }
        }

        public async Task<List<Employee>> ReadAsync(string filePath)
        {
            List<Employee> employees;
            using (var reader = new StreamReader(filePath))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Employee>));
                
                employees = (List<Employee>)deserializer.Deserialize(reader);
            }
            return employees;
        }
    }
}
