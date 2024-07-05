using DungeonGameLogic.Enums;
using DungeonGameSimulator;
using DungeonGameSimulator.Utilities;
using Spectre.Console;

internal class Program
{
    private static void Main(string[] args)
    {

        TestGameConsole();

        //DisplayStartPage();

        //while (true)
        //{
        //    var key = Console.ReadKey(true);
        //    if (key.Key == ConsoleKey.Enter)
        //    {
        //        RunSimulation();
        //        break;
        //    }
        //}

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

    static void TestGameConsole()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        GameConsole.Initialize();
        GameConsole.TestEmojiSupport();
        GameConsole.LogBattleStart();

        GameConsole.LogAction("A Mighty dragon appears.", LogType.Enemy, Emoji.Known.Dragon);
        GameConsole.LogAction("The brave warrior draws his sword.", LogType.Friendly, Emoji.Known.Dagger);
        GameConsole.LogAction("The White Mage prepares a powerful spell.", LogType.Friendly, Emoji.Known.Sparkles);

        GameConsole.DisplayCharacterStats("Warrior", 5, 100, 0);
        GameConsole.DisplayCharacterStats("White Mage", 5, 80, 100);
        GameConsole.DisplayCharacterStats("Dragon", 8, 150, 50);

        GameConsole.LogAction("Warrior attacks the dragon!", LogType.Friendly, Emoji.Known.CrossedSwords);
        GameConsole.LogAction("Critical hit! The dragon takes massive damage!", LogType.Critical, Emoji.Known.Collision);
        GameConsole.LogAction("The dragon breaths fire!", LogType.Enemy, Emoji.Known.Fire);
        GameConsole.LogAction("The White Mage casts a healing spell on the warrior.", LogType.Healing, Emoji.Known.SparklingHeart);

        GameConsole.LogBattleEnd("The dragon flies away. The Warrior and the White Mage celebrate.");
    }
}
