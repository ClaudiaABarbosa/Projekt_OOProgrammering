namespace MinaHusdjur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VisaMeny();     // Anropar funktionen för att visa menyn 
        }
        static void VisaLogo()  // Rensar konsolfönstret och visar en ASCII-art-logga
        {
            Console.Clear();
            Console.WriteLine(@"
            █▀▄▀█ █▄█ █▀█ █▀▀ ▀█▀ █▀
            █░▀░█ ░█░ █▀▀ ██▄ ░█░ ▄█

            ░░░░░░░░░░▐▐
            ░▐░░░░░░░▄██▄▄
            ░░▀▀██████▀░░░░▓▓
            ░░░░▐▐░░▐▐░░░░░░▓▓▓▓╝
            ▒▒▒▒▐▐▒▒▐▐▒▒▒▒▒▒▓▒▒▓▒▒
            ");
        }
        static void VisaMeny()  // Anropar funktionen för att visa logotypen och skriver ut menyalternativ
        {
            VisaLogo();
            Console.WriteLine("[1] för att se en översikt av alla husdjur" +
                "\n[2] För att läsa mer om ett husdjur" +
                "\n[3] Registrera matning" +
                "\n[4] Se matlogg." +
                "\n[5] för att journalföra om husdjur" +
                "\n[6] för att avsluta programmet");

            Console.Write("\nVälj ett alternativ: ");

            if (int.TryParse(Console.ReadLine(), out int val)) // tar emot användarens svar i string och försöker omvandla till int, om det lyckas får vi ut int = val som används i switch case annars få användaren försöka igen (else). 
            {
                switch (val)     // Anropar olika funktioner beroende på användarens val 
                {
                    case 1:     
                        VisaLogo();
                        InfoHusdjurUt.DjurOversikt();
                        AtergaTillMeny();
                        break;
                    
                    case 2:
                        VisaLogo();
                        InfoHusdjur.ValAvHusdjur();
                        AtergaTillMeny();
                        break;

                    case 3:
                        VisaLogo();
                        Matregister.Matning();
                        AtergaTillMeny();
                        break;

                    case 4:
                        VisaLogo();
                        Matregister.MatningLoggUt();
                        AtergaTillMeny();
                        break;

                    case 5:   
                        VisaLogo();
                        JournalHusdjur.LaggTillInfo();
                        AtergaTillMeny();
                        break;

                    case 6:      
                        Avsluta();
                        break;

                    default:     //Om användaren anger ett val som inte finns ex. 6 kommer användaren att få felmeddelandet.
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        AtergaTillMeny();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning. Vänligen ange ett heltal.");
                AtergaTillMeny();
            }
        }

        public static void AtergaTillMeny() // Metod skapad för att återgå till menyn efter att avnändaren har använt något av menyvalen. Väntar på användarens tryck på en tangent, rensar konsolfönstret och visar menyn igen.
        {
            Console.WriteLine("Tryck på valfri knapp för att återgå till meny.");
            Console.ReadKey();
            Console.Clear();
            VisaMeny();
        }

        static void Avsluta()   // Rensar konsolfönstret och visar en avslutningsmeddelande
        {
            Console.Clear();
            Console.WriteLine(@"
            ▒▒▒▒▒▒▒█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█
            ▒▒▒▒▒▒▒█░▒▒▒▒▒▒▒▓▒▒▓▒▒▒▒▒▒▒░█
            ▒▒▒▒▒▒▒█░▒▒▓▒▒▒▒▒▒▒▒▒▄▄▒▓▒▒░█░▄▄
            ▒▒▄▀▀▄▄█░▒▒▒▒▒▒▓▒▒▒▒█░░▀▄▄▄▄▄▀░░█
            ▒▒█░░░░█░▒▒▒▒▒▒▒▒▒▒▒█░░░░░░░░░░░█
            ▒▒▒▀▀▄▄█░▒▒▒▒▓▒▒▒▓▒█░░░█▒░░░░█▒░░█
            ▒▒▒▒▒▒▒█░▒▓▒▒▒▒▓▒▒▒█░░░░░░░▀░░░░░█
            ▒▒▒▒▒▄▄█░▒▒▒▓▒▒▒▒▒▒▒█░░█▄▄█▄▄█░░█
            ▒▒▒▒█░░░█▄▄▄▄▄▄▄▄▄▄█░█▄▄▄▄▄▄▄▄▄█
            ▒▒▒▒█▄▄█░░█▄▄█░░░░░░█▄▄█░░█▄▄█");
            Console.WriteLine("\t\t\t\tHejdå! :)");
        }
    }
}
