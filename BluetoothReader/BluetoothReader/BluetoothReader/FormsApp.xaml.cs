﻿using System;
using System.Reflection;
using Acr.UserDialogs;
using BluetoothReader.view;
using BluetoothReader.viewmodel;
using nexus.core.logging;
using nexus.protocols.ble;
using Xamarin.Forms;
using Device = Xamarin.Forms.Device;
#if RELEASE
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
#endif

namespace BluetoothReader
{
   public partial class FormsApp
   {
      private readonly IUserDialogs m_dialogs;
      private readonly NavigationPage m_rootPage;

      public FormsApp( IBluetoothLowEnergyAdapter adapter, IUserDialogs dialogs )
      {
         InitializeComponent();

         m_dialogs = dialogs;
         var logsVm = new LogsViewModel();
         SystemLog.Instance.AddSink( logsVm );

         var bleAssembly = adapter.GetType().GetTypeInfo().Assembly.GetName();
         Log.Info( bleAssembly.Name + "@" + bleAssembly.Version );

         var bleGattServerViewModel = new BleGattServerViewModel( dialogs, adapter );
         var bleScanViewModel = new BleDeviceScannerViewModel(
            bleAdapter: adapter,
            dialogs: dialogs,
            onSelectDevice: async p =>
            {
               bleGattServerViewModel.Update( p );
               await m_rootPage.PushAsync(
                  new BleGattServerPage(
                     model: bleGattServerViewModel,
                     bleServiceSelected: async s => { await m_rootPage.PushAsync( new BleGattServicePage( s ) ); } ) );
               await bleGattServerViewModel.OpenConnection();
            } );

         m_rootPage = new NavigationPage(
            new TabbedPage
            {
               Title = "BLE Test",
               Children = {new BleDeviceScannerPage( bleScanViewModel ), new LogsPage( logsVm )}
            } );

         MainPage = m_rootPage;
      }

      /// <inheritdoc />
      protected override void OnStart()
      {
         base.OnStart();
         if(Device.RuntimePlatform == Device.Windows)
         {
            Device.StartTimer(
               TimeSpan.FromSeconds( 3 ),
               () =>
               {
                  m_dialogs.Alert(
                     "");
                  return false;
               } );
         }
      }
   }
}