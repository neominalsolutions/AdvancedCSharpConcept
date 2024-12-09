using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvancedCSharpConcept.ConsoleApp.RecordsAndTupples.RecordsAndTupplesSample;

namespace AdvancedCSharpConcept.ConsoleApp.StaticClasses
{
  // extension method tanımı için sınıfın static tanımlı olması lazım.
  // ilgili veri tipinin hem tipine hemde nesnenin kendisine müdehale etmeden nesneye veya veri tipine kazandırılan bir özellik.
  public static class CustomExtension
  {

    // extension method
    public static string ToLowerCase(this string value)
    {
      return value.ToLower();
    }


    public static string ParseToString(this Money value)
    {
      return $"{value.Amount} {value.Currency}";
    }


    public static string PrettyFormatDate(this DateTime value)
    {
      return $"{value.Day}/{value.Month}/{value.Year}";
    }


  }
}
