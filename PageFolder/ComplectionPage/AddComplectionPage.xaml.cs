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
    /// Логика взаимодействия для AddComplectionPage.xaml
    /// </summary>
    public partial class AddComplectionPage : Page
    {
        SqlConnection sqlConnection = new SqlConnection(
            @"Data Source=(local)\SQLEXPRESS;" +
            "Initial Catalog=IgnatProject;" +
            "Integrated Security=True");
        SqlCommand sqlCommand;
        CBClass cB;
        SqlDataReader dataReader;
        public AddComplectionPage()
        {
            InitializeComponent();
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.OpenPage(new ComplectionAdminPage());
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {       
            try
            {               
                sqlCommand = new SqlCommand(
                    "Insert Into dbo.[Complection] " +
                    "(ModelId,MarkId,TypeId," +
                    "Count,Price,TotalPrice,Description) " +
                    $"Values ('{ModelCb.SelectedValue.ToString()}'," +
                    $"'{MarkCb.SelectedValue.ToString()}'," +
                    $"'{TypeCb.SelectedValue.ToString()}'," +
                    $"'{CountTb.Text}'," +
                    $"'{PriceTb.Text}'," +
                    $"'{TotalPriceСb.Text}'," +
                    $"'{DescriptionTb.Text}')",
                    sqlConnection);
                sqlCommand.ExecuteNonQuery();
                MBClass.InfoMB("Работник добавлен");
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cB.LoadCB(MarkCb, CBClass.CBType.Mark);
            cB.LoadCB(ModelCb, CBClass.CBType.Model);
            cB.LoadCB(TypeCb, CBClass.CBType.Type);
        }
    }
}
