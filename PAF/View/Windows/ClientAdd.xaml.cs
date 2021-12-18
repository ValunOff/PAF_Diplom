﻿using PAF.Data.Clases;
using PAF.Data.Entityies;
using PAF.ViewModel;
using PAF.ViewModel.BaseVM;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PAF.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientAdd.xaml
    /// </summary>
    public partial class ClientAdd : Window
    {
        Clients client = new Clients();

        public ClientAdd(IPage page)
        {
            InitializeComponent();
            this.DataContext = page;
            ClientGender.ItemsSource = Enum.GetValues(typeof(Genders));
            ClientGender.SelectedValue = Genders.Муж;
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {

            }
        }

        private void ButtonClientAdd(object sender, RoutedEventArgs e)
        {
            bool ok = true;

            if (ClientLastName.Text == "")
            {
                ok = false;
                ClientLastNameText.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                ClientLastName.Foreground = new SolidColorBrush(Colors.Gray);
                client.LastName = ClientLastName.Text;
            }

            if (ClientFirstName.Text == "")
            {
                ok = false;
                ClientFirstNameText.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                ClientFirstNameText.Foreground = new SolidColorBrush(Colors.Gray);
                client.FirstName = ClientFirstName.Text;
            }

            if (ClientMiddleName.Text == "")
            {
                ok = false;
                ClientMiddleNameText.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                ClientMiddleNameText.Foreground = new SolidColorBrush(Colors.Gray);
                client.MiddleName = ClientMiddleName.Text;
            }

            if (ClientGender.SelectedValue == null)
                client.Gender = Genders.Муж;
            else
                client.Gender = (Genders)ClientGender.SelectedValue;

            if (ClientPhone.Text == "")
            {
                ok = false;
                ClientPhoneText.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                ClientPhoneText.Foreground = new SolidColorBrush(Colors.Gray);
                client.Phone = ClientPhone.Text;
            }

            int gender = client.Gender == Genders.Муж ? 0 : 1;

            if(ok)
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString))
                {
                    connection.Open();
                    string q =
                                "insert into Clients(LastName,FirstName,MiddleName,Gender,Phone) " +
                                $"values ('{client.LastName}','{ client.FirstName}','{ client.MiddleName}',{gender},'{ client.Phone}') ";
                    SqlCommand command = new SqlCommand(q, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Client");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

