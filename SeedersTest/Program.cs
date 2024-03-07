// See https://aka.ms/new-console-template for more information

using Seeders;
using SeedersTest.Model;

var car = Seeder.FromJson<Car>("Json");
Console.WriteLine(car.CompanyName);

var car2 = Seeder.FromJson<Car>("Json2");
Console.WriteLine(car2.CompanyName);