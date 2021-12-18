﻿using PAF.Commands.Base;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;
using PAF.ViewModel.BaseVM;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace PAF.ViewModel
{
    class ComponentVM : ViewModel, IPage
    {
        #region Properties
        /// <summary>Пока прога работает с бд, лучше запретить все кнопки для работы с бд</summary>
        bool CanButtonClick = true;

        public DataTable DataTable { get => _DataTable; set => Set(ref _DataTable, value); }
        DataTable _DataTable;

        public int Width { get => _Width; set => Set(ref _Width, value); }
        int _Width = 800;

        public int Height { get => _Height; set => Set(ref _Height, value); }
        int _Height = 475;
        #endregion

        public void Refresh()
        {
            string query =
                    "select "+
                    "c.Id Код, "+
                    "c.[Name] 'Наименование товара', "+
                    "cast(c.Price as decimal(15,2)) Цена, " +
                    "c.Amount Количество, "+
                    "s.[Name] Поставщик, "+
                    "t.[name] Тип "+
                    "from components c "+
                    "inner join Supplies s on s.Id = c.Supply_Id "+
                    "inner join Types t on t.Id = c.[Type_Id] ";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable temp = new DataTable();
                    adapter.Fill(temp);
                    DataTable = temp; //добавил temp чтобы срабатывал set у свойства
                }
            }
            catch (Exception x)
            {
                System.Windows.MessageBox.Show(x.Message,"Ошибка таблицы Товары", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
            }
        }

        public void Refresh(string search)
        {
            string query =
                    "select " +
                    "c.Id Код, " +
                    "c.[Name] 'Наименование товара', " +
                    "cast(c.Price as decimal(15,2)) Цена, " +
                    "c.Amount Количество, " +
                    "s.[Name] Поставщик, " +
                    "t.[name] Тип " +
                    "from components c " +
                    "inner join Supplies s on s.Id = c.Supply_Id " +
                    "inner join Types t on t.Id = c.[Type_Id] " +
                    $"where convert(varchar(max),c.Id) + ' ' + convert(varchar(max),c.[Name]) + ' ' + convert(varchar(max),c.Price) + ' ' + convert(varchar(max),c.Amount) + ' ' + convert(varchar(max),s.[Name]) + ' ' + convert(varchar(max),t.[Name]) Like '%{search}%'";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable temp = new DataTable();
                    adapter.Fill(temp);
                    DataTable = temp; //добавил temp чтобы срабатывал set у свойства
                }
            }
            catch (Exception x)
            {
                System.Windows.MessageBox.Show(x.Message, "Ошибка таблицы Товары", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
            }
        }

        #region Commands

        #region AddCommand
        public ICommand AddCommand { get; set; }
        private bool CanAddExecute(object p) => CanButtonClick;
        private void OnAddExecuted(object p)
        {
            CanButtonClick = false;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Text files(*.csv) | *.csv"; //формат файла

            DateTime dateTime = DateTime.Now; //название формируется по текущей дате

            saveFileDialog.FileName = "Товары на " + dateTime.ToString("dd MM yyyy"); //название файла
            Encoding.GetEncoding("UTF-8");
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                DataRow[] dr = _DataTable.Select();

                StreamWriter file = new StreamWriter(path,false,Encoding.UTF8);
                bool first = true;
                foreach (var item in _DataTable.Columns)
                {
                    if (first)
                    {
                        file.Write(item.ToString());
                        first = false;
                    }
                    else
                    {
                        file.Write(";" + item.ToString());
                    }
                }
                file.WriteLine();
                foreach (var item in dr)
                {
                    file.WriteLine(item.ItemArray[0] + ";" + item.ItemArray[1] + ";" + item.ItemArray[2] + ";" + item.ItemArray[3] + ";" + item.ItemArray[4] + ";" + item.ItemArray[5]);
                }
                file.Close();
            }
            CanButtonClick = true;
            
        }
        #endregion

        #region UpdateCommand
        public ICommand UpdateCommand { get; set; }
        private bool CanUpdateExecute(object p) => CanButtonClick;
        private void OnUpdateExecuted(object p)
        {
            CanButtonClick = false;
            Refresh();
            CanButtonClick = true;
        }
        #endregion
        #endregion

        public ComponentVM(ref int Width, ref int Height)
        {
            #region Commands
            AddCommand = new LambdaCommand(OnAddExecuted, CanAddExecute);
            UpdateCommand = new LambdaCommand(OnUpdateExecuted, CanUpdateExecute);
            #endregion

            Refresh();

            this.Width = Width >= 1150 ? Width - 350 : 800;     //1150 минимальная ширина окна. 350-Сумма ширины всех статичных элементов. 800-Минимальная ширина страницы
            this.Height = Height >= 600 ? Height - 80 : 520;   //600 минимальная высота окна. 125-Сумма высоты всех статичных элементов. 475-Минимальная высота страницы
        }

        public ComponentVM()
        {
            #region Commands
            AddCommand = new LambdaCommand(OnAddExecuted, CanAddExecute);
            UpdateCommand = new LambdaCommand(OnUpdateExecuted, CanUpdateExecute);
            #endregion

            Refresh();
        }
    }
}
