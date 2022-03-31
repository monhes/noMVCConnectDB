using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Store
    {
        MethodClass obj = new MethodClass();
        public Action<int,int,int> Add;
        public void annoucement(string message,string cuntomer) {
            Console.WriteLine("Attention plz : {0} {1}",message,cuntomer);
        }

        public delegate void Del(string message);
        public void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }
        public void DelegateImplement(Del del,string message)
        {
            del(message);
        }

        public void StatDelegate()
        {
            // Instantiate the delegate.
            Del handler = DelegateMethod;

            // Call the delegate.
            handler("stay");

            //call delegate as argument
            MethodWithCallback(1, 2, handler);

            Del d1 = obj.Method1;
            Del d2 = obj.Method2;
            Del d3 = DelegateMethod;

            Del allMethodsDelegate = d1 + d2;
            allMethodsDelegate += d3;
        }
        public static void MethodWithCallback(int param1, int param2, Del callback)
        {
            callback("The number is: " + (param1 + param2).ToString());
        }
        


    }
    public class MethodClass
    {
        public void Method1(string message) { }
        public void Method2(string message) { }

          
    }
}
