using System;
namespace SlpModel
{
  public class Service
  {
    public Service ()
    {
    }
    
    public string Address { get; set; }
    public int Lifetime { get; set; }
    
    public override string ToString ()
    {
      return string.Format ("[Service: Address={0}, Lifetime={1}]", Address, Lifetime);
    }
  }
}

