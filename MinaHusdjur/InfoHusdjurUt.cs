namespace MinaHusdjur
{
    internal class InfoHusdjurUt // En klass skapad för att skriva ut sparade information om mina husdjur.
    {
        public static void DjurOversikt() // Funktion för att visa en översikt över husdjuren
        {
            // En matris som innehåller information om husdjuren (namn, art och ålder)
            string[,] oversikt = new string[3, 3] { {"Loke", "Indie", "Stella"},
                                                   {"Katt", "Katt", "Hund"},
                                                   {"3 år", "3 år", "11 månader"} };

            for (int i = 0; i < oversikt.GetLength(0); i++)  // Loopar igenom matrisen och skriver ut informationen på konsolen
            {
                Console.WriteLine($"\t{oversikt[i, 0]}\t{oversikt[i, 1]}\t{oversikt[i, 2]}");
            }
            Console.WriteLine();
        }
        public static void InfoStellaUt() // Funktion för att visa information om husdjuret Stella från en textfil
        {
            using (StreamReader reader = new StreamReader("JournalStella.txt"))     // Öppnar och läser textfilen som innehåller information om Stella
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content); // Skriver ut innehållet på konsolen
            }
        }
        public static void InfoLokeUt() 
        {
            
            using (StreamReader reader = new StreamReader("JournalLoke.txt"))   
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content); 
            }
        }
        public static void InfoIndieUt()
        {
            using (StreamReader reader = new StreamReader("JournalIndie.txt"))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content); 
            }
        }
    }
}
