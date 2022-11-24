using ProjectKosenkov.ClassFolder;
using ProjectKosenkov.WindowFolder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace ProjectKosenkov.PageFolder.ComplectionPage
{
    /// <summary>
    /// Логика взаимодействия для EditComplectionPage.xaml
    /// </summary>
    public partial class EditComplectionPage : Page
    {
        SqlConnection sqlConnection = new SqlConnection(
            @"Data Source=(local)\SQLEXPRESS;" +
            "Initial Catalog=IgnatProject;" +
            "Integrated Security=True");
        SqlCommand sqlCommand;
        CBClass cB;
        SqlDataReader dataReader;
        public EditComplectionPage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cB.LoadCB(MarkCb, CBClass.CBType.Mark);
            cB.LoadCB(ModelCb, CBClass.CBType.Model);
            cB.LoadCB(TypeCb, CBClass.CBType.Type);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select * From dbo.ComplectionView " +
                    $"Where ComplectionId='{VarialbleClass.UserId}'",
                    sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                ModelCb.SelectedValue = dataReader[1].ToString();
                MarkCb.SelectedValue = dataReader[2].ToString();
                TypeCb.SelectedValue = dataReader[3].ToString();
                CountTb.Text = dataReader[4].ToString();
                PriceTb.Text = dataReader[5].ToString();
                TotalPriceСb.Text = dataReader[6].ToString();
                DescriptionTb.Text = dataReader[7].ToString();                              
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                sqlCommand =
                    new SqlCommand("Update " +
                    "dbo.Complection " +
                    $"Set ModelCb='{ModelCb.SelectedValue.ToString()}'," +
                    $"MarkCb='{MarkCb.SelectedValue.ToString()}'," +
                    $"Typecb='{TypeCb.SelectedValue.ToString()}'," +
                    $"Count='{CountTb.Text}'," +
                    $"Price='{PriceTb.Text}'," +
                    $"TotalPrice='{TotalPriceСb.Text}'," +
                    $"Description='{DescriptionTb.Text}'" +
                    $"Where ComplectionId='{VarialbleClass.UserId}'",
                    sqlConnection);
                sqlCommand.ExecuteNonQuery();
                MBClass.InfoMB($"Данные работника " +
                    $"успешно отредактированы");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.OpenPage(new ComplectionAdminPage());
        }
    }
}
