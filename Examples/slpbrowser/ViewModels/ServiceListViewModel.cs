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

    public ObservableCollection<Service> Servers { get {
        if ( Model == null ) return null;
        return Model.Services;
      } }

    public ServiceListViewModel ()
    {
      Model = new SlpModel.SlpModel();


      RefreshCommand = new DelegateCommand( BeginRefresh, CanRefresh );


    }
    public DelegateCommand RefreshCommand { get; set; }

    public bool CanRefresh( object unused )
    {
      return !Refreshing;
    }

    public bool Refreshing { get; set; }

    public void EndRefresh( object unused )
    {
      OnPropertyChanged("Refreshing");
      OnPropertyChanged("CanRefresh");
      Refreshing = false;
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

