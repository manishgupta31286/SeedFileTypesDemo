using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedFileTypesDemo
{
    internal interface IWrite
    {
        public Task WriteAsync(string filePath, Employee employee);
    }
}
