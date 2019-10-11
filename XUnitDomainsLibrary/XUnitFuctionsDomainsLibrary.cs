using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Domains.Library;

namespace XUnitDomainsLibrary
{
    public class XUnitFuctionsDomainsLibrary
    {
        [Fact]
        public void AddLocationAddsToDictionary()
        {
            //arrange
            string name = "Walmart";
            string address = "123 Main St";

            //act
            Functions.AddLocation(name, address);

            //assert
            Assert.Equal(expected: "ID : 0,  NAME: Walmart,  ADDRESS: 123 Main St ", actual: Functions.locations[0].ToString());
        }
    }
}
