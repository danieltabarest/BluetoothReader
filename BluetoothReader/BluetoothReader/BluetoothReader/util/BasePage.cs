using Xamarin.Forms;

namespace BluetoothReader.util
{
   public class BasePage : ContentPage
   {
      protected override void OnAppearing()
      {
         base.OnAppearing();
         (BindingContext as IBaseViewModel)?.OnAppearing();
      }

      protected override void OnDisappearing()
      {
         base.OnDisappearing();
         (BindingContext as IBaseViewModel)?.OnDisappearing();
      }
   }
}