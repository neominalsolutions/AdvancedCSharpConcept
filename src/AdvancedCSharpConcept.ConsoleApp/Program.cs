// See https://aka.ms/new-console-template for more information
using AdvancedCSharpConcept.ConsoleApp.EventsDelegates;
using AdvancedCSharpConcept.ConsoleApp.GenericClass;
using AdvancedCSharpConcept.ConsoleApp.RecordsAndTupples;
using AdvancedCSharpConcept.ConsoleApp.StaticClasses;
using System.Dynamic;
using System.Reflection;
using static AdvancedCSharpConcept.ConsoleApp.EventsDelegates.DelegatesSamples;
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


StaticClassSamples.FormatDate(DateTime.Today); // Static Class ile Utility

DateTime.Today.PrettyFormatDate(); // Extension Method hali

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


#region DelegateSamples

var emailSender = new SendEmail();
// emailSender.ShowMessage("Bildirim");
var smsSender = new SendSms();
// smsSender.ShowMessage("Bildirim");

// Multi cast delegate, birden fazla methodun delegate üzerinden sıralı bir şekilde çağırılması
MessageHandler messageHandler = emailSender.ShowMessage;
messageHandler += smsSender.ShowMessage;

// 2.yöntem
MessageHandler messageHandler2 = new(emailSender.ShowMessage);
messageHandler2 += smsSender.ShowMessage;

// delegate üzerinden method tetikleme yöntemi
messageHandler.Invoke("Bildirim");


// 2. kullanım şekli

DelegatesSamples dg = new();

OperationHandler sh = dg.OnSuccess;
sh += dg.OnError;


DelegateInvoker di = new();
di.Invoke("", sh); // onError
di.Invoke("success", sh); // onSuccess, Javascript Callback yaklaşımının C# versiyonu


// Action Delegate Func Delegate 
// Func Delegate değer döndüren delegate
// Action void tanımlı doışarıdan parametre alan delegate

Action<string> ShowMessageAction = message =>
{
  Console.Out.WriteLine(message);
};


di.Handle(ShowMessageAction);


Func<int, int, int> Toplama = (int sayi1, int sayi2) =>
{
  return sayi1 + sayi2;
};


List<int> numbers05 = [1, 2, 3, 4];
List<int> numbers06 = [10, 20, 30, 40];


int totalSum = 0;

numbers05.ForEach((item) =>
{
  numbers06.ForEach((item2) =>
  {
    totalSum += Toplama(item, item2);
  });
});

Console.Out.WriteLine("Toplam" + totalSum);

// Son olarak Dynamic Delegate Runtime da Reflection üzerinde bir sınıfa ait methodu bulup ön tanımlı bir delegate üzerinden methodunun run edilmesini sağlar. Plugin bazlı geliştirilen uygulamalarda benzer yöntemeler uygulanabilir.
// 

var sendEmailInstance = Activator.CreateInstance<SendEmail>();
MethodInfo methodInfo = typeof(SendEmail).GetMethod("ShowMessage");

// MessageHandler delegate üzerinden methodInfo ait değeri tetikleme için bir delegate create ettik
Delegate dynamicDelegate = Delegate.CreateDelegate(typeof(MessageHandler), sendEmailInstance, methodInfo);

dynamicDelegate.DynamicInvoke("Dynamic Mesaj");



#endregion


#region EventSamples

EventSamples es = new();
es.PostSave += Es_PostSave; // MultiCasting
es.Save();

void Es_PostSave(object? sender, PostSaveArgs e)
{
  Console.WriteLine("Tetiklendi");
}




#endregion