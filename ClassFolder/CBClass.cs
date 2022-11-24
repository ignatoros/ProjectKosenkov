using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectKosenkov.ClassFolder
{
    class CBClass
    {
        SqlConnection sqlConnection = new SqlConnection(
             @"Data Source=(local)\SQLEXPRESS;" +
             "Initial Catalog=PrilutskiyProject;" +
             "Integrated Security=True");
        SqlDataAdapter sqlData;
        DataSet dataSet;

        public enum CBType
        {
            Role,
            Model,
            Mark,
            Type
        }

        private void RoleCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlData = new SqlDataAdapter("Select IdRole, RoleName " +
                    "From dbo.[Role] Order by IdRole ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "[Role]");
                comboBox.ItemsSource = dataSet.Tables["[Role]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.
                    Tables["[Role]"].Columns["RoleName"].ToString();
                comboBox.SelectedValuePath = dataSet.
                   Tables["[Role]"].Columns["IdRole"].ToString();
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
        private void MarkCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlData = new SqlDataAdapter("Select MarkId, MarkName " +
                    "From dbo.[Mark] Order by MarkId ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "[Mark]");
                comboBox.ItemsSource = dataSet.Tables["[Mark]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.
                    Tables["[Mark]"].Columns["MarkName"].ToString();
                comboBox.SelectedValuePath = dataSet.
                   Tables["[Mark]"].Columns["MarkId"].ToString();
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
        private void ModelCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlData = new SqlDataAdapter("Select ModelId, ModelName " +
                    "From dbo.[Model] Order by ModelId ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "[Model]");
                comboBox.ItemsSource = dataSet.Tables["[Model]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.
                    Tables["[Model]"].Columns["ModelName"].ToString();
                comboBox.SelectedValuePath = dataSet.
                   Tables["[Model]"].Columns["ModelId"].ToString();
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
        private void TypeCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlData = new SqlDataAdapter("Select TypeId, TypeName " +
                    "From dbo.[Type] Order by TypeId ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "[Type]");
                comboBox.ItemsSource = dataSet.Tables["[Type]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.
                    Tables["[Type]"].Columns["TypeName"].ToString();
                comboBox.SelectedValuePath = dataSet.
                   Tables["[Type]"].Columns["TypeId"].ToString();
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


        public void LoadCB(ComboBox comboBox, CBType type)
        {
            switch (type)
            {
                case CBType.Role:
                    RoleCBLoad(comboBox);
                    break;
                case CBType.Mark:
                    MarkCBLoad(comboBox);
                    break;
                case CBType.Model:
                    ModelCBLoad(comboBox);
                    break;
                case CBType.Type:
                    TypeCBLoad(comboBox);
                    break;
                
            }
        }
    }
}
