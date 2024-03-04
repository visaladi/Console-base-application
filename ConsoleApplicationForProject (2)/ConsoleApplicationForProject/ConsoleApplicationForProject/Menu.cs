using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Reflection.Metadata;
using System.Net.Cache;
using System.Transactions;

namespace ConsoleApplicationForProject
{
    public class Menu
    {
        public int ColPos { get; set; }
        public int RowPos { get; set; }
        public int SelectedItem { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public List<SelectUserItem> SelectUserItems { get; set; }
        
       

        public List<user> users { get; set; }
        public Menu()
        {
            ColPos = Console.WindowWidth / 2;
            RowPos = 10;
            SelectedItem = 0;

            
            MenuItems = new List<MenuItem>
            {

                new MenuItem("Add User", true),
                new MenuItem("Select User", false),
                new MenuItem("Delete User", false),
                new MenuItem("Display All Users",false),
                new MenuItem("Quit", false)
            };
            SelectUserItems = new List<SelectUserItem>
            {
                new SelectUserItem("Modify User",true),
                new SelectUserItem("Edit Modules",false),
                new SelectUserItem("Back",false),




            };
            users = new List<user>();

          


        }

        public void DisplayMenu()
        {
          

                Console.CursorVisible = false;
            bool running = true;
            Console.Write(string.Join("", Enumerable.Repeat("*", 48)));
            Console.Write("Welcome To The Programme");
            Console.WriteLine(string.Join("", Enumerable.Repeat("*", 48)));
            while (running)
            {




                for (int i = 0; i < MenuItems.Count; i++)
                {
                    Console.SetCursorPosition(ColPos, RowPos + i);

                    if (MenuItems[i].IsSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(MenuItems[i].Title);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(MenuItems[i].Title);
                    }

                }



                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = (SelectedItem + 1) % MenuItems.Count;
                    MenuItems[SelectedItem].IsSelected = true;
                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = (SelectedItem - 1);
                    if (SelectedItem < 0)
                    {
                        SelectedItem = MenuItems.Count - 1;
                    }
                    MenuItems[SelectedItem].IsSelected = true;
                }


                if (key.Key == ConsoleKey.Enter)
                {


                    if (MenuItems[SelectedItem].Title == "Display All Users")


                    {
                        Console.Clear();
                        Console.WriteLine(" ".PadRight(50)+" Complete List");
                        if (users.Count == 0)
                        {
                            Console.WriteLine("This is empty");
                        }

                        for (int i = 0; i < users.Count; i++)
                        {
                            Console.SetCursorPosition(5, 5 + i);
                            double Gp = users[i].gpa();
                            Console.WriteLine($" Name : {users[i].Name} | Address : {users[i].Address} | Birth Year : {users[i].Birth} | Id : {users[i].Id} | GPA : {Gp}");

                        }
                        Console.ReadKey();
                        Console.Clear();


                    }

                    if (MenuItems[SelectedItem].Title == "Add User")
                    {
                        Console.Clear();

                        Console.SetCursorPosition(2, 2);

                        Console.Write("Enter Your Name     :" + " ".PadRight(5));
                        string? name = Console.ReadLine();
                        Console.SetCursorPosition(2, 3);
                        Console.Write("Enter Your BirthDay :" + " ".PadRight(5));
                        string? birth = Console.ReadLine();
                        Console.SetCursorPosition(2, 4);
                        Console.Write("Enter Your Address  :" + " ".PadRight(5));
                        string? Address = Console.ReadLine();
                        int id = users.Count;
                        string id_s = Convert.ToString(id);
                        Console.SetCursorPosition(2, 5);
                        Console.Write("Enter Password      :" + " ".PadRight(5));
                        string? new_password = Console.ReadLine();
                        
                        user newUser = new user(name, birth, Address, id, new_password);
                        newUser.UserModules = new List<Module>();
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write("Add module name :");
                            string n=Console.ReadLine();
                            int m = i;
                            Console.Write("Add the grade :");
                            string g=Console.ReadLine();
                            if (g != "A" && g != "B" && g != "C" && g != "D" && g != "E")
                            {
                                i--;
                                Console.WriteLine("wrong grade so you have to re added the  moduule again ");


                            }
                            else
                            {
                                newUser.UserModules.Add(new Module(n, m, g));
                            }


                        }
                        users.Add(newUser);
                        

                        

                        Console.Beep();
                        Console.Clear();

                    }

                    if (MenuItems[SelectedItem].Title == "Select User")
                    {
                        Console.Clear();
                        bool run = true;
                        while (run)
                        {

                            for (int i = 0; i < SelectUserItems.Count; i++)
                            {
                                Console.SetCursorPosition(2, 2 + i);
                                if (SelectUserItems[i].Selection)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.WriteLine(SelectUserItems[i].Option);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.WriteLine(SelectUserItems[i].Option);

                                }
                            }
                            var key2 = Console.ReadKey();
                            if (key2.Key == ConsoleKey.DownArrow)
                            {
                                SelectUserItems[SelectedItem].Selection = false;
                                SelectedItem = (SelectedItem + 1) % SelectUserItems.Count;
                                SelectUserItems[SelectedItem].Selection = true;
                            }
                            if (key2.Key == ConsoleKey.UpArrow)
                            {
                                SelectUserItems[SelectedItem].Selection = false;
                                SelectedItem = (SelectedItem - 1);
                                if (SelectedItem < 0)
                                {
                                    SelectedItem = SelectUserItems.Count - 1;
                                }
                                SelectUserItems[SelectedItem].Selection = true;
                            }
                            if (key2.Key == ConsoleKey.Enter)
                            {

                                if (SelectUserItems[SelectedItem].Option == "Modify User")
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(10, 20);

                                    int select;
                                    try
                                    {
                                        Console.WriteLine("Enter your Id : ");

                                        select = Convert.ToInt32(Console.ReadLine());




                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                                        select = -1;
                                    }

                                    if (select == -1)
                                    {
                                        Console.Clear();
                                        DisplayMenu();
                                    }
                                    Console.WriteLine("Enter Your Password : ");
                                    string selectPassword = Console.ReadLine();
                                    if (select < users.Count)
                                    {
                                        if (selectPassword == users[select].Password)
                                        {
                                            Console.Write("New Name :");
                                            string Name = Console.ReadLine();
                                            Console.Write("New Adress :");
                                            string Address = Console.ReadLine();
                                            Console.Write("New Date Of Birth :");
                                            string Birth = Console.ReadLine();
                                            Console.Write("New Password : ");
                                            string Password = Console.ReadLine();
                                            users[select].Name = Name;
                                            users[select].Address = Address;
                                            users[select].Password = Password;
                                            users[select].Birth = Birth;
                                            Console.Clear();
                                            DisplayMenu();
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            DisplayMenu();

                                        }
                                    }

                                }
                                if (SelectUserItems[SelectedItem].Option=="Edit Modules")
                                {
                                    int select;
                                    try
                                    {
                                        Console.WriteLine("Enter your Id : ");

                                        select = Convert.ToInt32(Console.ReadLine());




                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                                        select = -1;
                                    }

                                    if (select == -1)
                                    {
                                        Console.Clear();
                                        DisplayMenu();
                                    }
                                    int selectm;
                                    try
                                    {
                                        Console.WriteLine("Enter your Module Id : ");

                                        selectm = Convert.ToInt32(Console.ReadLine());




                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                                        selectm = -1;
                                    }

                                    if (selectm == -1)
                                    {
                                        Console.Clear();
                                        DisplayMenu();
                                    }
                                    if (select<users.Count) {
                                        Console.Write("Enter New Module : ");
                                        users[select].UserModules[selectm].ModuleName = Console.ReadLine();
                                        users[select].UserModules[selectm].CodeNumber = selectm;
                                        Console.Write("Enter New Module Grade : ");

                                        string nG=users[select].UserModules[selectm].gradeCode = Console.ReadLine();
                                        while(nG!="A" && nG != "B" && nG != "C"&& nG != "D" && nG != "E")
                                        {
                                            Console.WriteLine("Yoy enter wrong grade");
                                            nG = Console.ReadLine();
                                        }


                                    }


                                }


                                if (SelectUserItems[SelectedItem].Option == "Back")
                                {
                                    Console.Clear();

                                    DisplayMenu();
                                    run = false;


                                }


                            }

                        }
                    }

                    if (MenuItems[SelectedItem].Title == "Delete User")
                    {
                        Console.Clear();
                        Console.SetCursorPosition(2, 2);
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!      Do you want to Delete     !!!!!!!!!!!!!!!!");
                        Console.SetCursorPosition(2, 6);
                        Console.WriteLine("If yes please press enter");
                        var keyNote = Console.ReadKey();
                        if (keyNote.Key == ConsoleKey.Enter)
                        {



                            //Console.Clear();
                            int select;
                            try
                            {
                                Console.WriteLine("Enter your Id : ");

                                select = Convert.ToInt32(Console.ReadLine());
                                

                                
                                
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                                select = -1;
                            }
                            Console.Clear();
                            Console.SetCursorPosition(2, 2);
                            
                            
                            Console.WriteLine("Enter Your Password : ");
                            string selectPassword = Console.ReadLine();

                            Console.Clear();
                            if (select == -1)
                            {
                                Console.WriteLine("Invalid Id");
                                Console.WriteLine("You cannot delete");
                                Console.ReadKey(true);
                                Console.Clear();
                                
                               DisplayMenu();
                            }
                            

                            if (select < users.Count && select >= 0 )
                            {
                                if (selectPassword == users[select].Password)
                                {
                                    users.RemoveAt(select);
                                    Console.Clear();

                                }
                                else
                                {
                                    Console.Clear();
                                    DisplayMenu();

                                }
                            }
                            else
                            {
                                Console.Clear();
                                DisplayMenu();
                            }
                        }
                        else
                        {
                            Console.Clear() ;
                            DisplayMenu();
                        }
                    
                }

                    if (MenuItems[SelectedItem].Title == "Quit")
                    {
                        Console.Clear();
                        running = false;



                    }
                }
            }
        }
    }
}
