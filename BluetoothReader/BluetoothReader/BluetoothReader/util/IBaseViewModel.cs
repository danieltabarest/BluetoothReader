using System.ComponentModel;

namespace BluetoothReader.util
{
   public interface IBaseViewModel : INotifyPropertyChanged
   {
      void OnAppearing();

      void OnDisappearing();
   }
}