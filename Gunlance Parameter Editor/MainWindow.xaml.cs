using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32;
using Gunlance_Parameter_Editor.Crypto;


namespace Gunlance_Parameter_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cipher cipher;
        public byte[] data;
        public byte[] data2;
        public byte[] data3;
        public byte[] data4;
        public byte[] SaveAsData;
        private readonly string key = "j1P15gEkgVa7NdFxiqwCPitykHctY2nZPjSaElvqb0eSwcLO1cOlTqqv";
        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();
        public MainWindow()
        {
            InitializeComponent();
            ShellingType.Items.Add("Normal");
            ShellingType.Items.Add("Long");
            ShellingType.Items.Add("Wide");
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            cipher = new Cipher(key);
            TextBox[] ShellC = { ShellC1, ShellC2, ShellC3, ShellC4, ShellC5, ShellC6 };
            TextBox[] ShellF = { ShellF1, ShellF2, ShellF3, ShellF4, ShellF5, ShellF6 };
            TextBox[] WyverC = { WyverC1, WyverC2, WyverC3, WyverC4, WyverC5, WyverC6 };
            TextBox[] WyverF = { WyverF1, WyverF2, WyverF3, WyverF4, WyverF5, WyverF6 };
            TextBox[] Wyrmtc = { Wyrmtc1, Wyrmtc2, Wyrmtc3, Wyrmtc4, Wyrmtc5, Wyrmtc6 };
            TextBox[] WyrmEC = { WyrmEC1, WyrmEC2, WyrmEC3, WyrmEC4, WyrmEC5, WyrmEC6 };
            TextBox[] WyrmEF = { WyrmEF1, WyrmEF2, WyrmEF3, WyrmEF4, WyrmEF5, WyrmEF6 };
            TextBox[] Generl = { NumShells, ShellCT, WFAT, WFCD, ChargeMod, FBMod, MFBMod };
            ofd.Filter = "Gunlance Parameter File|wp07_param.w07p";
            if (ofd.ShowDialog() == true)
            {
                SaveButton.IsEnabled = true;
                ShellingType.IsEnabled = true;
                for (int i=0;i<6;i++)
                {
                    ShellC[i].IsEnabled = true;
                    ShellF[i].IsEnabled = true;
                    WyverC[i].IsEnabled = true;
                    WyverF[i].IsEnabled = true;
                    Wyrmtc[i].IsEnabled = true;
                    WyrmEC[i].IsEnabled = true;
                    WyrmEF[i].IsEnabled = true;
                    Generl[i].IsEnabled = true;
                }
                Generl[6].IsEnabled = true;
                SaveM.IsEnabled = true;
                SaveAs.IsEnabled = true;
                ShellingType.SelectedIndex = 1;
                ShellingType.SelectedIndex = 0;
            }
            
        }
        private void Type_Changed (object sender, RoutedEventArgs e)
        {
            cipher = new Cipher(key);
            data = null;
            data2 = null;
            data = (File.ReadAllBytes(ofd.FileName));
            data2 = cipher.Decipher(data);
            int offset = 1579 + ((ShellingType.SelectedIndex) * 180);
            TextBox[] ShellC = { ShellC1, ShellC2, ShellC3, ShellC4, ShellC5, ShellC6 };
            TextBox[] ShellF = { ShellF1, ShellF2, ShellF3, ShellF4, ShellF5, ShellF6 };
            TextBox[] WyverC = { WyverC1, WyverC2, WyverC3, WyverC4, WyverC5, WyverC6 };
            TextBox[] WyverF = { WyverF1, WyverF2, WyverF3, WyverF4, WyverF5, WyverF6 };
            TextBox[] Wyrmtc = { Wyrmtc1, Wyrmtc2, Wyrmtc3, Wyrmtc4, Wyrmtc5, Wyrmtc6 };
            TextBox[] WyrmEC = { WyrmEC1, WyrmEC2, WyrmEC3, WyrmEC4, WyrmEC5, WyrmEC6 };
            TextBox[] WyrmEF = { WyrmEF1, WyrmEF2, WyrmEF3, WyrmEF4, WyrmEF5, WyrmEF6 };
            TextBox[] Generl = { NumShells, ShellCT, WFAT, WFCD, ChargeMod, FBMod, MFBMod };
            float RV = BitConverter.ToSingle(new byte[] { data2[1499], data2[1500], data2[1501], data2[1502] }, 0);
            Generl[1].Text = RV.ToString();
            RV = BitConverter.ToSingle(new byte[] { data2[1507], data2[1508], data2[1509], data2[1510] }, 0);
            Generl[2].Text = RV.ToString();
            RV = BitConverter.ToSingle(new byte[] { data2[1511], data2[1512], data2[1513], data2[1514] }, 0);
            Generl[3].Text = RV.ToString();
            for (int i=0;i<6;i++)
            {
                RV = BitConverter.ToSingle(new byte[] { data2[offset + (i * 4)], data2[offset + 1 + (i * 4)], data2[offset + 2 + (i * 4)], data2[offset + 3 + (i * 4)] }, 0);
                ShellC[i].Text = RV.ToString();
                RV = BitConverter.ToSingle(new byte[] { data2[offset + 24 + (i * 4)], data2[offset + 25 + (i * 4)], data2[offset + 26 + (i * 4)], data2[offset + 27 + (i * 4)] }, 0);
                ShellF[i].Text = RV.ToString();
                RV = BitConverter.ToSingle(new byte[] { data2[offset + 60 + (i * 4)], data2[offset + 61 + (i * 4)], data2[offset + 62 + (i * 4)], data2[offset + 63 + (i * 4)] }, 0);
                WyverC[i].Text = RV.ToString();
                RV = BitConverter.ToSingle(new byte[] { data2[offset + 84 + (i * 4)], data2[offset + 85 + (i * 4)], data2[offset + 86 + (i * 4)], data2[offset + 87 + (i * 4)] }, 0);
                WyverF[i].Text = RV.ToString();
                RV = BitConverter.ToSingle(new byte[] { data2[offset + 108 + (i * 4)], data2[offset + 109 + (i * 4)], data2[offset + 110 + (i * 4)], data2[offset + 111 + (i * 4)] }, 0);
                Wyrmtc[i].Text = RV.ToString();
                RV = BitConverter.ToSingle(new byte[] { data2[offset + 132 + (i * 4)], data2[offset + 133 + (i * 4)], data2[offset + 133 + (i * 4)], data2[offset + 135 + (i * 4)] }, 0);
                WyrmEC[i].Text = RV.ToString();
                RV = BitConverter.ToSingle(new byte[] { data2[offset + 156 + (i * 4)], data2[offset + 157 + (i * 4)], data2[offset + 158 + (i * 4)], data2[offset + 159 + (i * 4)] }, 0);
                WyrmEF[i].Text = RV.ToString();
            }
            for (int i=0;i<3;i++)
            {
                RV = BitConverter.ToSingle(new byte[] { data2[offset + 48 + (i * 4)], data2[offset + 49 + (i * 4)], data2[offset + 50 + (i * 4)], data2[offset + 51 + (i * 4)] }, 0);
                Generl[i+4].Text = RV.ToString();
            }
            Int32 RV2 = 0;
            if (ShellingType.SelectedIndex == 0)
            {
                RV2 = BitConverter.ToInt32(new byte[] { data2[1487], data2[1488], data2[1489], data2[1490] }, 0);
                Generl[0].Text = RV2.ToString();
            }
            else if (ShellingType.SelectedIndex == 1)
            {
                RV2 = BitConverter.ToInt32(new byte[] { data2[1495], data2[1496], data2[1497], data2[1498] }, 0);
                Generl[0].Text = RV2.ToString();
            }
            else if (ShellingType.SelectedIndex == 2)
            {
                RV2 = BitConverter.ToInt32(new byte[] { data2[1491], data2[1492], data2[1493], data2[1494] }, 0);
                Generl[0].Text = RV2.ToString();
            }

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            data = null;
            data3 = null;
            data4 = null;
            cipher = new Cipher(key);
            #region definitions
            int offset = 1579 + ((ShellingType.SelectedIndex) * 180);
            TextBox[] ShellC = { ShellC1, ShellC2, ShellC3, ShellC4, ShellC5, ShellC6 };
            TextBox[] ShellF = { ShellF1, ShellF2, ShellF3, ShellF4, ShellF5, ShellF6 };
            TextBox[] WyverC = { WyverC1, WyverC2, WyverC3, WyverC4, WyverC5, WyverC6 };
            TextBox[] WyverF = { WyverF1, WyverF2, WyverF3, WyverF4, WyverF5, WyverF6 };
            TextBox[] Wyrmtc = { Wyrmtc1, Wyrmtc2, Wyrmtc3, Wyrmtc4, Wyrmtc5, Wyrmtc6 };
            TextBox[] WyrmEC = { WyrmEC1, WyrmEC2, WyrmEC3, WyrmEC4, WyrmEC5, WyrmEC6 };
            TextBox[] WyrmEF = { WyrmEF1, WyrmEF2, WyrmEF3, WyrmEF4, WyrmEF5, WyrmEF6 };
            TextBox[] Generl = { NumShells, ShellCT, WFAT, WFCD, ChargeMod, FBMod, MFBMod };
            #endregion
            data = (File.ReadAllBytes(ofd.FileName));
            data3 = cipher.Decipher(data);
            byte[] buffer = BitConverter.GetBytes(Convert.ToSingle(Generl[1].Text));
            data3[1499] = buffer[0];
            data3[1500] = buffer[1];
            data3[1501] = buffer[2];
            data3[1502] = buffer[3];
            buffer = BitConverter.GetBytes(Convert.ToSingle(Generl[2].Text));
            data3[1507] = buffer[0];
            data3[1508] = buffer[1];
            data3[1509] = buffer[2];
            data3[1510] = buffer[3];
            buffer = BitConverter.GetBytes(Convert.ToSingle(Generl[3].Text));
            data3[1511] = buffer[0];
            data3[1512] = buffer[1];
            data3[1513] = buffer[2];
            data3[1514] = buffer[3];
            for (int i = 0; i < 6; i++)
            {
                buffer = BitConverter.GetBytes(Convert.ToSingle(ShellC[i].Text));
                data3[offset + (i * 4)] = buffer[0];
                data3[offset + 1 + (i * 4)] = buffer[1];
                data3[offset + 2 + (i * 4)] = buffer[2];
                data3[offset + 3 + (i * 4)] = buffer[3];
                buffer = BitConverter.GetBytes(Convert.ToSingle(ShellF[i].Text));
                data3[offset + 24 + (i * 4)] = buffer[0];
                data3[offset + 25 + (i * 4)] = buffer[1];
                data3[offset + 26 + (i * 4)] = buffer[2];
                data3[offset + 27 + (i * 4)] = buffer[3];
                buffer = BitConverter.GetBytes(Convert.ToSingle(WyverC[i].Text));
                data3[offset + 60 + (i * 4)] = buffer[0];
                data3[offset + 61 + (i * 4)] = buffer[1];
                data3[offset + 62 + (i * 4)] = buffer[2];
                data3[offset + 63 + (i * 4)] = buffer[3];
                buffer = BitConverter.GetBytes(Convert.ToSingle(WyverF[i].Text));
                data3[offset + 84 + (i * 4)] = buffer[0];
                data3[offset + 85 + (i * 4)] = buffer[1];
                data3[offset + 86 + (i * 4)] = buffer[2];
                data3[offset + 87 + (i * 4)] = buffer[3];
                buffer = BitConverter.GetBytes(Convert.ToSingle(Wyrmtc[i].Text));
                data3[offset + 108 + (i * 4)] = buffer[0];
                data3[offset + 109 + (i * 4)] = buffer[1];
                data3[offset + 110 + (i * 4)] = buffer[2];
                data3[offset + 111 + (i * 4)] = buffer[3];
                buffer = BitConverter.GetBytes(Convert.ToSingle(WyrmEC[i].Text));
                data3[offset + 132 + (i * 4)] = buffer[0];
                data3[offset + 133 + (i * 4)] = buffer[1];
                data3[offset + 134 + (i * 4)] = buffer[2];
                data3[offset + 135 + (i * 4)] = buffer[3];
                buffer = BitConverter.GetBytes(Convert.ToSingle(WyrmEF[i].Text));
                data3[offset + 156 + (i * 4)] = buffer[0];
                data3[offset + 157 + (i * 4)] = buffer[1];
                data3[offset + 158 + (i * 4)] = buffer[2];
                data3[offset + 159 + (i * 4)] = buffer[3];
            }
            for (int i = 0; i < 3; i++)
            {
                buffer = BitConverter.GetBytes(Convert.ToSingle(Generl[i + 4].Text));
                data3[offset + 48 + (i * 4)] = buffer[0];
                data3[offset + 49 + (i * 4)] = buffer[1];
                data3[offset + 50 + (i * 4)] = buffer[2];
                data3[offset + 51 + (i * 4)] = buffer[3];
            }
            if (ShellingType.SelectedIndex == 0)
            {
                buffer = BitConverter.GetBytes(Convert.ToInt32(Generl[0].Text));
                data3[1487] = buffer[0];
                data3[1488] = buffer[1];
                data3[1489] = buffer[2];
                data3[1490] = buffer[3];
            }
            else if (ShellingType.SelectedIndex == 1)
            {
                buffer = BitConverter.GetBytes(Convert.ToInt32(Generl[0].Text));
                data3[1495] = buffer[0];
                data3[1496] = buffer[1];
                data3[1497] = buffer[2];
                data3[1498] = buffer[3];
            }
            else if (ShellingType.SelectedIndex == 2)
            {
                buffer = BitConverter.GetBytes(Convert.ToInt32(Generl[0].Text));
                data3[1491] = buffer[0];
                data3[1492] = buffer[1];
                data3[1493] = buffer[2];
                data3[1494] = buffer[3];
            }
            data4 = cipher.Encipher(data3);
            File.WriteAllBytes(ofd.FileName, data4);
        }
        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            data = null;
            data3 = null;
            data4 = null;
            cipher = new Cipher(key);
            #region definitions
            int offset = 1579 + ((ShellingType.SelectedIndex) * 180);
            TextBox[] ShellC = { ShellC1, ShellC2, ShellC3, ShellC4, ShellC5, ShellC6 };
            TextBox[] ShellF = { ShellF1, ShellF2, ShellF3, ShellF4, ShellF5, ShellF6 };
            TextBox[] WyverC = { WyverC1, WyverC2, WyverC3, WyverC4, WyverC5, WyverC6 };
            TextBox[] WyverF = { WyverF1, WyverF2, WyverF3, WyverF4, WyverF5, WyverF6 };
            TextBox[] Wyrmtc = { Wyrmtc1, Wyrmtc2, Wyrmtc3, Wyrmtc4, Wyrmtc5, Wyrmtc6 };
            TextBox[] WyrmEC = { WyrmEC1, WyrmEC2, WyrmEC3, WyrmEC4, WyrmEC5, WyrmEC6 };
            TextBox[] WyrmEF = { WyrmEF1, WyrmEF2, WyrmEF3, WyrmEF4, WyrmEF5, WyrmEF6 };
            TextBox[] Generl = { NumShells, ShellCT, WFAT, WFCD, ChargeMod, FBMod, MFBMod };
            #endregion
            data = (File.ReadAllBytes(ofd.FileName));
            data3 = cipher.Decipher(data);
            byte[] buffer = BitConverter.GetBytes(Convert.ToSingle(Generl[1].Text));
            data3[1499] = buffer[0];
            data3[1500] = buffer[1];
            data3[1501] = buffer[2];
            data3[1502] = buffer[3];
            buffer = BitConverter.GetBytes(Convert.ToSingle(Generl[2].Text));
            data3[1507] = buffer[0];
            data3[1508] = buffer[1];
            data3[1509] = buffer[2];
            data3[1510] = buffer[3];
            buffer = BitConverter.GetBytes(Convert.ToSingle(Generl[3].Text));
            data3[1511] = buffer[0];
            data3[1512] = buffer[1];
            data3[1513] = buffer[2];
            data3[1514] = buffer[3];
            for (int i = 0; i < 6; i++)
            {
                buffer = BitConverter.GetBytes(Convert.ToSingle(ShellC[i].Text));
                data3[offset + (i * 4)] = buffer[0];
                data3[offset + 1 + (i * 4)] = buffer[1];
                data3[offset + 2 + (i * 4)] = buffer[2];
                data3[offset + 3 + (i * 4)] = buffer[3];
                buffer = BitConverter.GetBytes(Convert.ToSingle(ShellF[i].Text));
                data3[offset + 24 + (i * 4)] = buffer[0];
                data3[offset + 25 + (i * 4)] = buffer[1];
                data3[offset + 26 + (i * 4)] = buffer[2];
                data3[offset + 27 + (i * 4)] = buffer[3];
                buffer = BitConverter.GetBytes(Convert.ToSingle(WyverC[i].Text));
                data3[offset + 60 + (i * 4)] = buffer[0];
                data3[offset + 61 + (i * 4)] = buffer[1];
                data3[offset + 62 + (i * 4)] = buffer[2];
                data3[offset + 63 + (i * 4)] = buffer[3];
                buffer = BitConverter.GetBytes(Convert.ToSingle(WyverF[i].Text));
                data3[offset + 84 + (i * 4)] = buffer[0];
                data3[offset + 85 + (i * 4)] = buffer[1];
                data3[offset + 86 + (i * 4)] = buffer[2];
                data3[offset + 87 + (i * 4)] = buffer[3];
                buffer = BitConverter.GetBytes(Convert.ToSingle(Wyrmtc[i].Text));
                data3[offset + 108 + (i * 4)] = buffer[0];
                data3[offset + 109 + (i * 4)] = buffer[1];
                data3[offset + 110 + (i * 4)] = buffer[2];
                data3[offset + 111 + (i * 4)] = buffer[3];
                buffer = BitConverter.GetBytes(Convert.ToSingle(WyrmEC[i].Text));
                data3[offset + 132 + (i * 4)] = buffer[0];
                data3[offset + 133 + (i * 4)] = buffer[1];
                data3[offset + 134 + (i * 4)] = buffer[2];
                data3[offset + 135 + (i * 4)] = buffer[3];
                buffer = BitConverter.GetBytes(Convert.ToSingle(WyrmEF[i].Text));
                data3[offset + 156 + (i * 4)] = buffer[0];
                data3[offset + 157 + (i * 4)] = buffer[1];
                data3[offset + 158 + (i * 4)] = buffer[2];
                data3[offset + 159 + (i * 4)] = buffer[3];
            }
            for (int i = 0; i < 3; i++)
            {
                buffer = BitConverter.GetBytes(Convert.ToSingle(Generl[i + 4].Text));
                data3[offset + 48 + (i * 4)] = buffer[0];
                data3[offset + 49 + (i * 4)] = buffer[1];
                data3[offset + 50 + (i * 4)] = buffer[2];
                data3[offset + 51 + (i * 4)] = buffer[3];
            }
            if (ShellingType.SelectedIndex == 0)
            {
                buffer = BitConverter.GetBytes(Convert.ToInt32(Generl[0].Text));
                data3[1487] = buffer[0];
                data3[1488] = buffer[1];
                data3[1489] = buffer[2];
                data3[1490] = buffer[3];
            }
            else if (ShellingType.SelectedIndex == 1)
            {
                buffer = BitConverter.GetBytes(Convert.ToInt32(Generl[0].Text));
                data3[1495] = buffer[0];
                data3[1496] = buffer[1];
                data3[1497] = buffer[2];
                data3[1498] = buffer[3];
            }
            else if (ShellingType.SelectedIndex == 2)
            {
                buffer = BitConverter.GetBytes(Convert.ToInt32(Generl[0].Text));
                data3[1491] = buffer[0];
                data3[1492] = buffer[1];
                data3[1493] = buffer[2];
                data3[1494] = buffer[3];
            }
            data4 = cipher.Encipher(data3);
            sfd.Filter = "Gunlance Parameter File|wp07_param.w07p";
            sfd.FileName = ofd.SafeFileName;
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                File.WriteAllBytes(sfd.FileName, data4);
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This tool was made by Aradi147. " +
               "\n This tool would not be possible if it was not for MHVue's WorldChunkTool " +
               "and MHW Modding Discord's Help. " +
               "\nSpecial thanks to ZephyAlurus, Ezekial, and Freschu for their wikis, FusionR for his Cirilla, Hexhexhex for all his help, and *& for torturing himself with the save editor" +
               "\nIf you paid for this tool, you should ask for your money back.");
        }
        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("To contact me and other modders, please vist \n https://discord.gg/gJwMdhK");
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
