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

            XDocument xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Lista samochodów z komisu"),
                new XElement("Samochody",
                    from car in carList
                    orderby car.brand, car.model
                    select new XElement("samochód",
                        new XAttribute("Marka", car.brand),
                        new XElement("Model", car.model),
                        new XElement("Numer Rejestracyjny", car.registractionNumber),
                        new XElement("Rok produkcji", car.yearOfProduction),
                        new XElement("Klimatyzacja", car.airConditioning)
                        )
                    )
            );

            xml.Save("Cars.xml");
            listView.ItemsSource = carList;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            
            if ((!String.IsNullOrEmpty(textBoxBrand.Text) || !String.IsNullOrEmpty(textBoxModel.Text) ||
               !String.IsNullOrEmpty(textBoxRegistractionNumber.Text) || !String.IsNullOrEmpty(textBoxYearOfProduction.Text)) && 
               ((radioButtonNo.IsChecked == false && radioButtonYes.IsChecked == true) || 
               (radioButtonNo.IsChecked == true && radioButtonYes.IsChecked == false)))
            {

                Car car1 = new Car();
                if (Equals(car1))
                {
                    MessageBox.Show("Samochód o takim numerze rejestracyjnym jest już zarejestrowany!");
                }
                else
                {
                    car1.brand = textBoxBrand.Text;
                    car1.model = textBoxModel.Text;
                    try
                    {
                        car1.yearOfProduction = int.Parse(textBoxYearOfProduction.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Niepoprawny format roku produkcji");
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


                    carList.Add(car1);
                    listView.ItemsSource = null;
                    listView.ItemsSource = carList;
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
            label.Content = carList[index].Description();
        }
    }
}
