using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

using SlpSharp;

namespace SlpModel
{
  public class SlpModel
  {
    public SlpModel()
    {
    }

    public Action ClearServices { get; set; }
    public Action<Service> AddService { get; set; }

    public void Refresh()
    {
      if ( ClearServices != null )
        ClearServices();

      using ( var slp = new SlpClient( null ) ){
        slp.FindTypes( string.Empty, null, delegate ( string type ){
          
          using ( var _slp = new SlpClient( null ) ){
            _slp.Find( type, null, delegate ( string server, UInt16 lifetime ) {

              var serv = new Service(){ Address = server, Lifetime = lifetime };
              if ( AddService != null )
                AddService( serv );
            } );
          }          
        } );
      }
    }
    
  }
}

