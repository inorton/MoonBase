using System;

namespace slpmoon
{
  public class HomeViewModel : ViewModelBase
  {
    public HomeViewModel ()
    {
      Greeting = DateTime.Now.ToString();
    }

    public string Greeting { get; set; }
  }
}
