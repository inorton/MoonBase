using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

using AsyncCore;
using SlpSharp;

namespace SlpModel
{
  public class SlpModel
  {
    public void Refresh()
    {
      Services.Clear();
      // find service types
      using ( var slp = new SlpClient( null ) ){
        slp.FindTypes( string.Empty, null, delegate ( string type ){
          
          using ( var _slp = new SlpClient( null ) ){
            _slp.Find( type, null, delegate ( string server, UInt16 lifetime ) {
              Services.Add( new Service(){ Address = server, Lifetime = lifetime } );
            } );
          }          
        } );
      }
    }
    
    
    public ObservableCollection<Service> Services { get; private set; }
    
  }
}

