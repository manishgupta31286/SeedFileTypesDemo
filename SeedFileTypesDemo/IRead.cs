using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedFileTypesDemo
{
    internal interface IRead<T>
    {
        public Task<T> ReadAsync(string filePath);
    }
}
