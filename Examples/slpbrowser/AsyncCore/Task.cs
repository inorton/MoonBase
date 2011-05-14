using System;
using System.Windows.Threading;
using System.ComponentModel;
using System.Threading;

namespace AsyncCore
{
  public class Task
  {
    private Thread waitThread = null;
    private Thread operationThread = null;
    private bool terminating = false;
    
    public Dispatcher Dispatcher { get; private set; }

    public Action Operation { get; set; }
    public Action OnFinish { get; set; }
    public Action<Exception> OnException { get; set; }
    
    public Task( Dispatcher forui )
    {
      Dispatcher = forui; 
    }
    
    public void Terminate()
    {
      if ( IsRunning ){
        terminating = true;
        operationThread.Abort();
      }
    }
    
    public bool IsRunning {
      get {
        if ( operationThread == null ) return false; 
        return operationThread.IsAlive;
      }
    }
    
    public void Start()
    {
        
      if ( IsRunning ) 
        throw new InvalidAsynchronousStateException("this task has already started");
      if ( Operation == null )
        throw new ArgumentNullException("no operation");

      operationThread = new Thread( StartOperation );
      waitThread = new Thread( Execute );
      terminating = false;
      waitThread.Start();

    }

    private void StartOperation()
    {
      if ( Operation != null ){
        Operation();
      }
    }
    
    private void Execute()
    {
      try {
        operationThread.Start();  
        operationThread.Join();
      } catch ( Exception ex ){
        if ( OnException != null ) 
          OnException( ex );
      }
      
      if ( !terminating )
        if ( OnFinish != null )
          Dispatcher.BeginInvoke( OnFinish );
    }
    
    ~Task()
    {
      if ( waitThread != null )
        if ( waitThread.IsAlive )
          waitThread.Abort();
    }
  }
}

