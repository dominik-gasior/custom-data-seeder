// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using Seeders;
using SeedersTest.Model;

var seeder = new Seeder(new JsonSerializerSettings());
var car = seeder.FromJson<Car>("Json");
Console.WriteLine(car.CompanyName);

var car2 = seeder.FromJson<Car>("Json2");
Console.WriteLine(car2.CompanyName);