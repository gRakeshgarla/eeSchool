using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Controls;

namespace eeSchool
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        List<String> schoolList;
		public LoginPage ()
		{
			InitializeComponent ();

            schoolList = new List<String>
            {
                "School A","School B","School C"
            };

            school.ItemsSource = schoolList;

       //     if (Application.Current.Properties.ContainsKey("user"))
         //       username.Text = Application.Current.Properties["user"] as string;

       //     if (Application.Current.Properties.ContainsKey("pass"))
         //       password.Text = Application.Current.Properties["pass"] as string;

       //  if (Application.Current.Properties.ContainsKey("school"))
       //         school.SelectedIndex = Int32.Parse(Application.Current.Properties["school"] as string);
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (username.Text.ToUpper().Equals("ADMIN") && password.Text.ToUpper().Equals("ADMIN") 
                                            & schoolList[school.SelectedIndex].ToUpper().Equals("SCHOOL A"))
            {
                if (RememberMe.Checked)
                {
                    Application.Current.Properties["user"] = username.Text;
                    Application.Current.Properties["pass"] = password.Text;
                    Application.Current.Properties["school"] = school.SelectedIndex;
                    Application.Current.SavePropertiesAsync();
                }
               Navigation.PushAsync(new AdminMainPage(schoolList[school.SelectedIndex]));

            }
            else
            {
                DisplayAlert("Login Failed", "Please check the Login details once again", "OK");
            }
        }
    }
}
