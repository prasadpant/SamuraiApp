using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class TestClass
    {
        public int a;
        public int b;
        public int c;
        public TestClass()
        {
            a = 10;
            b = 10;
        }

        public TestClass add()
        {
            c = a + b;
            return this;
        }

        public void subtract(int a1 , int b1)
        {
            c = a1 - b1;
        }
    }
}
