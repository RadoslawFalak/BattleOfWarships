using BattleOfWarships.Domain;
using BattleOfWarships;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace WarshipCombat
{
    internal class GamePlay
    {
        //Klasa enum dla pierwszej współrzędnej którą wprowdzi użytkownik, czyli wiersze oznaczone A-J
        public enum FirstCoordinate
        {
            A = 1,
            a = 1,
            B, b = 2,
            C, c = 3,
            D, d = 4,
            E, e = 5,
            F, f = 6,
            G, g = 7,
            H, h = 8,
            I, i = 9,
            J, j = 10,
        }

        //Mechanika gry dla jednego gracza
        public static void OnePlayerGame()
        {
            int firstCoordinate;
            int secondCoordinate;
            int timeInSeconds = 0;
            int points = 0;
            int score = 0;
            int moves = 0;
            int destroyedShips = 0;
            int ship5 = 0, ship4 = 0, ship3 = 0, ship2 = 0, ship1 = 0;
            string input;
            string[] lettersTest = new string[10] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };// Tablica dla sprzwdzenia czy użytkonik napewno wprowadził literę jako pierwszą współrzędną
            Console.Clear();
            GameBoard.ClearingTheBoard(GameBoard.playerGameBoard);
            GameBoard.ClearingTheBoard(GameBoard.gameBoard);
            //Dodawanie wszystkich okrętów do planszy gry
            ShipDraw.FiveFlagships(GameBoard.gameBoard);
            ShipDraw.FourFlagships(GameBoard.gameBoard);
            ShipDraw.ThreeFlagships(GameBoard.gameBoard);
            ShipDraw.TwoFlagships(GameBoard.gameBoard);
            ShipDraw.TwoFlagshipsSecond(GameBoard.gameBoard);

            var playerOne = new Players();
            Console.Write("Enter the name of the player: ");
            playerOne.Name = Console.ReadLine();
            Console.Clear();
            DateTime startTime = DateTime.Now; // Czas startu programu

            while (score != 16) // 16 puntów czyli łączna ilość trafień za wszystkie okręty 
            {
                string soundFilePath = "cannon-shot-14799.mp3"; //dzwięk wystrzału
                using (var audioFile = new Mp3FileReader(soundFilePath)) // mp3 player
                using (var outputDevice = new WaveOutEvent())
                {
                    Console.WriteLine($"Game time: {(DateTime.Now - startTime):hh\\:mm\\:ss}"); // Wyświetlanie licznika czasu
                    Console.WriteLine($"Player: {playerOne.Name}");
                    GameBoard.PrintArray(GameBoard.playerGameBoard);//Drukuje planszę którą widzi gracz
                    Console.WriteLine($"You destroyed {destroyedShips} of 5 ships");
                    Console.WriteLine($"Number of shots: {moves}");
                    Console.WriteLine("Enter the attack coordinate");
                    Console.Write("Enter the first coordinate from A to J: ");
                    input = Console.ReadLine().ToUpper();
                    int stop = 2;
                    if (input == "EXIT")
                    {
                        Menu.MainMenu();
                    }
                    while (stop != 1) //Sprawdza czy podana współrzędna mieści się w zakresie liter
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (input == lettersTest[i])
                            {
                                stop = 1;
                            }
                        }
                        if (stop != 1)
                        {
                            Console.WriteLine("Incorrect coordinate! \r\nEnter the first coordinate from A to J:");
                            input = Console.ReadLine().ToUpper();
                        }
                    }
                    Enum.TryParse(input, out FirstCoordinate letter);// Pobiera dane z klasy enum
                    firstCoordinate = (int)letter;// podaje litere z klasy enum jako liczbe która jest jej przypisana 
                    Console.Write("Enter the second coordinate from 1 to 10: ");
                    string input2 = Console.ReadLine();

                    for ( ; ; )
                    {
                        if (int.TryParse(input2, out secondCoordinate))//sprawdza czy podana wartość jest int-em
                        {
                            if (secondCoordinate >= 1 && secondCoordinate <= 10) // sprawdza czy wartość jest z zakresu 1-10
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect coordinate! \r\nEnter the second coordinate from 1 to 10:");
                                input2 = Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect coordinate! \r\nEnter the second coordinate from 1 to 10:");
                            input2 = Console.ReadLine();
                        }
                    }
                    // Sprawdza czy strzał jest celny na tablicy przeciwnika i czy już wcześniej nie padło to samo miejsce
                    if (GameBoard.playerGameBoard[secondCoordinate, firstCoordinate] != " S" 
                        && GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 5" 
                        || GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 4"
                        || GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 3" 
                        || GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 2"
                        || GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 1")
                    {
                        GameBoard.playerGameBoard[secondCoordinate, firstCoordinate] = " S"; //przypisuje trafienie
                        outputDevice.Init(audioFile);
                        outputDevice.Play();// uruchamia dzwięk wystrzału
                        Console.WriteLine("You hit the ship!");
                        score += 1; // zwiększa ilość punktów
                        moves += 1; // zwiększa liczbę ruchów
                        Thread.Sleep(1000); // robi pauze żeby odtworzył się cały dzwięk
                        if (GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 5")
                        {
                            ship5 += 1;
                            if (ship5 == 5)
                            {
                                destroyedShips += 1;
                                Console.WriteLine("Congratulations ! You sank a five-masted ship.\r\nPress any key !");
                                Console.ReadKey();
                            }
                        }
                        else if (GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 4")
                        {
                            ship4 += 1;
                            if (ship4 == 4)
                            {
                                destroyedShips += 1;
                                Console.WriteLine($"Congratulations ! You sank a four-masted ship.\r\nPress any key !");
                                Console.ReadKey();
                            }
                        }
                        else if (GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 3")
                        {
                            ship3 += 1;
                            if (ship3 == 3)
                            {
                                destroyedShips += 1;
                                Console.WriteLine("Congratulations ! You sank a three-masted ship.\r\nPress any key !");
                                Console.ReadKey();
                            }
                        }
                        else if (GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 2")
                        {
                            ship2 += 1;
                            if (ship2 == 2)
                            {
                                destroyedShips += 1;
                                Console.WriteLine("Congratulations ! You sank a two-masted ship.\r\nPress any key !");
                                Console.ReadKey();
                            }
                        }
                        else if (GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 1")
                        {
                            ship1 += 1;
                            if (ship1 == 2)
                            {
                                destroyedShips += 1;
                                Console.WriteLine("Congratulations ! You sank a two-masted ship.\r\nPress any key !");
                                Console.ReadKey();
                            }
                        }
                    }
                    else if (GameBoard.playerGameBoard[secondCoordinate, firstCoordinate] == " S" || GameBoard.playerGameBoard[secondCoordinate, firstCoordinate] == " O") // Sprzwdza czy podane wzpółrzędne już się powtórzyły
                    {
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                        Console.WriteLine("You've shot at this place before! Please choose another.");
                        moves += 1;
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        GameBoard.playerGameBoard[secondCoordinate, firstCoordinate] = " O"; // Przypisuje chybiony strzał na tablicy gracza
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                        Console.WriteLine("You missed!");
                        moves += 1;
                        Thread.Sleep(1000);
                    }
                    Console.Clear();
                }
            }
            TimeSpan differenceTime = DateTime.Now - startTime; // Czas gry
            timeInSeconds = (int)differenceTime.TotalSeconds; // czas gry w sekundach int

            points = ScoreCalculation.Calculation(moves, timeInSeconds);
            TopTenList.AddResultToTopTenList(playerOne.Name, ScoreCalculation.Calculation(moves, points));
            TopTenList.SortTopTenList();
            Console.WriteLine($"Congratulations on destroying all the ships, you win in {moves} moves.");
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            Menu.MainMenu();
        }

        //Mechanika gry - gracz vs gracz
        public static void PlayerVSPlayer()
        {
            bool gamePlay = true;
            int winerrMoves = 0;
            string winerrName = "Gamer";
            int playerOneMoves = 0;
            int playerTwoMoves = 0;
            int firstCoordinate;
            int secondCoordinate;
            int timeInSeconds = 0;
            //int points = 0;
            int destroyedShipsP1 = 0;
            int destroyedShipsP2 = 0;
            int ship5P1 = 0, ship4P1 = 0, ship3P1 = 0, ship2P1 = 0, ship1P1 = 0;
            int ship5P2 = 0, ship4P2 = 0, ship3P2 = 0, ship2P2 = 0, ship1P2 = 0;
            string input;
            string[] lettersTest = new string[10] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };// Tablica dla sprzwdzenia czy użytkonik napewno wprowadził literę jako pierwszą współrzędną
            Console.Clear();
            GameBoard.ClearingTheBoard(GameBoard.playerGameBoard);
            GameBoard.ClearingTheBoard(GameBoard.gameBoard);
            GameBoard.ClearingTheBoard(GameBoard.player2GameBoard);
            GameBoard.ClearingTheBoard(GameBoard.gameBoard2);

            //Dodawanie wszystkich okrętów do planszy gry pierwszego gracza
            ShipDraw.FiveFlagships(GameBoard.gameBoard);
            ShipDraw.FourFlagships(GameBoard.gameBoard);
            ShipDraw.ThreeFlagships(GameBoard.gameBoard);
            ShipDraw.TwoFlagships(GameBoard.gameBoard);
            ShipDraw.TwoFlagshipsSecond(GameBoard.gameBoard);
            //Dodawanie wszystkich okrętów do planszy gry drugiego gracza
            ShipDraw.FiveFlagships(GameBoard.gameBoard2);
            ShipDraw.FourFlagships(GameBoard.gameBoard2);
            ShipDraw.ThreeFlagships(GameBoard.gameBoard2);
            ShipDraw.TwoFlagships(GameBoard.gameBoard2);
            ShipDraw.TwoFlagshipsSecond(GameBoard.gameBoard2);  

            var playerOne = new Players();
            Console.Write("Enter the name of the player 1: ");
            playerOne.Name = Console.ReadLine();
            Console.Clear();
            var playerTwo = new Players();
            Console.Write("Enter the name of the player 2: ");
            playerTwo.Name = Console.ReadLine();
            Console.Clear();
            DateTime startTime = DateTime.Now; // Czas startu programu
            int playerOnePoints = 0;
            int playerTwoPoints = 0;
            while(gamePlay)
            {   
                //First player
                while (true)
                {
                    string soundFilePath = "cannon-shot-14799.mp3"; //dzwięk wystrzału
                    using (var audioFile = new Mp3FileReader(soundFilePath)) // mp3 player
                    using (var outputDevice = new WaveOutEvent())
                    {
                        Console.Clear();
                        Console.WriteLine($"Game time: {(DateTime.Now - startTime):hh\\:mm\\:ss}"); // Wyświetlanie licznika czasu
                        Console.WriteLine($"Player: {playerOne.Name}");
                        GameBoard.PrintArray(GameBoard.playerGameBoard);//Drukuje planszę którą widzi gracz
                        Console.WriteLine($"You destroyed {destroyedShipsP1} of 5 ships");
                        Console.WriteLine($"Number of shots: {playerOneMoves}");
                        Console.WriteLine("Enter the attack coordinate");
                        Console.Write("Enter the first coordinate from A to J: ");
                        input = Console.ReadLine().ToUpper();
                        int stop = 2;
                        if (input == "EXIT")
                        {
                            Menu.MainMenu();
                        }
                        while (stop != 1) //Sprawdza czy podana współrzędna mieści się w zakresie liter
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                if (input == lettersTest[i])
                                {
                                    stop = 1;
                                }
                            }
                            if (stop != 1)
                            {
                                Console.WriteLine("Incorrect coordinate! \r\nEnter the first coordinate from A to J:");
                                input = Console.ReadLine().ToUpper();
                            }
                        }
                        Enum.TryParse(input, out FirstCoordinate letter);// Pobiera dane z klasy enum
                        firstCoordinate = (int)letter;// podaje litere z klasy enum jako liczbe która jest jej przypisana 
                        Console.Write("Enter the second coordinate from 1 to 10: ");
                        string input2 = Console.ReadLine();

                        for (; ; )
                        {
                            if (int.TryParse(input2, out secondCoordinate))//sprawdza czy podana wartość jest int-em
                            {
                                if (secondCoordinate >= 1 && secondCoordinate <= 10) // sprawdza czy wartość jest z zakresu 1-10
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect coordinate! \r\nEnter the second coordinate from 1 to 10:");
                                    input2 = Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Incorrect coordinate! \r\nEnter the second coordinate from 1 to 10:");
                                input2 = Console.ReadLine();
                            }
                        }
                        if (GameBoard.playerGameBoard[secondCoordinate, firstCoordinate] == " S" || GameBoard.playerGameBoard[secondCoordinate, firstCoordinate] == " O") // Sprzwdza czy podane wzpółrzędne już się powtórzyły
                        {
                            outputDevice.Init(audioFile);
                            outputDevice.Play();
                            Console.WriteLine("You've shot at this place before! Please choose another.");
                            playerOneMoves += 1;
                            Thread.Sleep(1000);
                            break;
                        }
                        // Sprawdza czy strzał jest celny na tablicy przeciwnika i czy już wcześniej nie padło to samo miejsce
                        else if (GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 5" 
                            || GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 4"
                            || GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 3" 
                            || GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 2"
                            || GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 1")
                        {
                            GameBoard.playerGameBoard[secondCoordinate, firstCoordinate] = " S"; //przypisuje trafienie
                            outputDevice.Init(audioFile);
                            outputDevice.Play();// uruchamia dzwięk wystrzału
                            Console.WriteLine("You hit the ship!");
                            playerOnePoints += 1; // zwiększa ilość punktów
                            playerOneMoves += 1; // zwiększa liczbę ruchów
                            Thread.Sleep(1000); // robi pauze żeby odtworzył się cały dzwięk
                            if (GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 5")
                            {
                                ship5P2 += 1;
                                if (ship5P2 == 5)
                                {
                                    destroyedShipsP1 += 1;
                                    Console.WriteLine("Congratulations ! You sank a five-masted ship.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                            else if (GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 4")
                            {
                                ship4P2 += 1;
                                if (ship4P2 == 4)
                                {
                                    destroyedShipsP1 += 1;
                                    Console.WriteLine($"Congratulations ! You sank a four-masted ship.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                            else if (GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 3")
                            {
                                ship3P2 += 1;
                                if (ship3P2 == 3)
                                {
                                    destroyedShipsP1 += 1;
                                    Console.WriteLine("Congratulations ! You sank a three-masted ship.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                            else if (GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 2")
                            {
                                ship2P2 += 1;
                                if (ship2P2 == 2)
                                {
                                    destroyedShipsP1 += 1;
                                    Console.WriteLine("Congratulations ! You sank a two-masted ship.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                            else if (GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 1")
                            {
                                ship1P2 += 1;
                                if (ship1P2 == 2)
                                {
                                    destroyedShipsP1 += 1;
                                    Console.WriteLine("Congratulations ! You sank a two-masted ship.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                        }
                        else
                        {
                            GameBoard.playerGameBoard[secondCoordinate, firstCoordinate] = " O"; // Przypisuje chybiony strzał na tablicy gracza
                            outputDevice.Init(audioFile);
                            outputDevice.Play();
                            Console.WriteLine("You missed!");
                            playerOneMoves += 1;
                            Thread.Sleep(1000);
                            break;
                        }
                        Console.Clear();
                    }
                    if(playerOnePoints == 16) break;
                }
                if (playerOnePoints == 16)
                {
                    winerrName = playerOne.Name;
                    winerrMoves = playerOneMoves;
                    break;
                }
                //Second player
                while (true) 
                {
                    string soundFilePath = "cannon-shot-14799.mp3"; //dzwięk wystrzału
                    using (var audioFile = new Mp3FileReader(soundFilePath)) // mp3 player
                    using (var outputDevice = new WaveOutEvent())
                    {
                        Console.Clear();
                        Console.WriteLine($"Game time: {(DateTime.Now - startTime):hh\\:mm\\:ss}"); // Wyświetlanie licznika czasu
                        Console.WriteLine($"Player: {playerTwo.Name}");
                        GameBoard.PrintArray(GameBoard.player2GameBoard);//Drukuje planszę którą widzi gracz
                        Console.WriteLine($"You destroyed {destroyedShipsP2} of 5 ships");
                        Console.WriteLine($"Number of shots: {playerTwoMoves}");
                        Console.WriteLine("Enter the attack coordinate");
                        Console.Write("Enter the first coordinate from A to J: ");
                        input = Console.ReadLine().ToUpper();
                        int stop = 2;
                        if (input == "EXIT")
                        {
                            Menu.MainMenu();
                        }
                        while (stop != 1) //Sprawdza czy podana współrzędna mieści się w zakresie liter
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                if (input == lettersTest[i])
                                {
                                    stop = 1;
                                }
                            }
                            if (stop != 1)
                            {
                                Console.WriteLine("Incorrect coordinate! \r\nEnter the first coordinate from A to J:");
                                input = Console.ReadLine().ToUpper();
                            }
                        }
                        Enum.TryParse(input, out FirstCoordinate letter);// Pobiera dane z klasy enum
                        firstCoordinate = (int)letter;// podaje litere z klasy enum jako liczbe która jest jej przypisana 
                        Console.Write("Enter the second coordinate from 1 to 10: ");
                        string input2 = Console.ReadLine();

                        for (; ; )
                        {
                            if (int.TryParse(input2, out secondCoordinate))//sprawdza czy podana wartość jest int-em
                            {
                                if (secondCoordinate >= 1 && secondCoordinate <= 10) // sprawdza czy wartość jest z zakresu 1-10
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect coordinate! \r\nEnter the second coordinate from 1 to 10:");
                                    input2 = Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Incorrect coordinate! \r\nEnter the second coordinate from 1 to 10:");
                                input2 = Console.ReadLine();
                            }
                        }
                        if (GameBoard.player2GameBoard[secondCoordinate, firstCoordinate] == " S" || GameBoard.player2GameBoard[secondCoordinate, firstCoordinate] == " O") // Sprzwdza czy podane wzpółrzędne już się powtórzyły
                        {
                            outputDevice.Init(audioFile);
                            outputDevice.Play();
                            Console.WriteLine("You've shot at this place before! Please choose another.");
                            playerTwoMoves += 1;
                            Thread.Sleep(1000);
                            break;
                        }
                        // Sprawdza czy strzał jest celny na tablicy przeciwnika i czy już wcześniej nie padło to samo miejsce
                        else if (GameBoard.player2GameBoard[secondCoordinate, firstCoordinate] != " S" && GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 5" || GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 4" || GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 3" || GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 2"|| GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 1")
                        {
                            GameBoard.player2GameBoard[secondCoordinate, firstCoordinate] = " S"; //przypisuje trafienie
                            outputDevice.Init(audioFile);
                            outputDevice.Play();// uruchamia dzwięk wystrzału
                            Console.WriteLine("You hit the ship!");
                            playerTwoPoints += 1; // zwiększa ilość punktów
                            playerTwoMoves += 1; // zwiększa liczbę ruchów
                            Thread.Sleep(1000); // robi pauze żeby odtworzył się cały dzwięk
                            if (GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 5")
                            {
                                ship5P1 += 1;
                                if (ship5P1 == 5)
                                {
                                    destroyedShipsP2 += 1;
                                    Console.WriteLine("Congratulations ! You sank a five-masted ship.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                            else if (GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 4")
                            {
                                ship4P1 += 1;
                                if (ship4P1 == 4)
                                {
                                    destroyedShipsP2 += 1;
                                    Console.WriteLine($"Congratulations ! You sank a four-masted ship.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                            else if (GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 3")
                            {
                                ship3P1 += 1;
                                if (ship3P1 == 3)
                                {
                                    destroyedShipsP2 += 1;
                                    Console.WriteLine("Congratulations ! You sank a three-masted ship.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                            else if (GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 2")
                            {
                                ship2P1 += 1;
                                if (ship2P1 == 2)
                                {
                                    destroyedShipsP2 += 1;
                                    Console.WriteLine("Congratulations ! You sank a two-masted ship.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                            else if (GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 1")
                            {
                                ship1P1 += 1;
                                if (ship1P1 == 2)
                                {
                                    destroyedShipsP2 += 1;
                                    Console.WriteLine("Congratulations ! You sank a two-masted ship.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                        }
                        else
                        {
                            GameBoard.player2GameBoard[secondCoordinate, firstCoordinate] = " O"; // Przypisuje chybiony strzał na tablicy gracza
                            outputDevice.Init(audioFile);
                            outputDevice.Play();
                            Console.WriteLine("You missed!");
                            playerTwoMoves += 1;
                            Thread.Sleep(1000);
                            break;
                        }
                        Console.Clear();
                    }
                    if (playerTwoPoints == 16) break;
                }
                if (playerTwoPoints == 16)
                {
                    winerrName = playerTwo.Name;
                    winerrMoves = playerTwoMoves;
                    break;
                }
            } 

            TimeSpan differenceTime = DateTime.Now - startTime; // Czas gry
            timeInSeconds = (int)differenceTime.TotalSeconds; // czas gry w sekundach int

            //points = ScoreCalculation.Calculation(winerMoves, timeInSeconds);
            TopTenList.AddResultToTopTenList(winerrName, ScoreCalculation.Calculation(winerrMoves, timeInSeconds));
            TopTenList.SortTopTenList();
            Console.WriteLine($"The winer is {winerrName} ! ! ! \r\n" +
                              $"Congratulations on destroying all the ships, you win in {winerrMoves} moves.");
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            Menu.MainMenu();

        }

        //Mechanika - gracz vs komputer
        public static void PlayerVSComputer()
        {
            bool gamePlay = true;
            int winnerMoves = 0;
            string winnerName = "Gamer";
            int playerOneMoves = 0;
            int playerTwoMoves = 0;
            int firstCoordinate;
            int secondCoordinate;
            int timeInSeconds = 0;
            int destroyedShipsP1 = 0;
            int destroyedShipsP2 = 0;
            int ship5P1 = 0, ship4P1 = 0, ship3P1 = 0, ship2P1 = 0, ship1P1 = 0;
            int ship5P2 = 0, ship4P2 = 0, ship3P2 = 0, ship2P2 = 0, ship1P2 = 0;
            string input;
            string[] lettersTest = new string[10] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };// Tablica dla sprzwdzenia czy użytkonik napewno wprowadził literę jako pierwszą współrzędną
            Console.Clear();
            GameBoard.ClearingTheBoard(GameBoard.playerGameBoard);
            GameBoard.ClearingTheBoard(GameBoard.gameBoard);
            GameBoard.ClearingTheBoard(GameBoard.player2GameBoard);
            GameBoard.ClearingTheBoard(GameBoard.gameBoard2);
            //Dodawanie wszystkich okrętów do planszy gry pierwszego gracza
            ShipDraw.FiveFlagships(GameBoard.gameBoard);
            ShipDraw.FourFlagships(GameBoard.gameBoard);
            ShipDraw.ThreeFlagships(GameBoard.gameBoard);
            ShipDraw.TwoFlagships(GameBoard.gameBoard);
            ShipDraw.TwoFlagshipsSecond(GameBoard.gameBoard);
            //Dodawanie wszystkich okrętów do planszy gry drugiego gracza
            ShipDraw.FiveFlagships(GameBoard.gameBoard2);
            ShipDraw.FourFlagships(GameBoard.gameBoard2);
            ShipDraw.ThreeFlagships(GameBoard.gameBoard2);
            ShipDraw.TwoFlagships(GameBoard.gameBoard2);
            ShipDraw.TwoFlagshipsSecond(GameBoard.gameBoard2);

            var playerOne = new Players();
            Console.Write("Enter the name of the player 1: ");
            playerOne.Name = Console.ReadLine();
            Console.Clear();
            DateTime startTime = DateTime.Now; // Czas startu programu
            int playerOnePoints = 0;
            int playerTwoPoints = 0;
            while (gamePlay)
            {
                //Player
                while (true)
                {
                    string soundFilePath = "cannon-shot-14799.mp3"; //dzwięk wystrzału
                    using (var audioFile = new Mp3FileReader(soundFilePath)) // mp3 player
                    using (var outputDevice = new WaveOutEvent())
                    {
                        Console.Clear();
                        Console.WriteLine($"Game time: {(DateTime.Now - startTime):hh\\:mm\\:ss}"); // Wyświetlanie licznika czasu
                        Console.WriteLine($"Player: {playerOne.Name}");
                        GameBoard.PrintArray(GameBoard.playerGameBoard);//Drukuje planszę którą widzi gracz
                        Console.WriteLine($"You destroyed {destroyedShipsP1} of 5 ships");
                        Console.WriteLine($"Number of shots: {playerOneMoves}");
                        Console.WriteLine("Enter the attack coordinate");
                        Console.Write("Enter the first coordinate from A to J: ");
                        input = Console.ReadLine().ToUpper();
                        int stop = 2;
                        if (input == "EXIT")
                        {
                            Menu.MainMenu();
                        }
                        while (stop != 1) //Sprawdza czy podana współrzędna mieści się w zakresie liter
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                if (input == lettersTest[i])
                                {
                                    stop = 1;
                                }
                            }
                            if (stop != 1)
                            {
                                Console.WriteLine("Incorrect coordinate! \r\nEnter the first coordinate from A to J:");
                                input = Console.ReadLine().ToUpper();
                            }
                        }
                        Enum.TryParse(input, out FirstCoordinate letter);// Pobiera dane z klasy enum
                        firstCoordinate = (int)letter;// podaje litere z klasy enum jako liczbe która jest jej przypisana 
                        Console.Write("Enter the second coordinate from 1 to 10: ");
                        string input2 = Console.ReadLine();

                        for (; ; )
                        {
                            if (int.TryParse(input2, out secondCoordinate))//sprawdza czy podana wartość jest int-em
                            {
                                if (secondCoordinate >= 1 && secondCoordinate <= 10) // sprawdza czy wartość jest z zakresu 1-10
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect coordinate! \r\nEnter the second coordinate from 1 to 10:");
                                    input2 = Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Incorrect coordinate! \r\nEnter the second coordinate from 1 to 10:");
                                input2 = Console.ReadLine();
                            }
                        }
                        if (GameBoard.playerGameBoard[secondCoordinate, firstCoordinate] == " S" || GameBoard.playerGameBoard[secondCoordinate, firstCoordinate] == " O") // Sprzwdza czy podane wzpółrzędne już się powtórzyły
                        {
                            outputDevice.Init(audioFile);
                            outputDevice.Play();
                            Console.WriteLine("You've shot at this place before! Please choose another.");
                            playerOneMoves += 1;
                            Thread.Sleep(1000);
                            break;
                        }
                        // Sprawdza czy strzał jest celny na tablicy przeciwnika i czy już wcześniej nie padło to samo miejsce
                        else if (GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 5"
                            || GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 4"
                            || GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 3"
                            || GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 2"
                            || GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 1")
                        {
                            GameBoard.playerGameBoard[secondCoordinate, firstCoordinate] = " S"; //przypisuje trafienie
                            outputDevice.Init(audioFile);
                            outputDevice.Play();// uruchamia dzwięk wystrzału
                            Console.WriteLine("You hit the ship!");
                            playerOnePoints += 1; // zwiększa ilość punktów
                            playerOneMoves += 1; // zwiększa liczbę ruchów
                            Thread.Sleep(1000); // robi pauze żeby odtworzył się cały dzwięk
                            if (GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 5")
                            {
                                ship5P2 += 1;
                                if (ship5P2 == 5)
                                {
                                    destroyedShipsP1 += 1;
                                    Console.WriteLine("Congratulations ! You sank a five-masted ship.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                            else if (GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 4")
                            {
                                ship4P2 += 1;
                                if (ship4P2 == 4)
                                {
                                    destroyedShipsP1 += 1;
                                    Console.WriteLine($"Congratulations ! You sank a four-masted ship.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                            else if (GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 3")
                            {
                                ship3P2 += 1;
                                if (ship3P2 == 3)
                                {
                                    destroyedShipsP1 += 1;
                                    Console.WriteLine("Congratulations ! You sank a three-masted ship.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                            else if (GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 2")
                            {
                                ship2P2 += 1;
                                if (ship2P2 == 2)
                                {
                                    destroyedShipsP1 += 1;
                                    Console.WriteLine("Congratulations ! You sank a two-masted ship.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                            else if (GameBoard.gameBoard2[secondCoordinate, firstCoordinate] == " 1")
                            {
                                ship1P2 += 1;
                                if (ship1P2 == 2)
                                {
                                    destroyedShipsP1 += 1;
                                    Console.WriteLine("Congratulations ! You sank a two-masted ship.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                        }
                        else
                        {
                            GameBoard.playerGameBoard[secondCoordinate, firstCoordinate] = " O"; // Przypisuje chybiony strzał na tablicy gracza
                            outputDevice.Init(audioFile);
                            outputDevice.Play();
                            Console.WriteLine("You missed!");
                            playerOneMoves += 1;
                            Thread.Sleep(1000);
                            break;
                        }
                        Console.Clear();
                    }
                    if (playerOnePoints == 16) break;
                }
                if (playerOnePoints == 16)
                {
                    winnerName = playerOne.Name;
                    winnerMoves = playerOneMoves;
                    break;
                }
                //Computer
                for (int i = 0; i < DifficultyLevel.difficultyLevel; i++)
                {
                    string soundFilePath = "cannon-shot-14799.mp3"; //dzwięk wystrzału
                    using (var audioFile = new Mp3FileReader(soundFilePath)) // mp3 player
                    using (var outputDevice = new WaveOutEvent())
                    {
                        Console.Clear();
                        Console.WriteLine($"Player: Enemy");
                        GameBoard.PrintArray(GameBoard.player2GameBoard);//Drukuje planszę którą widzi gracz
                        Random rdm = new Random();
                        firstCoordinate = rdm.Next(1, 11);
                        secondCoordinate = rdm.Next(1, 11);
                        for (; ; ) 
                        {
                            if (GameBoard.player2GameBoard[secondCoordinate, firstCoordinate] == " S" || GameBoard.player2GameBoard[secondCoordinate, firstCoordinate] == " O") // Sprzwdza czy podane wzpółrzędne już się powtórzyły
                            {
                                firstCoordinate = rdm.Next(1, 11);
                                secondCoordinate = rdm.Next(1, 11);
                            }
                            else
                            {
                                break;
                            }
                        }
                        // Sprawdza czy strzał jest celny na tablicy przeciwnika i czy już wcześniej nie padło to samo miejsce
                        if (GameBoard.player2GameBoard[secondCoordinate, firstCoordinate] != " S" && GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 5" || GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 4" || GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 3" || GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 2" || GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 1")
                        {
                            GameBoard.player2GameBoard[secondCoordinate, firstCoordinate] = " S"; //przypisuje trafienie
                            outputDevice.Init(audioFile);
                            outputDevice.Play();// uruchamia dzwięk wystrzału
                            Console.WriteLine("Your ship was hit!");
                            playerTwoPoints += 1; // zwiększa ilość punktów
                            playerTwoMoves += 1; // zwiększa liczbę ruchów
                            Thread.Sleep(1000); // robi pauze żeby odtworzył się cały dzwięk
                            if (GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 5")
                            {
                                ship5P1 += 1;
                                if (ship5P1 == 5)
                                {
                                    destroyedShipsP2 += 1;
                                    Console.WriteLine("The enemy destroyed your warship with five flags.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                            else if (GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 4")
                            {
                                ship4P1 += 1;
                                if (ship4P1 == 4)
                                {
                                    destroyedShipsP2 += 1;
                                    Console.WriteLine($"The enemy destroyed your warship with four flags.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                            else if (GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 3")
                            {
                                ship3P1 += 1;
                                if (ship3P1 == 3)
                                {
                                    destroyedShipsP2 += 1;
                                    Console.WriteLine("The enemy destroyed your warship with three flags.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                            else if (GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 2")
                            {
                                ship2P1 += 1;
                                if (ship2P1 == 2)
                                {
                                    destroyedShipsP2 += 1;
                                    Console.WriteLine("The enemy destroyed your warship with two flags.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                            else if (GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " 1")
                            {
                                ship1P1 += 1;
                                if (ship1P1 == 2)
                                {
                                    destroyedShipsP2 += 1;
                                    Console.WriteLine("The enemy destroyed your warship with two flags.\r\nPress any key !");
                                    Console.ReadKey();
                                }
                            }
                        }
                        else
                        {
                            GameBoard.player2GameBoard[secondCoordinate, firstCoordinate] = " O"; // Przypisuje chybiony strzał na tablicy gracza
                            outputDevice.Init(audioFile);
                            outputDevice.Play();
                            Console.WriteLine("The enemy missed!");
                            playerTwoMoves += 1;
                            Thread.Sleep(1000);
                        }
                        Console.Clear();
                    }
                }
                if (playerTwoPoints == 16) break;
            }
            if (playerTwoPoints == 16)
            {
                winnerName = "Enemy";
                winnerMoves = playerTwoMoves;
            }
        
            TimeSpan differenceTime = DateTime.Now - startTime; // Czas gry
            timeInSeconds = (int)differenceTime.TotalSeconds; // czas gry w sekundach int
            if (winnerName == "Enemy")
            {
                Console.WriteLine("The enemy has defeated you, all your warships have been destroyed.");
            }
            else if (winnerName != "Enemy")
            {
                TopTenList.AddResultToTopTenList(winnerName, ScoreCalculation.Calculation(winnerMoves, timeInSeconds));
                TopTenList.SortTopTenList();
                Console.WriteLine($"The winner is {winnerName} ! ! ! \r\n" +
                                  $"Congratulations on destroying all the ships, you win in {winnerMoves} moves.");
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            Menu.MainMenu();
        }
    }
}
