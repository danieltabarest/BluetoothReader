using System;
using System.ComponentModel;
using BluetoothReader.viewmodel;
using Xamarin.Forms;

namespace BluetoothReader.view
{
   public partial class LogsPage
   {
      public LogsPage( LogsViewModel vm )
      {
         BindingContext = vm;
         InitializeComponent();
      }

      /// <inheritdoc />
      protected override void OnBindingContextChanged()
      {
         if(BindingContext != null)
         {
            ((LogsViewModel)BindingContext).PropertyChanged -= LogsPage_PropertyChanged;
         }
         base.OnBindingContextChanged();
         ((LogsViewModel)BindingContext).PropertyChanged += LogsPage_PropertyChanged;
      }

      private void LogsPage_PropertyChanged( Object sender, PropertyChangedEventArgs e )
      {
         scrollView.ScrollToAsync( logsLabel, ScrollToPosition.End, true );
      }
   }
}