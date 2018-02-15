using System;
using BluetoothReader.viewmodel;
using Xamarin.Forms;

namespace BluetoothReader.view
{
   public partial class BleGattServicePage
   {
      public BleGattServicePage( BleGattServiceViewModel model )
      {
         InitializeComponent();
         BindingContext = model;
      }

      private void OnItemSelected( Object sender, SelectedItemChangedEventArgs e )
      {
         ((ListView)sender).SelectedItem = null;
      }
   }
}