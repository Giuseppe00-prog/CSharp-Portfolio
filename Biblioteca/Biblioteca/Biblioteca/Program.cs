using Biblioteca;
using System.Data;

public class Program
{
    static void Main(string[] args)
    {
        List<Libro> _libri = new List<Libro>
        {
            new Libro(titolo: "Una lunga guerra", autore: "Orwell", anno: new DateOnly(1949,1,1)),
            new Libro(titolo: "Il nome della rosa", autore: "Eco", anno: new DateOnly(1980,1,1)),
        };
        Libreria libreria = new Libreria(_libri);
        while(true)
        {
            Console.WriteLine("Gestione Biblioteca");
            Console.WriteLine("1. Aggiungi un libro");
            Console.WriteLine("2. Cerca per autore");
            Console.WriteLine("3. Cerca per titolo");
            Console.WriteLine("4. Visualizza tutti i libri");
            Console.WriteLine("5. Salva su File");
            Console.WriteLine("6. Carica da file");
            Console.WriteLine("0. Esci");
            if (!int.TryParse(Console.ReadLine(), out int scelta))
            {
                Console.WriteLine("Scelta non valida!");
                continue;
            }
            switch (scelta)
            {
                case 1:
                    Console.Write("Titolo: ");
                    string titolo = Console.ReadLine();
                    Console.Write("Autore: ");
                    string autore = Console.ReadLine();
                    Console.Write("Anno: ");
                    int anno = int.Parse(Console.ReadLine());
                    libreria.AggiungiLibro(new Libro(titolo, autore, new DateOnly(anno, 1, 1)));
                    Console.WriteLine("Libro aggiunto correttamente!");
                    break;

                case 2:
                    Console.Write("Inserisci autore: ");
                    var libroAutore = libreria.CercaPerAutore(Console.ReadLine());
                    if (libroAutore != null)
                        libroAutore.Presentazione();
                    else
                        Console.WriteLine("Nessun libro trovato.");
                    break;

                case 3:
                    Console.Write("Inserisci titolo: ");
                    var libroTitolo = libreria.CercaPerTitolo(Console.ReadLine());
                    if (libroTitolo != null)
                        libroTitolo.Presentazione();
                    else
                        Console.WriteLine("Nessun libro trovato.");
                    break;

                case 4:
                    libreria.StampaTutti();
                    break;

                case 5:
                    libreria.SalvaSuFile("dati.json");
                    Console.WriteLine("Salvataggio completato.");
                    break;

                case 6:
                    libreria.CaricaDaFile("dati.json");
                    Console.WriteLine("Caricamento completato.");
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }
        }
       
    }
}