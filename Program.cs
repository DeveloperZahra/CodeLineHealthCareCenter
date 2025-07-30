namespace CodeLineHealthCareCenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static void ShowWelcomeScreen()
        {
            // while loop to display wellcome screen every true value untill user enter 0 value to exist from loop 
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==================================");
                Console.WriteLine("  🌟 Welcome to Hospital System 🌟   ");
                Console.WriteLine("==================================");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("0. Exit");
                Console.WriteLine("----------------------------------");
                Console.Write("Enter your choice: ");

                // switch condition to control user movemenet 
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        SignUp();
                        break;
                    case '2':
                        SignIn();
                        break;
                    case '0':
                        Console.WriteLine("Thank you for using the system!");
                        return;
                    default:
                        //ShowError("Invalid choice! Please try again.");
                        break;
                }

            }
        }

        // create Sign Up class
        static void SignUp() 
        
        { 
            Console.WriteLine("Wellcome To SignUp....");
        }

        // Create Sign In Class
        static void SignIn()
        {
            Console.WriteLine("Wellcome To SignIn....");
        }

       
    }
}
