using System;
using System.Collections.ObjectModel;
using Mono.MoonDesk;
using Mono.MoonDesk.Commands;

using Service = SlpModel.Service;

using AsyncCore;

namespace ViewModels
{
  public class ServiceListViewModel : ViewModelBase
  {
    public SlpModel.SlpModel Model { get; set; }

    private Task RefreshTask = null;
    private ObservableCollection<Service> _servers;

    public ObservableCollection<Service> Servers {
      get {
        return _servers;
      }
    }

    public ServiceListViewModel ()
    {
      Refreshing = false;
      _servers = new ObservableCollection<Service> ();
      Model = new SlpModel.SlpModel ();
      Model.ClearServices = delegate {
        Dispatcher.BeginInvoke (delegate {
          _servers.Clear ();
        });
      };

      Model.AddService = delegate(Service obj) {
        Dispatcher.BeginInvoke (delegate {
          _servers.Add (obj);
        });
      };

      RefreshCommand = new DelegateCommand (BeginRefresh, CanRefresh );
    }

    public DelegateCommand RefreshCommand { get; set; }

    public bool Refreshing { get; set; }

    public bool CanRefresh( object arg ){ return !Refreshing; }

    public void EndRefresh (object unused)
    {
      lock (Model) {
        DispatchNotifySetProperty( () => Refreshing, false );

        RefreshCommand.CanExecute(null);

        Console.WriteLine ("finished");
      }
    }

    public void BeginRefresh (object unused)
    {
      lock (Model) {
        Console.WriteLine("start");
        DispatchNotifySetProperty( () => Refreshing, true );


        RefreshTask = new Task (Dispatcher);
        RefreshTask.Operation = Model.Refresh;
        RefreshTask.OnFinish = delegate { EndRefresh (null); };
        RefreshCommand.CanExecute(null);

        RefreshTask.Start ();
      }
    }
  }
}

