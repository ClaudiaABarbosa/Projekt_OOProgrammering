namespace MinaHusdjur
{
    internal class InfoHusdjur // Här är en klass som tillåter användaren sjölv välja vilken av husdjuren hen vill läsa om 
    {
        public static void ValAvHusdjur() // Funktion för att välja och visa information om ett husdjur
        {
            Console.Write("Vilket husdjur vill du veta mer om? ");
            try
            {
                
                string valAvhusdjur = Console.ReadLine()!.ToLower(); // Läser in användarens inmatning och konverterar den till små bokstäver, för att inte bli fel när personen matar in namnet på husdjuret. 

                switch (valAvhusdjur)// Använder en switch-sats för att välja rätt husdjur och visa dess information. Valde switchcase då det blev mer lättläst än if-sats :)
                {
                    case "stella":
                        InfoHusdjurUt.InfoStellaUt(); // Anropar funktionen för att visa information om Stella
                        Console.WriteLine();
                        break;
                    case "loke":
                        InfoHusdjurUt.InfoLokeUt(); 
                        Console.WriteLine();
                        break;
                    case "indie":
                        InfoHusdjurUt.InfoIndieUt(); 
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Ogiltig inmatning. Vänligen försök igen med ett giltigt husdjursnamn.");
                        break;
                }
            }
            catch (IOException ex) 
            {
                Console.WriteLine("Ett fel uppstod vid filåtkomst: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ett okänt fel inträffade: " + ex.Message);
            }
        }
    }
}
