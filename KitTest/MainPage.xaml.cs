using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Namespace;
using Xamarin.Forms;

namespace KitTest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }
        void Handle_Clicked(object s, EventArgs e)
        {
            
            var d = deepButton.RootLayout(false);
            var a = anotherLabel.RootLayout(false);

            // RootLayout of any element equals the root xaml layout
            // and equals closest layout of type Layout<View> if specified with 'layoutWithChildren'
            Console.WriteLine("d: " + d.Id + ", a: " + a.Id + " = " + root.Id);
            
            // Prints all layouts of the page
            var list = deepButton.AllLayouts();
            foreach(var layout in list)
            {
                Console.WriteLine(layout.AutomationId);
            }
        }
    }
}
