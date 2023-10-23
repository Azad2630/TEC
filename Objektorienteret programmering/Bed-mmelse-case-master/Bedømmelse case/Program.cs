using System;
using System.Collections.Generic;

abstract class Doctor
{
    public string Name { get; }
    public string Specialization { get; }
    public string PhoneNumber { get; }
    public int AssignedPatients { get; set; }

    public Doctor(string name, string specialization, string phoneNumber)
    {
        Name = name;
        Specialization = specialization;
        PhoneNumber = phoneNumber;
        AssignedPatients = 0;
    }

    public abstract void AssignPatient(Patient patient);
}

class EyeDoctor : Doctor
{
    public EyeDoctor() : base("Peter Hansen", "øjenlæge", "11111111")
    {
    }

    public override void AssignPatient(Patient patient)
    {
        if (AssignedPatients >= 3)
        {
            throw new Exception("Lægen har allerede fået tildelt 3 patienter.");
        }

        AssignedPatients++;
    }
}

class RadiologyDoctor : Doctor
{
    public RadiologyDoctor() : base("Martin Jensen", "Radiologi", "22222222")
    {
    }

    public override void AssignPatient(Patient patient)
    {
        if (AssignedPatients >= 3)
        {
            throw new Exception("Lægen har allerede fået tildelt 3 patienter.");
        }

        AssignedPatients++;
    }
}

class SurgeryDoctor : Doctor
{
    public SurgeryDoctor() : base("Thomas Olsen", "Kirurgi", "33333333")
    {
    }

    public override void AssignPatient(Patient patient)
    {
        if (AssignedPatients >= 3)
        {
            throw new Exception("Lægen har allerede fået tildelt 3 patienter.");
        }

        if (patient.HasSpecialization("Onkologi"))
        {
            throw new Exception("En patient kan ikke have både en Kirurgi og en Onkologi læge.");
        }

        AssignedPatients++;
    }
}

class OncologyDoctor : Doctor
{
    public OncologyDoctor() : base("Ole Nielsen", "Onkologi", "44444444")
    {
    }

    public override void AssignPatient(Patient patient)
    {
        if (AssignedPatients >= 3)
        {
            throw new Exception("Lægen har allerede fået tildelt 3 patienter.");
        }

        if (patient.HasSpecialization("Kirurgi"))
        {
            throw new Exception("En patient kan ikke have både en Kirurgi og en Onkologi læge.");
        }

        AssignedPatients++;
    }
}

class Patient
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public List<Doctor> AssignedDoctors { get; }

    public Patient(string firstName, string lastName, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        AssignedDoctors = new List<Doctor>();
    }

    public bool HasSpecialization(string specialization)
    {
        foreach (var doctor in AssignedDoctors)
        {
            if (doctor.Specialization == specialization)
            {
                return true;
            }
        }
        return false;
    }

    public void AssignDoctor(Doctor doctor)
    {
        foreach (var assignedDoctor in AssignedDoctors)
        {
            if (assignedDoctor.Specialization == doctor.Specialization)
            {
                throw new Exception("Patienten har allerede en læge med samme specialisering.");
            }
        }

        if (AssignedDoctors.Count >= 3)
        {
            throw new Exception("Patienten har allerede fået tildelt 3 læger.");
        }

        doctor.AssignPatient(this);
        AssignedDoctors.Add(doctor);
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<Patient> patients = new List<Patient>();

        while (true)
        {
            Console.WriteLine("Registrer en ny patient:");
            Patient patient = RegisterPatient();

            EyeDoctor peterHansen = new EyeDoctor();
            RadiologyDoctor martinJensen = new RadiologyDoctor();
            SurgeryDoctor thomasOlsen = new SurgeryDoctor();
            OncologyDoctor oleNielsen = new OncologyDoctor();

            while (true)
            {
                Console.WriteLine("Vælg en læge at tildele patienten:");
                Console.WriteLine("1. Peter Hansen (øjenlæge)");
                Console.WriteLine("2. Martin Jensen (Radiologi)");
                Console.WriteLine("3. Thomas Olsen (Kirurgi)");
                Console.WriteLine("4. Ole Nielsen (Onkologi)");
                Console.WriteLine("5. Afslut og registrer en ny patient");
                Console.Write("Indtast valg (1-5): ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            patient.AssignDoctor(peterHansen);
                            break;
                        case 2:
                            patient.AssignDoctor(martinJensen);
                            break;
                        case 3:
                            patient.AssignDoctor(thomasOlsen);
                            break;
                        case 4:
                            patient.AssignDoctor(oleNielsen);
                            break;
                        case 5:
                            patients.Add(patient);
                            Console.WriteLine($"Patient {patient.FirstName} {patient.LastName} er tilmeldt følgende læger:");
                            foreach (var doctor in patient.AssignedDoctors)
                            {
                                Console.WriteLine($"{doctor.Name} ({doctor.Specialization})");
                            }
                            Console.WriteLine();
                            break;
                        default:
                            Console.WriteLine("Ugyldigt valg. Prøv igen.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ugyldigt input. Prøv igen.");
                }

                if (patient.AssignedDoctors.Count >= 3)
                {
                    Console.WriteLine("Patienten har allerede fået tildelt 3 læger.");
                    break;
                }
            }
        }
    }

    public static Patient RegisterPatient()
    {
        Console.Write("Indtast patientens fornavn: ");
        string firstName = Console.ReadLine();

        Console.Write("Indtast patientens efternavn: ");
        string lastName = Console.ReadLine();

        Console.Write("Indtast patientens telefonnummer: ");
        string phoneNumber = Console.ReadLine();

        return new Patient(firstName, lastName, phoneNumber);
    }
}
