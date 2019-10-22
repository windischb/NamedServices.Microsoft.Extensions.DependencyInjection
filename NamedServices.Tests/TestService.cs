using System;
using System.Collections.Generic;
using System.Text;

namespace NamedServices.Tests {
    public class TestService: ITestService {

        public string Name { get; set; }

        public TestService() {
          
        }

        public TestService(string name) {
            Name = name;
        }
    }
}
