using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AkademiadotNET
{
    /// <summary>
    /// Interaction logic for WindowBus.xaml
    /// </summary>
    public partial class WindowBus : Window
    {
        private ObservableCollection<Bus> busList;

        public WindowBus()
        {
            InitializeComponent();
            busList = new ObservableCollection<Bus>();

            Bus bus2 = new Bus("Mercedes", "capture", "wp879865", 1987, 32);

            busList.Add(bus2);
            listViewBus.ItemsSource = busList;

            
        }

        private void buttonBusAdd_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(textBoxBrand.Text) ||
               !String.IsNullOrEmpty(textBoxModel.Text) || 
               !String.IsNullOrEmpty(textBoxRegistractionNumber.Text) ||
               !String.IsNullOrEmpty(textBoxYearOfProduction.Text) || 
               !String.IsNullOrEmpty(textBoxNumberOfSeats.Text))
            {
                Bus bus1 = new Bus();
                bus1.brand = textBoxBrand.Text;
                bus1.model = textBoxModel.Text;

                try
                {
                    bus1.yearOfProduction = int.Parse(textBoxYearOfProduction.Text);
                }
                catch
                {
                    MessageBox.Show("Niepoprawny format roku produkcji");
                    return;
                }
                
                bus1.registractionNumber = textBoxRegistractionNumber.Text;

                try
                {
                    bus1.numberOfSeats = int.Parse(textBoxNumberOfSeats.Text);
                }
                catch
                {
                    MessageBox.Show("Niepoprawny format liczby siedzen");
                    return;
                }

                bool registractionNumberExist = false;
                foreach (Vehicle other in busList)
                {
                    if (other.Equals(bus1))
                    {
                        registractionNumberExist = true;
                        break;
                    }
                }

                if (!registractionNumberExist)
                {
                    busList.Add(bus1);
                    listViewBus.ItemsSource = null;
                    listViewBus.ItemsSource = busList;
                }
                else
                {
                    MessageBox.Show("Autobus o tym numerze rejestracyjnym jest juz zapisany");
                }
 
            }
            else
            {
                MessageBox.Show("Uzupełnij wymagane dane!");
            }
        }

        private void buttonBusDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = listViewBus.SelectedIndex;
            if (index >= 0)
            {
                busList.RemoveAt(index);
                listViewBus.ItemsSource = null;
                listViewBus.ItemsSource = busList;
                
            }
            else
            {
                if(busList.Count<=0) MessageBox.Show("Nie ma już busów do kupienia!");
                else MessageBox.Show("Nie wybrałeś busa do kupienia!");
            }

        }

        private void buttonDescription_Click(object sender, RoutedEventArgs e)
        {
            int index = listViewBus.SelectedIndex;
            try
            {
                label.Content = busList[index].Description();
            }
            catch
            {
                MessageBox.Show("Zaznacz autobus dla którego chcesz odświeżyć opis");
            }
            
        }

       

        
    }
}
