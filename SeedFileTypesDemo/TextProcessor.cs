using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SeedFileTypesDemo
{
    internal class TextProcessor:IWrite, IRead<string>
    {
        public async Task WriteAsync(string filePath, Employee employee)
        {
            using (var writer = new StreamWriter(filePath, true))
            {
                await writer.WriteLineAsync(employee.ToString());
            }
        }

        public async Task<string> ReadAsync(string filePath)
        {
            string result = string.Empty;
            using (var reader = new StreamReader(filePath))
            {
                result = await reader.ReadToEndAsync();
            }
            return result;
        }
    }
}
