using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinqLab
{
    internal class Menu
    {
        public static void RunProgram()
        {
            bool running = true;
            while(running)
            {
                Console.WriteLine(@"System\> Hej, Snälla välj ett av valen");
                Console.WriteLine("1. Hämta alla produkter i kategorin \"Electronics\" och sortera dem efter pris (högst först)");
                Console.WriteLine("2. Lista alla leverantörer som har produkter med ett lagersaldo under 10 enheter");
                Console.WriteLine("3. Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden");
                Console.WriteLine("4. Hitta de 3 mest sålda produkterna baserat på OrderDetail-data");
                Console.WriteLine("5. Lista alla kategorier och antalet produkter i varje kategori");
                Console.WriteLine("6. Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr");
                Console.WriteLine("7. Avsluta programmet");

                int answer;
                while (!int.TryParse(Console.ReadLine(), out answer))
                {
                    Console.WriteLine($"Du måste ange ett heltal");
                }

                Console.Clear();

                switch(answer)
                {
                    case 1:
                        Commands.GetElectronics();
                        WaitForKey();
                        break;
                    case 2:
                        Commands.GetSuppliersLess10();
                        WaitForKey();
                        break;
                    case 3:
                        Commands.GetTotalOrderValueLastMonth();
                        WaitForKey();
                        break;
                    case 4:
                        Commands.GetTop3BestSellingProducts();
                        WaitForKey();
                        break;
                    case 5:
                        Commands.GetCategoriesWithProductCount();
                        WaitForKey();
                        break;
                    case 6:
                        Commands.GetHighValueOrdersWithDetails();
                        WaitForKey();
                        break;
                    case 7:
                        Console.WriteLine("Avslutar programmet...");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }            
        }
        private static void WaitForKey()
        {
            Console.WriteLine("\nTryck på enter för att fortsätta");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
