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

    public ObservableCollection<Service> Servers { get {
        return _servers; } }

    public ServiceListViewModel ()
    {
      _servers = new ObservableCollection<Service>();
      Model = new SlpModel.SlpModel();
      Model.ClearServices = delegate {
        View.Dispatcher.BeginInvoke( delegate {
          _servers.Clear();
        } );
      };

      Model.AddService = delegate(Service obj) {
        View.Dispatcher.BeginInvoke ( delegate {
          _servers.Add( obj );
        } );
      };

      RefreshCommand = new DelegateCommand( BeginRefresh, delegate ( object arg ) { return CanRefresh; } );
    }
    public DelegateCommand RefreshCommand { get; set; }

    public bool Refreshing { get; set; }
    public bool CanRefresh { get { return !Refreshing; } }

    public void EndRefresh( object unused )
    {
      Refreshing = false;
      OnPropertyChanged("Refreshing");
      OnPropertyChanged("CanRefresh");
      Console.WriteLine("finished");
    }

    public void BeginRefresh( object unused )
    {
      RefreshTask = new Task( View.Dispatcher );
      RefreshTask.Operation = Model.Refresh;
      RefreshTask.OnFinish = delegate { EndRefresh(null); };

      Refreshing = true;
      OnPropertyChanged("Refreshing");
      OnPropertyChanged("CanRefresh");

      RefreshTask.Start();

    }
  }
}

