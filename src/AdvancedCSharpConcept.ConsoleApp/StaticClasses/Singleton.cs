using System;
using System.Linq;
using System.Text;


namespace AdvancedCSharpConcept.ConsoleApp.StaticClasses
{
  // Thread Safe Singleton Design Patterns
  // Uygulamadan birden fazla yerden erişim sağlamamız gereken bir global değişken varsa bu yöntemi tercih edebiliriz.

  public sealed class Singleton
  {
    // ilk instance lazy alıyor
    // 4.0 ve sonrası Net Framework hemde Net Core versiyonlarının tümü
    private static readonly Lazy<Singleton> lazy =
        new Lazy<Singleton>(() => new Singleton());

    // lazy.Value; thread safe singleton instance value
    public static Singleton Instance { get { return lazy.Value; } }

    // constructor dışarı kapalı oluyor. bu sayede sadece 1 kereye mahsus nesne instance alınyor.
    private Singleton()
    {
    }

    public void DoWork()
    {
      Console.Out.WriteLine("Test");
    }
  }
}
