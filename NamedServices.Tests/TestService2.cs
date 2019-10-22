using System;
using System.Collections.Generic;
using System.Text;

namespace NamedServices.Tests {
    public class TestService2: ITestService {

        public string Name { get; set; }


        public TestService2() {
          
        }

        public TestService2(string name) {
            Name = name;
        }
    }
}
