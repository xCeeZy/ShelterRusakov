using ShelterRusakov.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShelterRusakov
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TypeComboBox.SelectedValuePath = "id";
            TypeComboBox.DisplayMemberPath = "name";
            TypeComboBox.ItemsSource = App.context.viewanimal.ToList();

            AnimalsDataGrid.ItemsSource = App.context.journal.ToList();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (DateAdmissionDp.SelectedDate == null ||
                TypeComboBox.SelectedItem == null ||
                string.IsNullOrEmpty(NicknameTextBox.Text) ||
                string.IsNullOrEmpty(AgeTextBox.Text) ||
                string.IsNullOrEmpty(ConditionsTextBox.Text) ||
                DateEndDp.SelectedDate == null)
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                journal NewJournal = new journal()
                {
                    datestart = DateAdmissionDp.SelectedDate.Value,
                    idviewanimal = (int)TypeComboBox.SelectedValue,
                    name = NicknameTextBox.Text,
                    pasport = Convert.ToBoolean(PassportCheckBox.IsChecked),
                    age = int.Parse(AgeTextBox.Text),
                    service = ConditionsTextBox.Text,
                    dateend = DateEndDp.SelectedDate.Value
                };

                App.context.journal.Add(NewJournal);
                App.context.SaveChanges();

                MessageBox.Show("Запись добавлена");

                DateAdmissionDp.SelectedDate = null;
                TypeComboBox.SelectedItem = null;
                NicknameTextBox.Text = "";
                PassportCheckBox.IsChecked = false;
                AgeTextBox.Text = "";
                ConditionsTextBox.Text = "";
                DateEndDp.SelectedDate = null;

                AnimalsDataGrid.ItemsSource = App.context.journal.ToList();
            }
        }
    }
}