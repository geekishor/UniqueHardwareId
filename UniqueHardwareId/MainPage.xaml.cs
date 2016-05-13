using System;
using Windows.Storage.Streams;
using Windows.System.Profile;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UniqueHardwareId
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnGetHwId_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var hardwareToken = HardwareIdentification.GetPackageSpecificToken(null);
                var hardwareId = hardwareToken.Id;
                var dataReader = DataReader.FromBuffer(hardwareId);

                byte[] bytes = new byte[hardwareId.Length];
                dataReader.ReadBytes(bytes);

                txtId.Text = BitConverter.ToString(bytes);

            }
            catch (Exception ex)
            {
            }
        }
    }
}
