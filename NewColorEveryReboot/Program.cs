using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace NewColorEveryReboot
{
    class Program
    {
        static uint[] NewColor()
        {
            uint[] myColors = new uint[2];
            Random rand = new Random();
            float hue = (float) rand.NextDouble();
            myColors[0] = ColorConvert.HSBtoColor(hue, 1.0f, 0.75f);
            myColors[1] = ColorConvert.HSBtoColor(hue, 1.0f, 0.85f);
            return myColors;
        }
        static void Main(string[] args)
        {
            uint[] myColors = NewColor();
            uint myStartColor = myColors[0];
            uint myAccentColor = myColors[1];
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", 
                "StartColor", (int) myStartColor, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Accent",
                "AccentColor", (int) myAccentColor, RegistryValueKind.DWord);

        }
    }
}
