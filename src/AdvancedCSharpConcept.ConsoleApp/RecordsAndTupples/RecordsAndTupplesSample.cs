using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharpConcept.ConsoleApp.RecordsAndTupples
{

  // Records
  // 1. özelliği Equality özelliği iki farklı nesnenin değer eşitliğine bakar, class gibi referans eşitliğine bakmaz
  // 2. Fakat class gibi referance type olarak tanımlıdır. Heap bölgesinde tutulur
  // 3. Immutable olarak çalışmak için ideal bir tanımlamadır. Değerler initialize aşamasında set edilir daha sonradan değiştirilemez. Classlar ise Mutable Type kategorisine girer.




  public class RecordsAndTupplesSample
  {
    public record Money(decimal Amount, string Currency);

    public class MoneyClass(decimal Amount,string Currency) // Mutable type
    {
      public decimal Amount { get; set; } = Amount;
      public string Currency { get; set; } = Currency;

      public override bool Equals(object? obj)
      {
        return base.Equals(obj);
      }
    }


    public RecordsAndTupplesSample()
    {
      var m1 = new Money(1000, "TL");
      var m2 = new Money(1000, "TL"); // event ve request (DTO) veya value Object nesneleri için tercih ederiz.
      // Value Objectler Entitylerden farklı olarak Id (Identity) değeri barındırmaz, kıyaslama sadece değerlerine bakılarak yapılan nesneler. Location(X,Y), Money(Amount,Currency), Person(FullName,LastName), Address(City,Country,ZipCode)

      m1.Equals(m2); // true; değer eşitliğinde dolayı true

      var m3 = new MoneyClass(1000, "TL");
      var m4 = new MoneyClass(1000, "TL");
     

      m3.Equals(m4); // false çıktı verir. Çünkü referans eşitliğine bakar.


      // Immutable type özelliği
      // m1.Amount = 5000;
      // Bazlı Property değerleri Immutable çalışmaları. Hesap açılış Bakiyesi 0
      // Hesap Numarası => ilk nesne yada hesap ilk açılışında set ederiz daha sonra bunu güncelleyemeyiz sadece silebiliriz. (Hesap pasif hale yada hesap kapanmalıdır.)


      // Class tanımında ilgili propertylere contructor üzerinden init edildiklerinden dolayı erişilemez (decimal Amount,string Currency) constructor init işlemine class tabi tutulursa tüm constructordaki bilgileri private olarak kalır.
      // m4.Amount = 5000;
      m4.Amount = 5000;


      // Not: record tipleri Immutable olarak tanımlandıklarından ötürü with keyword ile değer değiştirilip yeni bir record nesnesi oluşturubilir.

      var m6 = m1 with { Amount = 450, Currency = "$" };
      //m1.Amount = 450;

      m6.Equals(m1);

      // record başka bir record'dan inherit olabilir
      // class içinde record tanımı yapılabilir fakat record içinde class tanımlanamaz.

    }
  }
}
