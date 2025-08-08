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

		private bool SelectionSort(LinkedList<double> list)
		{
			if (list.Count == 0)
				return false;
			var current = list.First;
			while (current != null)
			{
				var minNode = current;
				var nextNode = current.Next;
				while (nextNode != null)
				{
					if (nextNode.Value < minNode.Value)
					{
						minNode = nextNode;
					}
					nextNode = nextNode.Next;
				}
				if (minNode != current)
				{
					double temp = current.Value;
					current.Value = minNode.Value;
					minNode.Value = temp;
				}
				current = current.Next;
			}
			return true;
		}

		private bool InsertionSort(LinkedList<double> list)
		{
			if (list.Count == 0)
				return false;
			var current = list.First;
			while (current != null)
			{
				var next = current.Next;
				while (next != null && next.Value < current.Value)
				{
					double temp = current.Value;
					current.Value = next.Value;
					next.Value = temp;
					next = next.Next;
				}
				current = current.Next;
			}
			return true;
		}

		private int BinarySearchIterative(LinkedList<Double> list, double SearchValue, double minimum, double maximum)
		{
			// return index of SearchValue in list, or -1 if not found
			int left = 0;
			int right = list.Count - 1;
			int index = 0;
			while (left < right)
			{
				index = (left + right) / 2;
				double currentValue = list.ElementAt(index);
				if (currentValue == SearchValue)
				{
					return index; // found
				}
				else if (currentValue < SearchValue)
				{
					left = index + 1; // search right half
				}
				else
				{
					right = index - 1; // search left half
				}
			}
			// Check if the last element is the one we are looking for
			if (left < list.Count && list.ElementAt(left) == SearchValue)
			{
				return left; // found
			}
			return -1; // not found
		}

		private int BinarySearchRecursive(LinkedList<Double> list, double SearchValue, double minimum, double maximum)
		{
			// return index of SearchValue in list, or -1 if not found
			if (minimum > maximum)
				return -1; // not found
			int mid = (int)((minimum + maximum) / 2);
			double midValue = list.ElementAt(mid);
			if (midValue == SearchValue)
			{
				return mid; // found
			}
			else if (midValue < SearchValue)
			{
				return BinarySearchRecursive(list, SearchValue, mid + 1, maximum); // search right half
			}
			else
			{
				return BinarySearchRecursive(list, SearchValue, minimum, mid - 1); // search left half
			}
		}
	}
}