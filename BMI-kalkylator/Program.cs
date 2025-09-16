using System;

namespace BMI_kalkylator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Hälsning och namn
            Console.WriteLine("Vad heter du?");
            string namn = Console.ReadLine();
            Console.WriteLine("Hej " + namn + "!");

            // Fråga om ålder
            int ålder;
            while (true)
            {
                Console.WriteLine("Hur gammal är du?");
                string input = Console.ReadLine();
                if (int.TryParse(input, out ålder))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning. Vänligen ange en giltig ålder.");
                }
            }

            // Fråga om träning
            Console.WriteLine("Gillar du att träna? (Tryck 1 = Ja, Tryck 2 = Nej)");
            string träna = Console.ReadLine();
            while (träna != "1" && träna != "2")
            {
                Console.WriteLine("Ogiltig inmatning. Vänligen ange 1 för Ja eller 2 för Nej.");
                träna = Console.ReadLine();
            }

            if (träna == "2")
            {
                Console.WriteLine("Okej, tack för svaret!");
            }
            else if (träna == "1")
            {
                Console.WriteLine("Vad roligt att höra! Hur många gånger i veckan?");
                string input = Console.ReadLine();
                int gånger;

                if (int.TryParse(input, out gånger) && gånger >= 0)
                {
                    Console.WriteLine("Du är grym att du tränar " + gånger + " gånger i veckan!");
                }
                else
                {
                    Console.WriteLine("Okej, tack för svaret!");
                }
            }

            // --- NYTT: Fråga om användaren vill räkna ut BMI ---
            Console.WriteLine("Vill du räkna ut ditt BMI? (ja/nej)");
            string svar = Console.ReadLine().ToLower();

            if (svar == "ja" || svar == "j")
            {
                // Lägg till instruktioner om hur man skriver in värden
                Console.WriteLine("För att räkna ut ditt BMI:");
                Console.WriteLine("1. För vikt, ange i kilogram (t.ex. 70)");
                Console.WriteLine("2. För längd, ange i meter (t.ex. 1.75)");

                // Ta in vikt och längd med hjälp av metoden LäsInDouble
                double vikt = LäsInDouble("Ange din vikt (kg): ");
                double längd = LäsInDouble("Ange din längd (meter): ");

                // Fråga om enhet och säkerställ att det är "metric" eller "imperial"
                string enhet;
                while (true)
                {
                    Console.Write("Ange enhet ('metric' eller 'imperial'): ");
                    enhet = Console.ReadLine().ToLower(); // Gör om till gemener för att hantera stor-/lilla bokstäver.

                    if (enhet == "metric" || enhet == "imperial")
                    {
                        break; // Om inmatningen är korrekt, bryt loopen.
                    }
                    else
                    {
                        Console.WriteLine("Ogiltig inmatning. Vänligen skriv 'metric' eller 'imperial'.");
                    }
                }

                // Beräkna BMI
                double bmi = CalculateBMI(vikt, längd, enhet);
                Console.WriteLine($"Ditt BMI är: {bmi:F2}");
            }
            else
            {
                Console.WriteLine("Okej, tack för att du använde programmet!");
            }

            
        }

        // --- BMI-metoden ---
        static double CalculateBMI(double weight, double height, string unit = "metric")
        {
            if (unit == "metric")
            {
                return weight / (height * height); // BMI-formel för metric (kg/m²)
            }
            else if (unit == "imperial")
            {
                return 703 * (weight / (height * height)); // BMI-formel för imperial (lbs/inch²)
            }
            else
            {
                Console.WriteLine("Okänd enhet, returnerar 0");
                return 0;
            }
        }

        // --- Hjälpfunktion för att läsa in en double och hantera både komma och punkt ---
        static double LäsInDouble(string prompt)
        {
            double resultat;
            string input;
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                // Byt ut komma (,) mot punkt (.) för att hantera inmatningar som 1,75 och 1.75
                input = input.Replace(',', '.'); // Ersätt komma med punkt.

                // Försök att konvertera inmatningen till ett double.
                if (double.TryParse(input, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out resultat))
                {
                    break; // Om det går att konvertera, bryt loopen.
                }
                else
                {
                    // Om inmatningen är ogiltig, be om ny inmatning.
                    Console.WriteLine("Ogiltig inmatning. Vänligen ange ett giltigt tal.");
                }
            }
            return resultat; // Returnera det giltiga talet.
        }
    }
}
