// See https://aka.ms/new-console-template for more information
using AdvancedCSharpConcept.ConsoleApp.GenericClass;
using AdvancedCSharpConcept.ConsoleApp.RecordsAndTupples;
using AdvancedCSharpConcept.ConsoleApp.StaticClasses;
using System.Dynamic;
using static AdvancedCSharpConcept.ConsoleApp.GenericClass.GenericClassSample;
using static AdvancedCSharpConcept.ConsoleApp.RecordsAndTupples.RecordsAndTupplesSample;

Console.WriteLine("Hello, World!");

// Generic Class
// Collections (Thread Safe, Concurency Collections)
// Static Class
// Extension Method
// Tupples & Records
// Serialization JSON, System Text JSON
// C# ile gelen yenilikler
// Events and Delegates


#region GenericClass

ProductRepository pr = new();
pr.Create(new Product { Id = Guid.NewGuid() });

CategoryRepository cr = new();
cr.Create(new Category { Id = 1 });

RepositoryBase<Product, Guid> pr2 = new ProductRepository();

pr2.Create(new Product());


#endregion


#region Collections

CollectionsSample cs = new();


#endregion


#region Records&Classes

RecordsAndTupplesSample sp = new RecordsAndTupplesSample();

#endregion

#region Tupples

// anlık veri tipine ihtiyaç duyduğumuz da kullandığımız bir veri demeti.
// C# 7.0 ve sonrasında kullanılan bir anlık veri demeti tipi.

// MVC mimarisinde ViewBag tanımları dynamic olarak tutuluyor. Dynamic runtime aşamasında verilerin tiplerinin berlirlendiği bir an. Genelde farklı bir uygulamadan çekilen bilgilere ait bir tip tanımımız yoksa tipin karşlığı yok ise bu gibi durumlarda dynamic tipini kullanabiliriz.

dynamic student = new ExpandoObject();
student.name = "ali";
student.surname = "tan";


// 1.yöntem
var tp = Tuple.Create<int, string, string>(1,"ali","tan"); // construction aşması
int age = tp.Item1; // deconstruction aşaması
string name = tp.Item2; // View Model

// 2.yöntem
var person = ("ali", "tan", 23);
int _age = person.Item3;
string _name = person.Item1;
string _lastname = person.Item2;


// 3.yöntem
var tp2 = new Tuple<int,string>(1, "ali");
Console.Out.WriteLine(tp2.Item1);

static (string city, string country, string zipCode)  GetAddressInfo(string city,string country,string zipCode)
{
  return (city, country, zipCode);
}

var address = GetAddressInfo("istanbul", "türkiye", "34000");
Console.Out.WriteLine(address.city);





#endregion


#region StaticClass


StaticClassSamples.FormatDate(DateTime.Today);

// Global Variables
StaticClassSamples.GuestCount++;
StaticClassSamples.GuestCount = 0;


string Name = "ali";

string NameLower = Name.ToLowerCase();

char[] chars =  Name.ToArray();

var money01 = new Money(500,"$");
money01.ParseToString(); // 500 $



//var l = Name.ToCharArray().Sum((Func<char, decimal> func) =>
//{
//  Console.WriteLine(ch);
//  Console.WriteLine(dc);

//  return func;
//});


//StaticClassSamples.Id = 789;


Singleton.Instance.DoWork(); // 1. instance alınır
Singleton.Instance.DoWork(); // 2. instance alınmadan method direkt olarak tetiklenecektir.

#endregion