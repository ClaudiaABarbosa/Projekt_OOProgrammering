namespace MinaHusdjur
{
    internal class Matregister
    {
        private static string[] husdjur = new string[3] { "Loke", "Indie", "Stella" };  // En array som håller namnen på husdjuren. Eftersom det är specifikt mina husdjur det handlar om. 

        private static double[,] matning = new double[husdjur.Length, 2];   // En matris som håller matningsinformation för varje husdjur (tid och mängd).
                                                                            // Därför utgår den från husdjur.Lenght, om jag skulle skaffa fler kan jag bara lägga till de i husdjur arraye
        public static void Matning()    // Funktion för att registrera matning för husdjuren
        {
            Console.WriteLine("\t\tMatningsdagbok. \n\nFör att avbryta resgitreringen tryck ENTER");
            for (int i = 0; i < matning.GetLength(0); i++)
            {
                bool godkandInput = false;
                while (!godkandInput)
                {
                    try //Testar inmantningen, om inkorrekt då körs Catch-metoden istället.  
                    {
                        // Användaren ombeds ange tidpunkt och mängd mat för varje husdjur
                        Console.Write($"\nAnge vilken tid {husdjur[i]} har fått maten: (ange: tim,min) ");
                        string tidpunktInput = Console.ReadLine();

                        // Kontrollera om användaren har matat in ett tomt värde
                        if (string.IsNullOrEmpty(tidpunktInput))
                        {
                            Console.WriteLine("Avbryter registreringen och återgår till meny.\n");
                            return;
                        }
                        else
                        {
                            matning[i, 0] = double.Parse(tidpunktInput);
                            godkandInput = true;
                        }
                        Console.Write($"\nAnge hur mycket mat {husdjur[i]} har fått: (ange endast i siffror) ");
                        string matningInput = Console.ReadLine();

                        if (string.IsNullOrEmpty(matningInput))
                        {
                            Console.WriteLine("Avbryter registreringen och återgår till meny.\n");
                            return;
                        }
                        else
                        {
                            matning[i, 1] = double.Parse(tidpunktInput);
                            godkandInput = true;
                        }
                    }
                    catch (FormatException) //om användaren skriver i fel format kommer ett fel meddelande och användaren får börja om.  
                    {
                        Console.WriteLine("Ogiltig inmatning. Ange ett giltigt nummer.");
                        i--; // Återställ räknaren om ogiltig inmatning upptäcks.
                    }
                }

            }
            MatningLogg();
        }

        public static void MatningLogg()    // Funktion för att logga matningsinformationen till en textfil, eftersom jag vill se matningslogg senare, vill jag kunna spara de i en textfil 
        {
            try
            {
                using (StreamWriter matlogg = new StreamWriter("Matlogg.txt", true)) // Med stremaWriter en fil skapas per automatik i projektmappen "bin". Nmanet på filen bilr "Matlogg" och anledningen till att man använder.
                                                                                     // true är för att texten inte skall skrivas över varje gång användaren matar in något nytt
                {
                    string datum = $"{DateOnly.FromDateTime(DateTime.Now)}:"; //då dagens datum ska vara med eftersom tiden skrivs av användaren. Därför används denna kod, annars räcker det med DateTime.Now 
                    matlogg.WriteLine(datum);
                    for (int i = 0; i < matning.GetLength(0); i++)
                    {
                        string logg = $"{husdjur[i]} har fått {matning[i, 1]} gram mat klockan {matning[i, 0]}.\n";
                        matlogg.WriteLine(logg);
                    }
                }
            }
            catch (IOException ex) // Om det skulle uppstå ett fel och filen inte skapats eller raderats så kommer fel meddelandet upp.
            {
                Console.WriteLine("Ett fel uppstod vid åtkomst av filen: " + ex.Message);
            }
        }


        public static void MatningLoggUt() // Funktion för att visa matningsloggen på konsolen
        {
            using (StreamReader reader = new StreamReader("Matlogg.txt")) //Hänvisar till min textfil "Matlogg" som skapades tidigare. 
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            }
        }
    }
}
