using System;
using System.Collections.Generic;
using System.Text;

namespace SRP__Patterns.Inheritance.src
{

    public class DVD : LibraryItem
    {
        public DVD( string catalogNumber,string title,decimal baseLateFee)
            : base(catalogNumber,title,baseLateFee,7,2)
        {
        }
    }
}
