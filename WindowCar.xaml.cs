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
using System.Xml.Linq;

namespace AkademiadotNET
{
    /// <summary>
    /// Interaction logic for WindowCar.xaml
    /// </summary>
    public partial class WindowCar : Window
    {
        private ObservableCollection<Car> carList;

        public WindowCar()
        {
            InitializeComponent();
            carList = new ObservableCollection<Car>();
            listView.ItemsSource = carList;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            
            if ((!String.IsNullOrEmpty(textBoxBrand.Text) ||
                 !String.IsNullOrEmpty(textBoxModel.Text) ||
                 !String.IsNullOrEmpty(textBoxRegistractionNumber.Text) ||
                 !String.IsNullOrEmpty(textBoxYearOfProduction.Text)) && 
               ((radioButtonNo.IsChecked == false && radioButtonYes.IsChecked == true) || 
                (radioButtonNo.IsChecked == true && radioButtonYes.IsChecked == false)))
            {

                Car car1 = new Car();
                //todo: zapisac warunek
                
                car1.brand = textBoxBrand.Text;
                car1.model = textBoxModel.Text;

                try
                {
                   car1.yearOfProduction = int.Parse(textBoxYearOfProduction.Text);
                }
                catch
                {
                   MessageBox.Show("Niepoprawny format roku produkcji");
                   return;
                }
                    
                car1.registractionNumber = textBoxRegistractionNumber.Text;

                if (radioButtonNo.IsChecked == true)
                {
                    car1.airConditioning = airConditioningValue.Nie.ToString();
                }
                else if (radioButtonYes.IsChecked == true)
                {
                    car1.airConditioning = airConditioningValue.Tak.ToString();
                }

                bool registractionNumberExist = false;
                foreach (Vehicle other in carList)
                {
                    if (other.Equals(car1))
                    {
                        registractionNumberExist = true;
                        break;
                    }
                }

                if(!registractionNumberExist)
                {
                    carList.Add(car1);
                    listView.ItemsSource = null;
                    listView.ItemsSource = carList;
                }
                else
                {
                    MessageBox.Show("Samochód o tym numerze rejestracyjnym jest juz zapisany");
                }

            }
            else
            {
                MessageBox.Show("Uzupełnij wymagane dane!");
            }

        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = listView.SelectedIndex;
            if (index >= 0)
            {
                carList.RemoveAt(index);
                listView.ItemsSource = null;
                listView.ItemsSource = carList;

            }
            else
            {
                if (carList.Count <= 0) MessageBox.Show("Nie ma już samochodów do kupienia!");
                else MessageBox.Show("Nie wybrałeś samochodu do kupienia!");
            }
        }

        private void buttonDescription_Click(object sender, RoutedEventArgs e)
        {
            int index = listView.SelectedIndex;
            try
            {
                label.Content = carList[index].Description();
            }
            catch
            {
                MessageBox.Show("Zaznacz samochód dla którego chcesz odświeżyć opis");
            } 
        }
    }
}
