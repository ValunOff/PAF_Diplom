﻿using PAF.Commands.Base;
using PAF.ViewModel.BaseVM;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;

namespace PAF.ViewModel
{
    class DeliveryAddVM : ViewModelForWindow, IPage
    {
        #region Prorerties
        bool CanButtonClick=true;

        public DataTable DataTable { get => _DataTable; set => Set(ref _DataTable, value); }
        DataTable _DataTable;

        public string SupplyName { get => _SupplyName; set => Set(ref _SupplyName, value); }
        string _SupplyName;

        public DataRowView SelectedSupply { 
            get => _SelectedSupply; 
            set
            {
                Set(ref _SelectedSupply, value);
                if (SelectedSupply != null)
                {
                    SupplyName = (string)SelectedSupply.Row.ItemArray[1];
                }
            }
        }
        DataRowView _SelectedSupply;
        #endregion

        public void Refresh()
        {
            string query =
                    "select "+
                    "id Код, "+
                    "[Name] Поставщик, "+
                    "[Address] Адрес "+
                    "from Supplies ";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable temp = new DataTable();
                    adapter.Fill(temp);
                    DataTable = temp; //добавил temp чтобы срабатывал set у свойства
                    DataTable.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception x)
            {
                System.Windows.MessageBox.Show(x.Message,"Ошибка таблицы Поставщики", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
            }
        }

        public void Refresh(string search)
        {
            string query =
                    "select " +
                    "id Код, " +
                    "[Name] Поставщик, " +
                    "[Address] Адрес " +
                    "from Supplies " +
                    $"where convert(varchar(max),id)  +' '+ convert(varchar(max),[Name])  +' '+ convert(varchar(max),[Address]) Like '%{search}%'";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable temp = new DataTable();
                    adapter.Fill(temp);
                    DataTable = temp; //добавил temp чтобы срабатывал set у свойства
                    DataTable.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception x)
            {
                System.Windows.MessageBox.Show(x.Message, "Ошибка таблицы Поставщики", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
            }
        }
        #region Commands

        #region AddCommand
        public ICommand AddCommand { get; set; }

        private bool CanAddExecute(object p) => CanButtonClick;
        private void OnAddExecuted(object p)
        {
            
            if(SelectedSupply == null)
            {
                System.Windows.MessageBox.Show("Выберите поставщика","Поставщик не выбран",System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
            }
            else
            {
                CanButtonClick = false;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text files(*.csv) | *.csv";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    Encoding qwe = Encoding.UTF8;
                    string[] file = File.ReadAllLines(filename,qwe);
                    string[] row;
                    string query;
                    bool first = false;
                    object DeliveryId = null;

                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString))
                    {
                        try
                        {
                            connection.Open();
                            string q =
                                        "insert into Deliveries(Date, Supply_Id) " +
                                        $@"values (GetDate(),{ SelectedSupply.Row.ItemArray[0]}) " +
                                        "select scope_identity()";
                            SqlCommand command = new SqlCommand(q, connection);
                            DeliveryId = command.ExecuteScalar();
                            connection.Close();
                        }
                        catch (Exception x)
                        {
                            System.Windows.MessageBox.Show(x.Message,"Выбранный поставщик не найден в бд", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                        }
                    }
                    var Id = Convert.ToInt32(DeliveryId);
                    foreach (var item in file)
                    {
                        if (first)
                        {
                            row = item.Split(';');

                            #region query
                            query =
                                "declare @IdComponent int, " +
                                        "@IdDeliveries int, " +
                                        "@IdType int, " +
                                        "@Component Varchar(255), " +
                                        "@Amount int " +

                                "select @Amount = Amount, @IdComponent = Id " +
                                "From Components " +
                                $@"where[Name] = '{row[0]}' " +

                                //проверяется поставлялся ли этот товар раньше
                                "if (isnull(@Amount, -1) = -1) " +
                                    "begin " +//Добавяет полное описание и количество
                                        $@"select @IdType = Id from Types where [Name] = '{row[1]}' " +


                                        "if (isnull(@IdType, 0) = 0) " + //если типа нет то он создает его без указания короткого названия
                                           "begin " +
                                                "insert into Types([Name]) " +
                                                $@"values (convert(nvarchar(MAX),'{row[1]}'))  " +
                                                "set @IdType = scope_identity() " +
                                            "end " +
                                        "insert into Components([Name],Price, Amount, Supply_Id, [Type_Id]) " +

                                        $@"values(N'{row[0]}',{row[2]}*1.2, {row[3]}, {SelectedSupply.Row.ItemArray[0]}, @IdType) " +

                                        "set @IdComponent = scope_identity() " +



                                    "end " +
                                "else " + //Данные о товаре уже есть меняется только количество
                                    $@"update Components set Amount = @Amount +{row[3]} " +
                                    $@"where[Name] = '{row[0]}' " +
                                    "insert into DeliveriesCompositions(Price, Amount, Sum, Component_Id, Delivery_Id) " +

                                        $@"values({row[2]},{row[3]},{row[4]},@IdComponent,{Id}) ";
                            #endregion

                            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString))
                            {
                                try
                                {
                                    SqlCommand command = new SqlCommand(query, connection);
                                    connection.Open();
                                    command.ExecuteNonQuery();
                                    connection.Close();
                                }
                                catch (Exception x)
                                {
                                    System.Windows.MessageBox.Show(x.Message,"", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                                }
                            }
                        }
                        first = true;
                    }
                }
                CanButtonClick = true;
                CloseAction();
            }
            
            
        }
        #endregion

        #endregion

        public DeliveryAddVM()
        {
            #region Commands
            AddCommand = new LambdaCommand(OnAddExecuted, CanAddExecute);
            #endregion

            Refresh();
        }

    }
}
