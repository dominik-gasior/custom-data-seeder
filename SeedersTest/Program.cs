// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using Seeders;
using SeedersTest.Model;

var seeder = new Seeder(new JsonSerializerSettings());
var car = seeder.FromJson<IEnumerable<Car>>("Json");
Console.WriteLine(car.First().CompanyName);

var car2 = seeder.FromJson<Car>("Json2");
Console.WriteLine(car2.CompanyName);

var car3 = seeder.FromJsonToFaker<IEnumerable<Car>>("Json").Generate();
Console.WriteLine(car3.First().CompanyName);

var car4 = seeder.FromJsonToFaker<Car>("Json2").Generate();