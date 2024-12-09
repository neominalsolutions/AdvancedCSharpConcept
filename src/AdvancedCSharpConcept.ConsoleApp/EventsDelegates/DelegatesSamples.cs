using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharpConcept.ConsoleApp.EventsDelegates
{
  // delegate: Methodların yönetilmesinden çalıştırılmasında sorumlu kod parçacıkları

  public delegate void MessageHandler(string message);

  public delegate void OperationHandler(string message);
 

 

  public class DelegatesSamples
  {
    public void OnSuccess(string message)
    {
      Console.WriteLine("Success");
    }

    public void OnError(string message)
    {
      Console.WriteLine("Error");
    }

    public class SendEmail()
    {
      public void ShowMessage(string message)
      {
        Console.Out.WriteLine($"email: {message}");
      }
    }

    public class SendSms()
    {
      public void ShowMessage(string message)
      {
        Console.Out.WriteLine($"sms: {message}");
      }
    }


    public class DelegateInvoker
    {
      // Method içerisinde delegate parametre olarak gönderme yöntemi
      public void Invoke(string message, OperationHandler handler)
      {
        Console.Out.WriteLine("Invoker");
        bool isSuccess = !String.IsNullOrEmpty(message);

        Delegate[] delegates =  handler.GetInvocationList();

        if (isSuccess)
        {
          delegates[0].DynamicInvoke(message); // OnSuccess
        }
        else
        {
          delegates[1].DynamicInvoke(message); // OnError
        }
        // buradaki logic sonucunda başka bir eylem tetikleyip süreci handler delegate üzerinden yönetmiş oluyoruz
        //handler(message);
      }


      public void Handle(Action<string> action)
      {
        action("Test");
      } 

    }

  }
}
