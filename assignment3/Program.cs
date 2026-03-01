using System.Diagnostics;
using System.Net.Sockets;

namespace assignment3
{

    //Part01
    #region Q1
    //Q1 : Identify the type of relationship in each scenario below (Inheritance, Association, Aggregation, Composition, or Dependency):

    //a) A University has Departments. If the university is closed, the departments no longer exist.
    //Composition

    //b) A Driver uses a Car.The driver does not own the car.
    //Association

    //c) A Dog is an Animal.
    //Inheritance

    //d) A Team has Players. If the team is deleted, the players still exist.
    //Aggregation

    //e) A method receives a Logger as a parameter and calls it inside the method only.
    //Dependency 
    #endregion
    #region Q2
    //Q2: Answer the following questions about access modifiers and sealed:
    //a) A parent class has a protected field.Can a child class in a different assembly access it? What about through an object instance from outside?
    //Yes,No



    //b) What is the difference between protected internal and private protected?
    //accessible anywhere in the same assembly or in the derived class in other assemblies while private protected
    //means accessible in the parent class or the derived class in the same assembly




    //c) What does the sealed keyword do when applied to a class? What about when applied to a method?
    //Doesnt allow inheritance,doesnt let any deriving class change the method behavior




    //d) Can you create an object from a sealed class using new? Why or why not? 
    //yes because sealed has to do with inheritance not creating new objects
    #endregion
    #region Part02

    public class Ticket
    {
        private static int counter = 0;
        public string MovieName { get; set; }
        public int TicketId { get; }
        private decimal price;
        public decimal Price
        {
            get => price;
            set
            {
                if (price < 0)
                    Console.WriteLine("Price must be greater than 0");
                price = value;
            }
        }

        //Constructor
        public Ticket(string _movieName, decimal _price)
        {
            MovieName = _movieName;
            Price = _price;
            TicketId=counter++;
        }
        //d.Override ToString() to return the ticket info.
        public decimal PriceAfterTax { get => Price * 1.14m; }
        public static int GetTotalTickets()
        {
            return counter;
        }

        public override string ToString()
        {
            return $"Ticket #{TicketId} | Movie {MovieName} | Price {Price} | After Tax {PriceAfterTax}";
        }
    }


    public class StandardTicket : Ticket
    {
        public string SeatNumber { get; set; }
        public StandardTicket(string _movieName, decimal _price, string _seatNumber) : base(_movieName, _price)
        {
            SeatNumber = _seatNumber;
        }
        public override string ToString()
        {
            return base.ToString() + $" | Seat: {SeatNumber} | Type: Standard";
        }
    }

    public class VIPTicket : Ticket
    {
        public bool LoungeAccess { get; set; }
        public decimal ServiceFee { get; } = 50m;
        public VIPTicket(string _movieName, decimal _price, bool _loungeAccess) : base(_movieName, _price + 50m)
        {
            LoungeAccess = _loungeAccess;
        }
        public override string ToString()
        {
            return base.ToString() +
                   $" | Lounge Access: {LoungeAccess} | Service Fee: {ServiceFee} | Type: VIP";
        }
    }
    public class IMAXTicket : Ticket
    {
        public bool Is3d { get; set; }
        public IMAXTicket(string _movieName, decimal _price, bool _is3d) : base(_movieName, _price + 30m)
        {
            Is3d = _is3d;
        }
        public override string ToString()
        {
            return base.ToString() +
                   $" | 3D: {Is3d} | Type: IMAX";
        }

    }


    public sealed class Projector
    {
        public void Start() => Console.WriteLine("Projector is on.");
        public void Stop() => Console.WriteLine("Projector is off.");
    }

    public class Cinema
    {
        public string CinemaName { get; set; }
        private Projector projector;
        public Cinema(string cinemaName)
        {
            CinemaName = cinemaName;
            projector = new Projector();
        }
        private Ticket[] tickets = new Ticket[20];
        public void AddTicket(Ticket t)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i] == null)
                {
                    tickets[i] = t;
                    return;
                }
            }
            Console.WriteLine("Cinema is full");

        }
        public void PrintAllTickets()
        {
            foreach (var ticket in tickets)
            {
                if (ticket != null)
                    Console.WriteLine(ticket);
            }
        }
        public void OpenCinema()
        {
            Console.WriteLine($"{CinemaName} is now OPEN.");
            projector.Start();
        }

        public void CloseCinema()
        {
            Console.WriteLine($"{CinemaName} is now CLOSED.");
            projector.Stop();
        }
    }

        internal class Program
        {
            static void Main(string[] args)
            {
                Cinema cinema = new Cinema("Cinema");
                cinema.OpenCinema();
                Ticket t1 = new StandardTicket("Inception", 100m, "A10");
                Ticket t2 = new VIPTicket("Avatar 2", 200m, true);
                Ticket t3 = new IMAXTicket("Oppenheimer", 150m, true);
                cinema.AddTicket(t1);
                cinema.AddTicket(t2);
                cinema.AddTicket(t3);
                Console.WriteLine("--- All Tickets ---");
                cinema.PrintAllTickets();
                Console.WriteLine($"Total Tickets Created: {Ticket.GetTotalTickets()}");
                cinema.CloseCinema();
            }
        }

    }
#endregion
