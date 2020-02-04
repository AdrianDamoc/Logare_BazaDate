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
using System.Data;
using Windows.UI.Popups;
using Logare_BazaDate.Views;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Logare_BazaDate
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void RegisterID_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pagina2));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=82.208.137.149\sqlexpress,8833;Initial Catalog=proba_transare;Persist Security Info=True;User ID=sa;Password=pro";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select utilizator,parola from Tabel_Utilizatori where utilizator = '" + utilizatorbox.Text + "' and parola ='" + parolabox.Password+"'";

            command = new SqlCommand(sql, cnn);

            String strResult = String.Empty;
           // int length = strResult.Length;
            strResult = (String)command.ExecuteScalar();
            if (strResult == null)
            {
               
                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Mesaj",
                    MaxWidth = this.ActualWidth,
                    PrimaryButtonText = "OK",
                    Content = new TextBlock
                    {
                        Text = "Nu esti inregistrat",
                        FontSize = 24,



                    },

                };
                await dialog.ShowAsync();

            } 
            else
            { 
                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Mesaj",
                    MaxWidth = this.ActualWidth,
                    PrimaryButtonText = "OK",
                    Content = new TextBlock
                    {
                        Text = "Te-ai logat",
                        FontSize = 24,



                    },

                };
                await dialog.ShowAsync();

            }


            command.Dispose();

   


            cnn.Close();
        }






      
        }
       
    }

