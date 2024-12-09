using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharpConcept.ConsoleApp.EventsDelegates
{
  public class PostSaveArgs:EventArgs
  {
    public string Name { get; init; }
    public string Id { get; init; }

  }

  // Bu sınıfın içerisinde bu hizmet içerisinde bir değerdeki değişimi takibe almak istiyoruz
  public class EventSamples
  {
    // listener.
    public event EventHandler<PostSaveArgs> PostSave;


        public EventSamples()
        {
          PostSave += EventSamples_PostSave; // listener bir EventHandler delegate üzerinden bir methodu işletmesini sağlamak. 
    }

    private void EventSamples_PostSave(object? sender, PostSaveArgs e)
    {
      Console.Out.WriteLine(e.Id +" " + e.Name);
      // Send Mail Logici uygulanacak.
      SendEmail();
    }

    // Veri tabanına bir kayıt gerçekleştiği anda çalışması gereken kod
    // Kayıt gerçekletştikten sonra bir event ile bizim bu kaydı takip edene operasyon ekebine mail atmamız gerekiyor
    public void Save()
    {
      // Repository.Save();

      // bu kod bloğu yerine event fılatarak işlemi evente devretseydik aslında daha bağımlılığı düşük bir kod yazmış olucaktık.

      // Side Effects
      // Find Subscribers.Find(Id);
      // SendEmail
      // SendEmail(); sorunu çözmek için ilgileri ayırdık.

      // Method sonucunda bir side effect var. Policy bir poliçe uygulanacak.
      // event olarak bunu çağıralım.

      PostSave.Invoke(this, new PostSaveArgs { Id = "1", Name = "Test" });
    }

    public void SendEmail()
    {
      // Find Subscribers.Find(Id);
      // SendEmail
    }

  }
}
