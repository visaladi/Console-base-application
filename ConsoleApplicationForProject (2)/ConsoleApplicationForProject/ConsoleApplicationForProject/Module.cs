using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForProject
{
    public class Module
    {
        public string ? ModuleName { get; set; }
        public int CodeNumber { get; set; }
        public string gradeCode { get; set; }

        public Module(string moduleName, int codenumber,string gcode)
        {
            ModuleName = moduleName;
            CodeNumber = codenumber;
            gradeCode= gcode;

        }
       

    }
}
