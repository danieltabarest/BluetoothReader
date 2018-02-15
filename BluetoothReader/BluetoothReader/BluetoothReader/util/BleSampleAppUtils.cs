
// 




using System;

namespace BluetoothReader.util
{
   internal static class BleSampleAppUtils
   {
      public const Int32 SCAN_SECONDS_DEFAULT = 10;
      public const Int32 SCAN_SECONDS_MAX = 30;

      public static Double ClampSeconds( Double seconds )
      {
         return Math.Max( Math.Min( seconds, SCAN_SECONDS_MAX ), 0 );
      }
   }
}