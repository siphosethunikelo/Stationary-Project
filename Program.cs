using System.Text.RegularExpressions;

namespace BootingBytesStationeryProject
{
    public  class Program
    {
        static void Main(string[] args)
        {


            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();    
            Console.WriteLine("******************************************************************************");
            Console.WriteLine(String.Format("{0,50}", "Lewis store Stationery Request Form".ToUpper()));
            Console.WriteLine(String.Format("{0,62}", "Office Location: 53 Victoria Rd, Woodstock, Cape Town, 7925") + "\n" + String.Format("{0,49}", "Company Secretary: (021) 460 4400 "));
            Console.WriteLine("******************************************************************************\n");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Hello, Please indicate whether you are the Manager or an employee by selecting \n1) for a Manager\n2) for an Employee");
            var access = int.Parse(Console.ReadLine());

             var UpperName = "";
           
            switch (access)
            {
                case 1:
                    string username,userName, password;
                    int create = 0;
                   

                    Console.WriteLine("Please enter the following details ");
                    bool AreaName = true;
                    var name = "";
                    while (AreaName)
                    {
                        Console.Write("Your name: ");
                       var  AreaM = Console.ReadLine();

                        Regex AM = new Regex(@"[A-Za-z]");
                        bool IsValidAm = AM.IsMatch(AreaM);

                        if (IsValidAm)
                        {
                            AreaName = false;
                        }
                        else
                        {
                            Console.Write("Invalid Input");
                        }

                        name = AreaM;
                    }

                    var id = "";
                    bool sa_Id = true;
                
                    while (sa_Id)
                    {
                        string SAiD;
                        Console.WriteLine("Your ID number");
                        SAiD = Console.ReadLine();
                        Regex regex = new Regex("[0-9]{5}(?:-[0-9]{4})?");
                        bool isValidID = regex.IsMatch(SAiD);
                        if (isValidID && SAiD.Length == 13)
                        {
                            sa_Id = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID number. Please try again");
                        }

                      id = SAiD;
                    }
                    Console.WriteLine();
                    // Substring to capitalize the first char of the name
                    var Name = name.Substring(0, 1);
                    Name = Name.ToUpper();
                    var endName = name.Substring(1);
                    endName = endName.ToLower();
                    UpperName = Name + endName;
                    

                    // Substring to get unique username
                    var nme = name.Substring(0, 3); 
                    nme = nme.ToUpper();
                    var ID = id.Substring(0, 2);
                    username = nme + ID;

                    Console.WriteLine($"{UpperName} this is your unique username {username} please don't share it with anyone\nYou will need to enter it with your password that you still need to create\nin order to gain access to the stationery List.");
               
                    Console.Write("\n\nThe System will run for correct username and password :\nYou have three login attempts\n"); 
                    Console.Write("------------------------------------------------------\n");
                    var validPass = " ";
                    var Password = true;
                    while (Password)
                    {
                        Console.WriteLine("Create a password in order to login.\nYour password should contain the following:\n\nMinimum 8 characters in length.\nAt least on upper English Letter\nAt least one lowercase English letter\nAt least one digit\nAt least one special character");
                        var passw = Console.ReadLine();
                        Console.WriteLine();

                        Regex passwordChecker = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
                        bool isValidPassword = passwordChecker.IsMatch(passw);

                        if (isValidPassword)
                        {
                            Console.WriteLine("Password meets the requirements\nNow that you've successfully created your password\nLet's login into the system");
                            Password = false;
                        }
                        else
                        {
                            Console.WriteLine("Password does not meet the requirements! Please try again");

                        }

                        validPass = passw;
                    }

                    
                   
                    var left = 3;
                    do // do while loop starting
                    {
                        Console.Write("Please enter your unique username: "); // User enters their username
                         userName = Console.ReadLine();
                        Console.Write("Please enter your password that you created: "); //User enters their password
                        password = Console.ReadLine();
                        Console.WriteLine();


                        if (username != userName || password != validPass) // Username & password generated here > NB!! > if we had a database our passwords wouldve been ABLE to store in there making our system secure
                        {
                            create++;

                            left--;
                            Console.WriteLine($"{UpperName} the username and password you have entered was invalid\nPlease try again");
                            Console.WriteLine($"Attempts left: {left}");
                        }
                        else
                        {

                            create = 1;

                        }

                    }
                    while ((username != userName || password != validPass) && (create != 3)); //   create(created my own variable > how many times our password will run



                    if (create == 3) //When user runs wrong password 3 times and attempt fails
                    {
                        Console.Write("\nLogin attempt three or more times. Try later!\n\n");
                        Console.Clear();
                        Console.WriteLine("Login attempt failed . Try again next time");
                        Console.WriteLine("\nYou tried to logged in at");
                        DateTime now1= DateTime.Now;
                        Console.WriteLine(now1.ToString("F"));  // DATE & TIME USERS LAST ATTEMPT LOGGING IN
                                                               // With the Now property of the DateTime, we get the current date and time in local time
                                                               //With the ToString method, we format the date. The F specifier creates a full date and time pattern.



                        Environment.Exit(0); // Closes the console (exit the program)
                    }



                    else
                    {

                        Console.WriteLine($"\n{UpperName} the password and username you have entered was correct!\n");

                        //***********Password section ends*************************//
                    }
                    break;
                case 2:
                    Console.WriteLine("Access denied\nOnly managers are allowed to have access when ordering stationery");
                    DateTime now = DateTime.Now;
                    Console.WriteLine(now.ToString("F"));
                    Environment.Exit(0);
                    break;


                   
            }
            Console.WriteLine(String.Format("{0,40}", "Branch Details".ToUpper()));
            Console.WriteLine(String.Format("{0,45}", "The Different Regions\n".ToUpper()));

            Console.WriteLine("******************************************************************************\n");
            //////////////////////////////////////////////////////////////////////////////////////  DISPLAYING THE DIFFERENT REGIONS ///////////////////////////////////////////////////////////////////////////

            List<string> regions = new List<string>
            {
                null,
                "City of Cape Town",
                "Cape Winelands Region",
                "Central Karoo Region",
                "Garden Route Region ",
                "Overberg Region",
                "West Coast Region"
            };



            for (int i = 1; i < regions.Count; i++)
            {
                Console.WriteLine("{0}) " + regions[i], i);

            }

            Console.Write("Please Select Region (1 to 6) from the above list: ");
            var districtSelect = Console.ReadLine();

            int selector;

            while (!int.TryParse(districtSelect, out selector))
            {
                Console.Write("Invalid number please enter a number and not a text: ");
                districtSelect = Console.ReadLine();
            }

            int intDistrict = Int32.Parse(districtSelect);

            var disValue = true;

            while (disValue)
            {
                if (intDistrict < regions.Count && !(intDistrict < 0))
                {
                    disValue = false;
                }
                else
                {
                    try
                    {
                        Console.Write("Please enter a number between 1 and 6: ");
                        districtSelect = Console.ReadLine();
                        intDistrict = Int32.Parse(districtSelect);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error occured {0}", e.Message);
                    }
                }
            }
            intDistrict = Int32.Parse(districtSelect);

            var store = "";
            var correctStore = true;
            while (correctStore)
            {
                Console.Write($"Enter the name of your branch in {regions[intDistrict]}: ");
                var store1 = Console.ReadLine();

                Regex LewisStore = new Regex(@"[A-Za-z]");
                bool isValidStore = LewisStore.IsMatch(store1);

                if (isValidStore)
                {
                    correctStore = false;
                }
                else
                {
                    Console.WriteLine("Invalid input please try again!");
                }

                store = store1;
            }
            

            // substring first char of Store
            var Store = store.Substring(0, 1);
            Store = Store.ToUpper();
            var LastChar = store.Substring(1);
            var Upperstore = Store + LastChar;

            /////////////////////////////////////////////////// END OF GETTING REIGION DATA //////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////// GETTING MANAGERS EMAIL ADDRESS ////////////////////////////////////////////////////////

            var Email = " ";
            var repeat = true;
            while (repeat)
            {
                string email;
                Console.Write("Please enter a valid email (someone@gmail.com): ");
                email = Console.ReadLine();



                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);

                if (match.Success)
                {
                    repeat = false;
                }
                else
                {
                    Console.WriteLine("Invalid email entered please try again");
                }

                Email = email;
            }

            /////////////////////////////////////////////////  END OF GETTING MANAGERS EMAIL ADDRESS ////////////////////////////////////////////////////////

            ///////////////////////////////////////////////// GETTING CELLPHONE NUMBER ////////////////////////////////////////////////////////


            bool num = true;
            var cNum = "";
            while (num)
            {
                string cellNum;
                Console.Write("Please enter a 10 digit phone number that starts with {0}: ");
                cellNum = Console.ReadLine();

                Regex cellNumChecker = new Regex(@"^[0-9]{10}$");
                bool isValidNum = cellNumChecker.IsMatch(cellNum);

                if (isValidNum && cellNum[0] == '0')
                {
                    num = false;
                }
                else
                {
                    Console.WriteLine("Phone number entered is invalid please try again.");
                    
                }

                cNum = cellNum;
            }

            ///////////////////////////////////////////////// END OF GETTING CELLPHONE  NUMBER////////////////////////////////////////////////////////
            Console.WriteLine("******************************************************************************\n");
            //////////////////////////////////////////////// STATIONERY LIST BEING DISPLAYED //////////////////////////////////////////////////////////////
            Console.WriteLine(String.Format("{0,40}", "Stationery List".ToUpper()));
            List<string> Stationery = new List<string>
            {
                null,"Pens","Notebooks & Notepads","Brochures","Filing","Staplers & Hole Punchers","Copy Paper",
                "Adhesive Rippa Label","Pricing & Office Labels","Stamps","Tape"
            };

            Console.WriteLine();
            for (int i = 1; i < Stationery.Count; i++)
            {
                Console.WriteLine("{0}) " + Stationery[i], i);
            }
            List<string> items = new List<string>();
            List<double> quanT = new List<double>();


            string input = "yes";
            while (input == "Yes" || input == "YES" || input == "yes")
            {


                try
                {
                    Console.Write("Select a number 1 to 10 from the above stationery list: ");
                    int Item = Convert.ToInt32(Console.ReadLine());


                    if (items.Contains(Stationery[Item]))
                    {
                        Console.WriteLine("Sorry, but you have already selected this item.\nPlease select another item");
                    }
                    else
                    {
                        items.Add(Stationery[Item]);
                        var REPEAT = true;
                        while (REPEAT)
                        {
                            try
                            {
                                Console.Write($"How many {Stationery[Item]} are you ordering: ");
                                var qty = Double.Parse(Console.ReadLine());
                                if (qty < 0)
                                {
                                    Console.WriteLine("Number entered is invalid please try again ");
                                }
                                else
                                {
                                    quanT.Add(qty);
                                    REPEAT = false;
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("{0}", e.Message);
                            }
                        }

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.Write("Do you want to continue adding items Yes or No: ");
                    input = Console.ReadLine();
                    Console.WriteLine("\n");
                }
            }

            //////////////////////////////////////////////// END OF STATIONERY LIST BEING DISPLAYED //////////////////////////////////////////////////////////////
            Console.WriteLine("******************************************************************************\n");
            var quant = quanT.Sum(x => x);

            List<string> results = new List<string> { regions[intDistrict], Upperstore, UpperName, cNum,  Email };


            List<string> list = new List<string>
            {
                "Region",
                "Branch Location",
                "Store Number",
                "Area Manager",
                "Store Email"
            };
            var storeDets = new System.Text.StringBuilder();


            for (int index = 0; index < results.Count; index++)
            {
                storeDets.AppendLine(String.Format("{0,-20}{1,45}", list[index], results[index]));
            }

            var Tot = new System.Text.StringBuilder();
            Tot.Append(String.Format("{0,-35}{1,30}\n", "Item", "Quantity"));
            for (int index = 0; index < quanT.Count; index++)
            {
                Tot.Append(String.Format("{0,-35}{1,28}\n", items[index], quanT[index]));
            }

            //////////////////////////////////////////////////////////// PREVIEW YOUR ORDER //////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine(String.Format("{0,41}", "A Preview of your Order".ToUpper()));
            Console.WriteLine(Tot);
            Console.WriteLine(String.Format("{0,-35}{1,28}", "Total Quantity", quant));
            Console.WriteLine();
            int Checkout =0;

            var preview = true;

            while (preview)
            {
                try
                {
                    Console.WriteLine("Would you like to proceed to check out Enter\n1) to checkout \n2) to add more itmes\n3) to cancel your order:  ");
                    Checkout = Convert.ToInt32(Console.ReadLine());
                    if (Checkout > 0 && Checkout <=3)
                    {
                       preview = false;
                    }
                    else
                    {
                        Console.WriteLine("Please select a number between 1 and 3");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error occured {0}", ex.Message);
                }
            }

            switch (Checkout)
            {
                case 1:
                    DateTime dateTime = DateTime.Now;
                    Console.WriteLine("******************************************************************************\n");
                    Console.WriteLine(String.Format("{0,37}", "Store Details".ToUpper()));
                    Console.WriteLine(storeDets);
                    Console.WriteLine(String.Format("{0,40}", "Stationery Details".ToUpper()));
                    Console.WriteLine(Tot);
                    Console.WriteLine(String.Format("{0,-35}{1,28}", "Total Quantity", quant));
                    Console.WriteLine(String.Format("{0,-35}{1,32}", "Date and Time", dateTime));
                    Console.WriteLine();
                    Console.WriteLine("Please press enter to process your order");
                    Console.Read();
                    Console.WriteLine($"Thank you {UpperName}, for using our service. \nYour order is being processed");
                    break;
                case 2:

                    Console.WriteLine();
                    for (int i = 1; i < Stationery.Count; i++)
                    {
                        Console.WriteLine("{0}) " + Stationery[i], i);
                    }

                    string userInput = "yes";
                    while (userInput == "yes" || userInput == "Yes" || userInput == "YES")
                    {


                        try
                        {
                            Console.WriteLine("Select a number 1 to 10 from the above stationery list: ");
                            int Item = Convert.ToInt32(Console.ReadLine());


                            if (items.Contains(Stationery[Item]))
                            {
                                Console.WriteLine("Sorry, but you've already selected this item.\nPlease select another item");
                            }
                            else
                            {
                                items.Add(Stationery[Item]);
                                var REPEAT = true;
                                while (REPEAT)
                                {
                                    try
                                    {
                                        Console.Write($"How many {Stationery[Item]} are you ordering: ");
                                        var qty = Double.Parse(Console.ReadLine());
                                        if (qty < 0)
                                        {
                                            Console.WriteLine("Number entered is invalid please try again ");
                                        }
                                        else
                                        {
                                            quanT.Add(qty);
                                            REPEAT = false;
                                        }

                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("{0}", e.Message);
                                    }
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {

                            Console.Write("Do you want to continue adding items Yes or No: ");
                            userInput = Console.ReadLine();
                        }
                    }

                    var UpdateTot = new System.Text.StringBuilder();
                    UpdateTot.Append(String.Format("{0,-35}{1,30}\n", "Item", "Quantity"));
                    for (int index = 0; index < quanT.Count; index++)
                    {
                        UpdateTot.Append(String.Format("{0,-35}{1,28}\n", items[index], quanT[index]));
                    }
                    quant = quanT.Sum(x => x);
                    DateTime dateTime1 = DateTime.Now;
                    Console.WriteLine("******************************************************************************\n");
                    Console.WriteLine(String.Format("{0,37}", "Store Details".ToUpper()));
                    Console.WriteLine(storeDets);
                    Console.WriteLine(String.Format("{0,40}", "Stationery Details".ToUpper()));
                    Console.WriteLine(UpdateTot);
                    Console.WriteLine(String.Format("{0,-35}{1,28}", "Total Quantity", quant));
                    Console.WriteLine(String.Format("{0,-35}{1,32}", "Date and Time", dateTime1));
                    Console.WriteLine();
                    Console.WriteLine("Please press enter to process your order");
                    Console.Read();
                    Console.WriteLine($"Thank you {UpperName}, for using our service. \nyour order is being processed");
                   

                    break;

                case 3:
                    dateTime1 = DateTime.Now;
                    Console.WriteLine("You cancelled your order on");
                    Console.WriteLine(dateTime1.ToString("F"));
                    Environment.Exit(0);
                    break;



            }

        }
    }
}