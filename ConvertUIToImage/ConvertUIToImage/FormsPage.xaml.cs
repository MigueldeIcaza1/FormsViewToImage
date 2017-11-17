using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConvertUIToImage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormsPage : ContentPage
	{
		public FormsPage ()
		{
			InitializeComponent ();
            BindingContext = new FormsPageModel();
        }
	}
}