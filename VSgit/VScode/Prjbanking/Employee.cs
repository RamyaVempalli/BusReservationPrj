using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prjbanking
{
    class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public void GetEmployee()
        {
           Console.WriteLine("Enter id");
            id=Convert.ToInt32(Console.ReadLine());
        }
        public void DisplayEmployee()
        {
           Console.WriteLine(id{0},id);
        }
    }

}
