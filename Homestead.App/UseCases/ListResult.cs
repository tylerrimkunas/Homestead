using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.App.UseCases
{
    public record ListResult<T> where T : class
    {
        public int Total { get; set; }
        public int Filtered { get; set; }
        public IEnumerable<T> Data { get; set; } = [];
        public IEnumerable<string> Errors { get; set; } = [];
    }
}
