using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    partial class Program
    {
        public class MyAttribute : Attribute
        {
            public MyAttribute() { }
            public MyAttribute(string DescriptionParam)
            {
                Description = DescriptionParam;
            }

            public string Description { get; set; }
        }
    }
}
