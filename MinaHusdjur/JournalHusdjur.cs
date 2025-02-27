using System;
using System.IO;

namespace MinaHusdjur
{
    internal class JournalHusdjur
    {
       
        public static void LaggTillInfo() // Metod för att lägga till information om husdjur i sina respektive journaler.
        {
            Console.WriteLine("\t\t     Journal. \n\nFör att avbryta resgitreringen tryck ENTER\n");
            Console.Write("Vilket husdjur vill du skriva om? ");
            string valAvHusdjur = Console.ReadLine();
 
            switch (valAvHusdjur.ToLower()) //  En switch-sats för att hantera olika husdjursval. Och .ToLower eftrsom det ska inte spella någon roll hur användaren skriver namnet på husdjuret.
            {
                case "stella":// Anropa LaggTillJournalInfo-metoden för husdjur "Stella".      
                    LaggTillJournalInfo("JournalStella.txt", valAvHusdjur);
                    break;
                case "loke":
                    LaggTillJournalInfo("JournalLoke.txt", valAvHusdjur);
                    break;
                case "indie":
                    LaggTillJournalInfo("JournalIndie.txt", valAvHusdjur);
                    break;
                default:
                    Console.WriteLine("Inkorrekt inmatning, vänligen försök igen");
                    break;
            }
        }

        // Privat metod för att lägga till information i en husdjursjournal. Privat eftersom endast klassen "JournalHusdjur" ska kunna anropa denna metod. 
        private static void LaggTillJournalInfo(string journalFilnamn, string husdjurNamn)
        {
            Console.WriteLine($"Vad vill du berätta om {husdjurNamn}");
            string journalText = Console.ReadLine();

            try
            {
                using (StreamWriter journal = new StreamWriter(journalFilnamn, true))  // Öppna journalfilen för att skriva och lägga till informationen.
                {
                    journal.WriteLine($"\n{DateTime.Now}:\n{journalText}");
                    Console.WriteLine("\nInformationen har lagts till i journalen.");
                }
            }
            catch (Exception ex)
            {
              
                Console.WriteLine($"Ett fel uppstod: {ex.Message}");  // Hantera eventuella fel som kan uppstå vid filskrivning. 
            }
        }
    }
}
