using System;
using System.Threading.Tasks;
using BluetoothReader.viewmodel;
using Xamarin.Forms;

namespace BluetoothReader.view
{
   public partial class BleGattServerPage
   {
      private readonly Func<BleGattServiceViewModel, Task> m_bleServiceSelected;

      public BleGattServerPage( BleGattServerViewModel model, Func<BleGattServiceViewModel, Task> bleServiceSelected )
      {
         m_bleServiceSelected = bleServiceSelected;
         InitializeComponent();
         BindingContext = model;
      }

      protected override Boolean OnBackButtonPressed()
      {
         ((BleGattServerViewModel)BindingContext).CloseConnection();
         return base.OnBackButtonPressed();
      }

      private void OnServiceSelected( Object sender, SelectedItemChangedEventArgs e )
      {
         if(e.SelectedItem != null)
         {
            m_bleServiceSelected( (BleGattServiceViewModel)e.SelectedItem );
            ((ListView)sender).SelectedItem = null;
         }
      }
   }
}