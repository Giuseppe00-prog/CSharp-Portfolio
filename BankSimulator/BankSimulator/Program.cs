using BankSimulator.Models;
using BankSimulator.Services;

public class Program
{
    static void Main(string[] args)
    {
        BancaService banca = new BancaService();
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\n=== SIMULATORE DI BANCA ===");
            Console.WriteLine("1. Crea cliente");
            Console.WriteLine("2. Crea conto per cliente");
            Console.WriteLine("3. Deposita");
            Console.WriteLine("4. Preleva");
            Console.WriteLine("5. Bonifico");
            Console.WriteLine("6. Mostra storico operazioni conto");
            Console.WriteLine("7. Mostra clienti e conti");
            Console.WriteLine("0. Esci");
            Console.Write("Seleziona un'opzione: ");

            string scelta = Console.ReadLine();
            Console.WriteLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Nome cliente: ");
                    string nome = Console.ReadLine()!;
                    Console.Write("Cognome cliente: ");
                    string cognome = Console.ReadLine()!;
                    try
                    {
                        var cliente = banca.CreaCliente(nome, cognome);
                        Console.WriteLine($"Cliente creato: {cliente}");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());

                    }
                    break;

                case "2":
                    Console.Write("ID cliente: ");
                    Guid idCliente = Guid.Parse(Console.ReadLine()!);
                    var clienteSelezionato = banca.TrovaCliente(idCliente);
                    if (clienteSelezionato == null)
                    {
                        Console.WriteLine("Cliente non trovato.");
                        break;
                    }
                    Console.Write("Numero conto: ");
                    string numeroConto = Console.ReadLine()!;
                    var conto = banca.CreaConto(clienteSelezionato, numeroConto);
                    Console.WriteLine($"Conto creato: {conto}");
                    break;

                case "3":
                    conto = SelezionaConto(banca);
                    if (conto != null)
                    {
                        Console.Write("Importo da depositare: ");
                        decimal importo = decimal.Parse(Console.ReadLine()!);
                        banca.Deposita(conto, importo);
                        Console.WriteLine("Deposito effettuato!");
                    }
                    break;

                case "4":
                    conto = SelezionaConto(banca);
                    if (conto != null)
                    {
                        Console.Write("Importo da prelevare: ");
                        decimal importo = decimal.Parse(Console.ReadLine()!);
                        try
                        {
                            banca.Preleva(conto, importo);
                            Console.WriteLine("Prelievo effettuato!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Errore: {ex.Message}");
                        }
                    }
                    break;

                case "5":
                    Console.WriteLine("Conto mittente:");
                    ContoCorrente mittente = SelezionaConto(banca)!;
                    Console.WriteLine("Conto destinatario:");
                    ContoCorrente destinatario = SelezionaConto(banca)!;
                    Console.Write("Importo bonifico: ");
                    decimal importoBonifico = decimal.Parse(Console.ReadLine()!);
                    try
                    {
                        banca.Bonifico(mittente, destinatario, importoBonifico);
                        Console.WriteLine("Bonifico effettuato!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Errore: {ex.Message}");
                    }
                    break;

                case "6":
                    conto = SelezionaConto(banca);
                    if (conto != null)
                        banca.MostraStorico(conto);
                    break;

                case "7":
                    banca.MostraClienti();
                    break;

                case "0":
                    continua = false;
                    break;

                default:
                    Console.WriteLine("Opzione non valida.");
                    break;
            }
        }

        Console.WriteLine("Grazie per aver usato il simulatore di banca!");
    }

    // Metodo helper per selezionare un conto da tutti i clienti
    static ContoCorrente? SelezionaConto(BancaService banca)
    {
        banca.MostraClienti();
        Console.Write("Inserisci ID cliente: ");
        Guid idCliente = Guid.Parse(Console.ReadLine()!);
        var cliente = banca.TrovaCliente(idCliente);
        if (cliente == null)
        {
            Console.WriteLine("Cliente non trovato.");
            return null;
        }

        if (cliente.Conti.Count == 0)
        {
            Console.WriteLine("Cliente non ha conti.");
            return null;
        }

        Console.WriteLine("Seleziona conto:");
        for (int i = 0; i < cliente.Conti.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {cliente.Conti[i]}");
        }

        int scelta = int.Parse(Console.ReadLine()!);
        return cliente.Conti[scelta - 1];
    }
}