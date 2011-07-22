MoonDesk / MoonBase - (c)2011 Ian Norton
========================================

MoonDesk is a small set of wrapper libraries to make it easier to write 
GUI applications that use silverlight controls that will run on linux 
as desktop applications. With a little care and some projects that share
source files you can make a WPF and Moonlight version of your program
(see the included hello example)

Using MoonBase
--------------

Using MoonBase you can develop apps that make use of the silverlight
controls, xaml and the MVVM pattern (and all the databinding goodness
that comes with it)

    using Moonlight.Gtk;
    using System.Windows;
    using System.Windows.Controls;
    using Mono.MoonDesk;

    public class MyGui {
     public static void Main( int argc, char[] argv ){
      Gtk.Application.Init();
      MoonBase.Init();

      AWindow win = new AWindow();
      ViewLoader loader = new ViewLoader( win.Host );
      
      // load from a xaml resource file and create your view model at the same time
      VVM foo = loader.LoadViewViewModel<MyViewModelClass>("MyXamlAssembly;MyNamespace/Views/MyView.xaml");
      
      win.Content = foo.View;

      Gtk.Application.Run();
      return 0;
     }
    }

MoonDesk alone isn't enough to build a cross-platform xaml based app but should help along the way. 

### Examples

#### hello

<img src="https://github.com/inorton/MoonBase/raw/master/Examples/hello/hello.png" alt="hello screenshot"/>

A simple form with a handful of views and view models, shows
a simple command binding that increments a value in the view model.
Also shows binding other controls into containers using ContentControl
( rather like frame src= in html )

BSD License
------------

Copyright (c) 2011, Ian Norton
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice,
  this list of conditions and the following disclaimer.  

* Redistributions in binary form must reproduce the above copyright
  notice, this list of conditions and the following disclaimer in the
  documentation and/or other materials provided with the distribution.

* Neither the name of moonbase nor the names of its contributors may be 
  used to endorse or promote products derived from this software without
  specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

