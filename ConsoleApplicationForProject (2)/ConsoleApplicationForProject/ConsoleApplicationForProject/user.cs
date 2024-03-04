using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForProject
{
    public class user
    {
        public string? Name { get; set; }
        public string? Birth { get; set; }
        public string? Address { get; set; }
        public int? Id { get; set; }
        public string? Password { get; set; }
        public List<Module> UserModules { get; set; }
        



        public user(string name, string birth, string address, int id, string password)
        {
            Name = name;
            Birth = birth;
            Address = address;
            Id = id;
            Password = password;
            UserModules = new List<Module>();
        }
        public double gpa()
        {
            double total=0;
            for(int i=0;i<5;i++)
            {
                if (UserModules[i].gradeCode == "A")
                {
                    total += 4;
                }
                else if (UserModules[i].gradeCode == "B")
                {
                    total += 3;
                }
                else if (UserModules[i].gradeCode == "C")
                {
                    total += 2;
                }
                else
                {
                    total+= 0;
                }
                
                



            }
            double GPA = total / 5;
            return GPA;

        }
        }
        
       







    }

