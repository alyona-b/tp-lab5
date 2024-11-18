using System;
using System.Collections.Generic;

[AttributeUsage(AttributeTargets.Class)]
public class AnimalDietAttribute : Attribute
{
    public string DietType { get; }

    public AnimalDietAttribute(string dietType)
    {
        DietType = dietType;
    }
}

class Employee
{
    private string fullName;
    private int age;
    private double salary;
    private int experience;

    public string JobTitle { get; set; }

    public Employee(string fullName, int age, double salary, int experience, string jobTitle)
    {
        this.fullName = fullName;
        this.age = age;
        this.salary = salary;
        this.experience = experience;
        this.JobTitle = jobTitle;
    }

    public string GetFullName() => fullName;
    public int GetAge() => age;
    public double GetSalary() => salary;
    public int GetExperience() => experience;

    public void UpdateEmployeeInfo(string newFullName, int newAge, double newSalary, int newExperience)
    {
        fullName = newFullName;
        age = newAge;
        salary = newSalary;
        experience = newExperience;
    }
}

class Cleaner : Employee
{
    public Cleaner(string fullName, int age, double salary, int experience)
        : base(fullName, age, salary, experience, "уборщик")
    {
    }
}

class Guard : Employee
{
    public Guard(string fullName, int age, double salary, int experience)
        : base(fullName, age, salary, experience, "охранник")
    {
    }
}

class Trainer : Employee
{
    public Trainer(string fullName, int age, double salary, int experience)
        : base(fullName, age, salary, experience, "дрессировщик")
    {
    }
}

[AnimalDiet("Хищник")]
class Lion : Animal
{
    public Lion(string species, int count, int cageNumber)
        : base(species, count, cageNumber)
    {
    }
}

[AnimalDiet("Травоядное")]
class Giraffe : Animal
{
    public Giraffe(string species, int count, int cageNumber)
        : base(species, count, cageNumber)
    {
    }
}

[AnimalDiet("Хищник")]
class Cobra : Animal
{
    public Cobra(string species, int count, int cageNumber)
        : base(species, count, cageNumber)
    {
    }
}

class Animal
{
    private string species;
    private int count;
    private int cageNumber;

    public Animal(string species, int count, int cageNumber)
    {
        this.species = species;
        this.count = count;
        this.cageNumber = cageNumber;
    }

    public string GetSpecies() => species;
    public int GetCount() => count;
    public int GetCageNumber() => cageNumber;

    public void UpdateAnimalInfo(string newSpecies, int newCount, int newCageNumber)
    {
        species = newSpecies;
        count = newCount;
        cageNumber = newCageNumber;
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();
        employees.Add(new Cleaner("Иванов Иван Иванович", 30, 20000, 3));
        employees.Add(new Cleaner("Петров Петр Петрович", 25, 18000, 2));
        employees.Add(new Guard("Сидоров Алексей Андреевич", 35, 22000, 5));
        employees.Add(new Guard("Козлова Мария Викторовна", 28, 21000, 4));
        employees.Add(new Trainer("Захаров Василис Александрович", 40, 30000, 7));
        employees.Add(new Trainer("Смирнова Елена Викторовна", 32, 28000, 6));

        List<Animal> animals = new List<Animal>();
        animals.Add(new Lion("Лев", 2, 1));
        animals.Add(new Giraffe("Жираф", 3, 2));
        animals.Add(new Cobra("Кобра", 2, 3));

        while (true)
        {
            Console.WriteLine("Выберите опцию:");
            Console.WriteLine("1. Посмотреть информацию о сотрудниках по должности");
            Console.WriteLine("2. Посмотреть информацию о животных по виду");
            Console.WriteLine("3. Внести изменения в информацию о сотрудниках");
            Console.WriteLine("4. Внести изменения в информацию о животных");
            Console.WriteLine("5. Выйти");

            string option = Console.ReadLine();

            if (option == "1")
            {
                Console.Write("Введите должность сотрудника (уборщик, охранник, дрессировщик): ");
                string jobTitle = Console.ReadLine();

                Console.WriteLine($"Информация о сотрудниках с должностью '{jobTitle}':");
                foreach (var employee in employees)
                {
                    if (employee.JobTitle.Equals(jobTitle, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"ФИО: {employee.GetFullName()}");
                        Console.WriteLine($"Возраст: {employee.GetAge()}");
                        Console.WriteLine($"Зарплата: {employee.GetSalary()}");
                        Console.WriteLine($"Стаж работы: {employee.GetExperience()}");
                        Console.WriteLine();
                    }
                }
            }
            else if (option == "2")
            {
                Console.Write("Введите вид животного (Лев, Жираф, Кобра): ");
                string species = Console.ReadLine();

                Console.WriteLine($"Информация о животных вида '{species}':");
                foreach (var animal in animals)
                {
                    if (animal.GetSpecies().Equals(species, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Вид: {animal.GetSpecies()}");
                        Console.WriteLine($"Количество: {animal.GetCount()}");
                        Console.WriteLine($"Номер клетки: {animal.GetCageNumber()}");
                        Console.WriteLine();
                    }
                }
            }
            else if (option == "3")
            {
                // Внесение изменений в информацию о сотрудниках
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Изменить информацию о сотруднике");
                Console.WriteLine("2. Назад");

                string actionOption = Console.ReadLine();

                if (actionOption == "1")
                {
                    Console.Write("Введите ФИО сотрудника, информацию о котором вы хотите изменить: ");
                    string fullName = Console.ReadLine();

                    Employee employeeToModify = employees.Find(e => e.GetFullName() == fullName);
                    if (employeeToModify != null)
                    {
                        Console.Write("Введите новое ФИО: ");
                        string newFullName = Console.ReadLine();

                        Console.Write("Введите новый возраст: ");
                        int newAge = int.Parse(Console.ReadLine());

                        Console.Write("Введите новую зарплату: ");
                        double newSalary = double.Parse(Console.ReadLine());

                        Console.Write("Введите новый стаж работы: ");
                        int newExperience = int.Parse(Console.ReadLine());

                        Console.Write("Введите новую должность: ");
                        string newJobTitle = Console.ReadLine();

                        // Вызываем метод для изменения информации о сотруднике.
                        employeeToModify.UpdateEmployeeInfo(newFullName, newAge, newSalary, newExperience);
                        employeeToModify.JobTitle = newJobTitle;

                        Console.WriteLine("Информация о сотруднике успешно обновлена.");
                    }
                    else
                    {
                        Console.WriteLine("Сотрудник с указанным ФИО не найден.");
                    }
                }
                else if (actionOption == "2")
                {
                    // Возврат в предыдущее меню
                }
            }
            else if (option == "4")
            {
                // Внесение изменений в информацию о животных
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Изменить информацию о животном");
                Console.WriteLine("2. Назад");


                string actionOption = Console.ReadLine();

                if (actionOption == "1")
                {
                    Console.Write("Введите вид животного, информацию о котором вы хотите изменить: ");
                    string species = Console.ReadLine();

                    Animal animalToModify = animals.Find(a => a.GetSpecies().Equals(species, StringComparison.OrdinalIgnoreCase));
                    if (animalToModify != null)
                    {
                        Console.Write("Введите новый вид животного: ");
                        string newSpecies = Console.ReadLine();

                        Console.Write("Введите новое количество животных: ");
                        int newCount = int.Parse(Console.ReadLine());

                        Console.Write("Введите новый номер клетки: ");
                        int newCageNumber = int.Parse(Console.ReadLine());

                        // Вызываем метод для изменения информации о животном.
                        animalToModify.UpdateAnimalInfo(newSpecies, newCount, newCageNumber);

                        Console.WriteLine("Информация о животном успешно обновлена.");
                    }
                    else
                    {
                        Console.WriteLine("Животное с указанным видом не найдено.");
                    }
                }
                else if (actionOption == "2")
                {
                    // Возврат в предыдущее меню
                }
            }
            else if (option == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Неверная опция. Пожалуйста, выберите 1, 2, 3, 4 или 5.");
            }
        }
    }
}