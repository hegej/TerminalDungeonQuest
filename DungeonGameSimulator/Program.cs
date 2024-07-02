using DungeonGameLogic.Enums;
using DungeonGameSimulator;

internal class Program
{
    private static void Main(string[] args)
    {

        DisplayStartPage();

        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                RunSimulation();
                break;
            }
        }

    }

    private static void DisplayStartPage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"

                                           ..::.                                              
                                        .....:::...                                           
                                       ......::::::.                                          
                                     ........-------..                                        
                                    .......:++=------..                                       
                                   ......=#%%%%#+====-...                                     
                                  ....-*%%%%%%%%%%#*+=-:...                                   
                                 ..-#%%%%%%%###%#%%%%%%#-::.:                                 
                               ...=#%%##+#**#**#%#%%%%%%%#**+=                                
                               ..-#****+**+==+**%@%%%%%%%%%#*+                                
                              .-*###**++#@#-=+*#%%%#%%%%%%%%%#+                               
                              :*###%#%#==+++=+**####%%%%@@%%%%#                               
                              :####%%@@#-----=+++**#@%%@@@##%##                               
                               +=##%%%@@%#=---++*%@@@@@@@%%+*#*                               
                              =--+*##%%@@@@@%##*%@@@@@%%%%%*##+                               
                             -==*#*#%%@*-:--=+**#%#+#@@@%%%#*#                                
                              =--**#%%+:.:::--=+****++*@%%%%%+-                               
                             --+++*##*:.:=-::-==#%#*++*%%%%%@%#                               
                           -   +++=+=:.:=--:.:=+####+=+*#%%%%%#                               
                            -=+=++-....-=-=--:++*###*++*++*##                                 
                              -==....=+=+***++########*#*+++-:                                
                               ...-=+***%%%#**##%%%%%%#%###**+=-                              
                              ...::===*#%#=:+*######%%*####*****+=                            
                             ...:-:++++#*-:-**##**###%#=####*****+*#*                         
                             ..:===***#*-:-***##+***#%%*=#######%%%%#                         
                            .:==+=+++**-:-**#*##+***#%%#=+= *####%%%#+                        
                       ++***=*====:-*+-::**#####+##*#%%%+++=    %%%%%*                        
                    ==+****       .++-:..+**#%#**#*#*#%%*++++                                 
              ===+*###**         .--:::..-+**##**##**#%##+**++=                               
        ====+*##**             ....:::..:=++++*+*#****#*#****++=                              
      +=######                 ....::...:=++++++******#*******+++                             
       -+###                 .....::....-++**+++******#*******++*+                            
         *                  .....--:...:=+***+++*******#*******++**                           
                           ....:---:...:=+***++********##*******+**+                          
                           ..-==+=:...:-++***+**#%%###%%%#*******+**                          
                           ..-=++==-=++=+******####**##%%%#*******+                           
                             =-:.=+=*####*****##*##+*##%#%%##******                           
                              .+**++*+*########**##+*##%##%###*                               
                                   +**#%@@@%%#######%%%%%*                                    
                                      #%@@@%       %@@@@%                                     
                                      *%%@@%       %@@@@@@%                                   
                                      #*#%%%       %@@@@@@%%         

                        \    / |_  o _|_  _     |\/|  _.  _   _     ._  ._ _   _  _  ._ _|_  _ o
                         \/\/  | | |  |_ (/_    |  | (_| (_| (/_    |_) | (/_ _> (/_ | | |_ _> o
                                                          _|        |             

             ________                                             ________                          __   
             \______ \  __ __  ____    ____   ____  ____   ____   \_____  \  __ __   ____   _______/  |_ 
              |    |  \|  |  \/    \  / ___\_/ __ \/  _ \ /    \   /  / \  \|  |  \_/ __ \ /  ___/\   __\
              |    `   \  |  /   |  \/ /_/  >  ___(  <_> )   |  \ /   \_/.  \  |  /\  ___/ \___ \  |  |  
             /_______  /____/|___|  /\___  / \___  >____/|___|  / \_____\ \_/____/  \___  >____  > |__|  
                     \/           \//_____/      \/           \/         \__>           \/     \/     
                                                              
");
        Console.ResetColor();
        Console.WriteLine("\nPress Enter to start the game simulation");
        Console.WriteLine("\nPress 'CTRL+C' to quit");
    }

    private static void RunSimulation()
    {
        Console.Clear();
        SimulationSpeed speed = GetSimulationSpeed();
        var simulator = new BattleSimulator();
        simulator.RunSimulation(speed: speed);

        Console.WriteLine("Simulation complete. Logs saved to battle_logs.json");

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }

    private static SimulationSpeed GetSimulationSpeed()
    {
        while (true)
        {
            Console.WriteLine("Select Simulation speed:");
            Console.WriteLine("1. Fast (0.1 seconds per action)");
            Console.WriteLine("2. Slow (0.5 secons per action)");
            Console.WriteLine("3. Manual (press Enter for each action)");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1: return SimulationSpeed.Fast;
                    case 2: return SimulationSpeed.Slow;
                    case 3: return SimulationSpeed.Manual;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }

            else
            {
                Console.WriteLine("Invalid input. Enter a number (1-3).");
            }
        }
    }
}
