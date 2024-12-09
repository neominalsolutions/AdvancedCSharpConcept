using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharpConcept.ConsoleApp.StaticClasses
{
  // Unit Test açısında static sınfılar test edilemediğinden, bir bağımlık oluşturuyor. Bu sebeple ilgili static sınıfı çağıran sınıfların test edilmesini engelliyor.
  public static class StaticClassSamples
  {
    public const int SerialNumber = 123; // Not, static readonly arasındaki fark const ifade direkt ddl içerisine gömülü olarak yazdığından dolayı dll ve dll bulun duğu dependiciler derlenmeden değerdeki değişikliği alamıyoruz.
    public static readonly int Id = 456; // proje bazlı ilgili değeri kendi runtime okuyor.


    public static int GuestCount = 0; // Not: Global Shared değişkenler için static class yönetmi thread safe çalışmadığı için önermiyoruz.


    static StaticClassSamples()
    {

    }

    // static veya const tipinde üye tanımı yapabiliriz.
    // instance almadan sınıfın isminden ilgili property veya methodlara erişim sağlayabilir (static olmak zorunda yada const olarak tanımlı bir property olabilir)
    // Genellikle Utility işlemlerinde, bir nesnenin farklı bir örneğine ihtiyaç duyulmayan durumlarda kullanılır.
    // formatting, parsing, convert gibi utiliy işlemleri için tercih edilirler.
    // global değişken olarak bir değişkenin tanımlanıp uygulama birden fazla yerden bu global değişken ulaşmak istendiği durumlarda kullanılır.
    // thread safe çalışacağımız durumlarda lock Object veya Thread Safe sınıflar ile kullanımını tercih etmeliyiz.

    // uygulama ayakta olduğu süre boyunca tek bir instance üzerinden çalışan sınıflar. memory kullanım olanlar non-static class göre daha az.

    public static string FormatDate(DateTime dateTime)
    {
      return "12/10/2020";
    }


  }
}
