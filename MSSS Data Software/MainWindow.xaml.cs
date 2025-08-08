using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;
using Galileo6;
using System.Security.Cryptography;

namespace MSSS_Data_Software
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		LinkedList<double> ListA = new LinkedList<double>();
		LinkedList<double> ListB = new LinkedList<double>();

		public MainWindow()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
			//clear linkedlists
			ListA.Clear();
			ListB.Clear();

			var g = new Galileo6.ReadData();

            for (int i = 0; i < 400; i++)
            {
                double sensorAValue = g.SensorA(InputSigma.Value ?? 0.0, InputMu.Value ?? 0.0);
                double sensorBValue = g.SensorB(InputSigma.Value ?? 0.0, InputMu.Value ?? 0.0);

                ListA.AddLast(sensorAValue);
                ListB.AddLast(sensorBValue);

            }
        }

		private void ShowAllSensorData()
		{
			ListviewSensor.Items.Clear();

			var enumeratorA = ListA.GetEnumerator();
			var enumeratorB = ListB.GetEnumerator();

			bool hasDataA = enumeratorA.MoveNext();
			bool hasDataB = enumeratorB.MoveNext();

			while (hasDataA && hasDataB)
			{
				// Create anonymous object with properties SensorA and SensorB
				var item = new
				{
					SensorA = enumeratorA.Current.ToString("F2"),
					SensorB = enumeratorB.Current.ToString("F2")
				};

				ListviewSensor.Items.Add(item);

				hasDataA = enumeratorA.MoveNext();
				hasDataB = enumeratorB.MoveNext();
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
            LoadData();
			ShowAllSensorData();
		}

		private int NumberOfNodes(LinkedList<double> list)
		{
			return list.Count;
		}

		private void DisplayListboxData(LinkedList<Double> list, ListBox box)
		{
			box.Items.Clear();

			foreach (var item in list)
			{
				box.Items.Add(item.ToString("F2"));
			}

		}
	}
}