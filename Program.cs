using System;
using static Employee;



Employee employee = new("Milovan", 30, 5);
Employee employee2 = new("Ivana", 31, 4);

EmployeeDbFake.ListAllNames();








employee.Earn(99990000);
employee.Earn(-1);
employee.Spend(1000000);
employee.Spend(3000000000);
employee.Spend(-1000000);
employee.Spend(0);

public abstract class Person
{
    public string Ime { get; set; }
    public int GodineStarosti { get; set; }


    public Person(string ime, int godineStarosti)
    {
        Ime = ime;
        GodineStarosti = godineStarosti;        
    }
}

public interface IPayable
{
    void Earn(double iznos);
    void Spend(double iznos);
}

public class Employee : Person, IPayable



{

    public int Staz { get; set; }


    public double BankovniRacun { get; private set; } = 200000;

    public Employee(string ime, int godineStarosti, int staz)
        : base(ime, godineStarosti)
    {
        Staz = staz;
        EmployeeDbFake.employeeList.Add(this);
    }


    public void Earn(double iznos)
    {
        if (iznos > 0)
        {
            BankovniRacun += iznos;
            Console.WriteLine($"{Ime} je zaradio {iznos} dinara. Trenutno stanje: {BankovniRacun} dinara.");
        }
        else
        {
            Console.WriteLine("Iznos mora biti pozitivan.");
        }
    }

    public void Spend(double iznos)
    {
        if (iznos > 0 && iznos <= BankovniRacun)
        {
            BankovniRacun -= iznos;
            Console.WriteLine($"{Ime} je potrošio {iznos} dinara. Trenutno stanje: {BankovniRacun} dinara.");
        }
        else if (iznos > BankovniRacun)
        {
            Console.WriteLine("Transakcija nije moguća. Nemate dovoljno sredstava na računu.");
        }
        else
        {
            Console.WriteLine("Iznos mora biti pozitivan");
        }
    }

    public bool IsSpendAmountValid (double iznos)
    {
        return iznos > 0 && iznos <= BankovniRacun;
    }
    
    public static class EmployeeDbFake
    {
        public static List<Employee> employeeList = [];

        public static void ListAllNames()
        {
            foreach (Employee e in employeeList)
            {
                Console.WriteLine(e.Ime);
            }
        }
    }

    
}

