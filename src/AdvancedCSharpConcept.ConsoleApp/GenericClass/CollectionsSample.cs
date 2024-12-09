using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvancedCSharpConcept.ConsoleApp.GenericClass.GenericClassSample;

namespace AdvancedCSharpConcept.ConsoleApp.GenericClass
{



  public class CollectionsSample
  {

    public CollectionsSample()
    {
      // Stack (LIFO) ve Queue (FIFO)


      Stack<int> numbers = new Stack<int>();
      numbers.Push(10);
      numbers.Push(15); // 15,10

      numbers.Pop(); // en baştaki değer çıkartır => // 15
      numbers.Peek(); // LIFO en son girilen değerin koleksiyondan getirilmesini sağlar.


      Queue<string> names = new Queue<string>();
      names.Enqueue("ali");
      names.Enqueue("ahmet"); // ali => ahmet
      names.Dequeue(); // ali FIFO  remove ali

      names.Peek(); // ali remove etmeden değeri döndürür.


      // her hangi bir tipi koleksiton içerisinde tutmamızı sağlar.
      ArrayList ar = new ArrayList(); // IList, ICollection, IClone, IEnumerable bu interfaceler collection ifadelerinin temelini oluşturur.
      ar.Add(1);
      ar.Add("ali");
      ar.Add(true);


      // Generic Collections
      // Dictionary<Tkey,TValue> => redis gibi memcache gibi key value pair değer tutan ifadelerde genelikle kullanılır
      // unique bir key değeri üzerinden koleksiyona ekleme çıkarma yapar.
      Dictionary<string, int> points = new();

      points["cansu"] = 55;
      points.Add("ali", 100);
      points.Add("ahmet", 200); // ali 100 => ahmet 200

      points["ali"] = 45; // aynı key sahip olacağından değer güncellenir.
      

      // int point = points["ali"];

      // points.Add("ali", 150); // aynı key değerini veremeyiz.

      foreach (KeyValuePair<string, int> item in points)
      {
        Console.Out.WriteLine(item.Key + " " + item.Value);
      }

      points.Remove("ali"); // key üzerinden remove etme


      // Hashset<T>

      // value yada referans type değerlerde dizi içerisinde aynı değer yada referans varsa diziye eklenmemesini sağlar.

      HashSet<int> numbers2 = new(); // ISet interfaceden implemente edilir.
      numbers2.Add(1);
      numbers2.Add(2);
      numbers2.Add(1); //  1,2 exception vermez ama aynı değeri eklemez.
      numbers2.Add(7);

      HashSet<int> numbers3 = new();
      numbers3.Add(5);
      numbers3.Add(2);


      var p1 = new Product();
      HashSet<Product> products = new();
      products.Add(p1);
      products.Add(p1);

      var unionSets =  numbers2.Union(numbers3);

      var intersectSets = numbers2.Intersect(numbers3); // 2
                                                        // Collection<T> veya List<T>

      var exceptSets = numbers2.Except(numbers3); // 1,7 numbers2 listede bulunup numbers3 listede bulunmayanlar.
      // Collection<T> veya List<T>

      var clist = new Collection<string>();
      Collection<string> clist2 = ["istanbul", "ankara", "bursa"];
      
  
      // en çok kullanılan collection tipimiz.
      var plist = new List<string>(); // range methodları, find (Predicate Delegate), tüm find ile başlayan methodlar list'e özgüdür.
      List<string> plist2 = ["istanbul", "ankara", "bursa"];

      // Non Thread Safe => Yukarıdaki tüm collection ifadeleri senkron programlama için kullanılır.

      // Thread Safe çalışan collection yapıları System.Collections.Concurrent namespaceden gelir. Multi Thread Programlarda shared data olarak collectionlara atılan bilgileri race condition durumu yaratmadan güvenli bir şekilde collection içerisinde tutmak için kullanılır.


      // C# 13 ile gelen Lock object tipi ile shared data da thread safe işlemler yapabiliriz.
      // private readonly System.Threading.Lock _balanceLock = new();

      // Not: Thread Safe Collection ifadelerinde using keywordleri ile çalışmaya özen gösterelim. // listeye eleman ekleme işlemlerini kapatabiliriz. complete method ile sonlandırabiliriz.
      // Concurency Collection ifadelerinde item çıkarmak için tryTake methodu kullanıyoruz.
      // Attempts to remove and return an object from the ConcurrentBag<T>.
      // Sıranın önemli olmadığı durumlarda BlockingCollection kendi içerisinde bloklama lock kitleme blocklama algoritmasına sahip olduğundan  ConcurrentBag göre çok daha yavaştır.
      // Bu tarz durumlarda tercih etmiyoruz. Fakat koleksiyon içerisindeki itemların kapasitelerini berlirlenmesi, item ekleme işlemini kapatılması veya sıralı olarak paralel kodların işlenmesini ve sıralı olarak listeye atılmasının gerektiği ekstrem durumlarda ConcurrentBag yerine kullanımı daha güvenlidir.
      BlockingCollection<int> nm4 = new();
      // nm4.CompleteAdding(); bu collcetiona özgü bir capacity kontrol işlemidir.

      // birbirinden bağımsız çalışan paralel programlanmış kod bloklarında kullanımı performans sağlar. Genelde işlemler bunun üzerine kurgulanır.
      ConcurrentBag<int> nm5 = new();


      ConcurrentDictionary<string, DateTime> paths = new();
      paths["/api/products/v2"] = DateTime.Now;

      DateTime d = paths.AddOrUpdate("/api/products", DateTime.Now, (key, newDate) => newDate);

      // InterLock, numeric ve sayısal değerlerin Thread Safe hesaplanması için kullanılan bir sınır
      int value = 10;
      Interlocked.Add(ref value, 25); // 35, SUM
      Interlocked.Decrement(ref value); // 9 1 azalt
      Interlocked.Increment(ref value); // 11 yap


    }
  }
}
