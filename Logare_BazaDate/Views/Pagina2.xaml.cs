using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Logare_BazaDate.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Pagina2 : Page
    {
        public Pagina2()
        {
            this.InitializeComponent();
        }

        private async void RegisterNewUser_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=82.208.137.149\sqlexpress,8833;Initial Catalog=proba_transare;Persist Security Info=True;User ID=sa;Password=pro";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Insert into Tabel_Utilizatori (utilizator,parola) values" + " ('" + UserRegID.Text.Trim()+"','"+  PassRegID.Text.Trim() + "')";

            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            
           

            

            command.Dispose();

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Mesaj",
                MaxWidth = this.ActualWidth,
                PrimaryButtonText = "OK",
                Content = new TextBlock
                {
                    Text = "Ai inserat in baza de date",
                    FontSize = 24,
                    
                    

        },

            };
            await dialog.ShowAsync();
            

            cnn.Close();
        }

    }
}
