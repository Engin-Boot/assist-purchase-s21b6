using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WpfAssistToPurchaseClient.Views
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : UserControl
    {
        static HttpClient client = new HttpClient();
        public Products()
        {
            InitializeComponent();
        }
        private async void OnClickAsync(object sender, RoutedEventArgs e)
        {
            Projects _projects = await GetAPIAsync("http://localhost:52659/api/Products");
            Console.WriteLine(_projects.ProductId, _projects.ScreenType);
        }
        static async Task<Projects> GetAPIAsync(string path)
        {
            Projects projects = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if(response.IsSuccessStatusCode)
            {
                projects = await response.Content.ReadAsAsync<Projects>();
            }
            return projects;

    }

       
    }

    public class Projects
    {
        public string ProductId { get; set; }
        public string ModelNumber { get; set; }
        public string ProductName { get; set; }

        //In inches (Validation required) 
        public double ScreenSize { get; set; }
        public double Weight { get; set; }
        public bool HasHandle { get; set; }
        public bool IsTouchScreen { get; set; }
        public bool IsCeCertified { get; set; }

        //Can be either LCD or LED, needs validation
        public string ScreenType { get; set; }
        public bool HasBattery { get; set; }

      
    }

    
}
