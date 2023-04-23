using SqlAnimatedWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SqlAnimatedWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainViewModel();

            list.ItemsSource = _viewModel.SelectAll();
        }
        private void onClickInsert(object sender, RoutedEventArgs e)
        {
            if (appNameInsert.Text == "" || userNameInsert.Text == "" || commentInsert.Text == "")
            {
                showNotification("Fields must be fieled", false);
                return;
            }
            
            int res = _viewModel.Insert(appNameInsert.Text, userNameInsert.Text, commentInsert.Text);
            if (res > 0)
            {
                update();
                showNotification("Inserted", true);
            }
            else
            {
                showNotification("Error", false);
            }
        }
        private void onClickUpdate(object sender, RoutedEventArgs e)
        {
            if (applicationNameUpdate.Text == "" || userNameUpdate.Text == "" || commentUpdate.Text == "") { 
                showNotification("Fields must be fieled", false);
                return;
            }

            int res = _viewModel.Update(int.Parse(idUpdate.Text), applicationNameUpdate.Text, userNameUpdate.Text, commentUpdate.Text);
            if (res > 0)
            {
                update();
                showNotification("Updated", true);
            }
            else
            {
                showNotification("Error", false);
            }
        }
        private void onClickDelete(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItems.Count == 0)
            {
                showNotification("You must select a comment", false);
                return;
            }

            int res = 0;
            for(int i=0;i<list.SelectedItems.Count ;i++ )
                res += _viewModel.Delete(((CommentDto)list.SelectedItems[i]).Id);

            if (res > 0)
            {
                update();
                showNotification("Success. "+res+" field(s) deleted", true);
            }
            else
            {
                showNotification("Error", false);
            }
        }

        private void clearUpdateFields()
        {
            applicationNameUpdate.IsEnabled = false;
            applicationNameUpdate.Text = "";

            userNameUpdate.IsEnabled = false;
            userNameUpdate.Text = "";

            commentUpdate.IsEnabled = false;
            commentUpdate.Text = "";

            updateButton.IsEnabled = false;
            updateButton.Opacity = 0.5;
        }
        private void updateBtn_TextChanged(object sender, TextChangedEventArgs e)
        {
            int id;
            if (!int.TryParse(idUpdate.Text, out id))
            {
                clearUpdateFields();
                return;
            }

            for(int i=0;i<list.Items.Count ; i++)
            {
                CommentDto currComment = ((CommentDto)list.Items[i]);
                if (currComment.Id == id)
                {
                    applicationNameUpdate.IsEnabled = true;
                    applicationNameUpdate.Text = currComment.ApplicationName;

                    userNameUpdate.IsEnabled = true;
                    userNameUpdate.Text = currComment.UserName;

                    commentUpdate.IsEnabled = true;
                    commentUpdate.Text = currComment.Comment;

                    updateButton.IsEnabled = true;
                    updateButton.Opacity = 1;
                    return;
                }
            }
            clearUpdateFields();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void update()
        {
            list.ItemsSource = _viewModel.SelectAll();
        }
        private void showNotification(string text, bool goodNotifivation)
        {
            notification.Content = text;
            notification.Visibility = Visibility.Visible;

            if (goodNotifivation)
            {
                SolidColorBrush backgroundBrush = new SolidColorBrush();
                backgroundBrush.Color = Color.FromArgb(127, 189, 147, 249);
                notification.Background = backgroundBrush;
            }
            else
            {
                SolidColorBrush backgroundBrush = new SolidColorBrush();
                backgroundBrush.Color = Color.FromArgb(255, 100, 33, 33);
                notification.Background = backgroundBrush;
            }

            var opacity = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5),
                AccelerationRatio = 1
            };
            var margin = new ThicknessAnimation
            {
                
                From = new Thickness(15, 25, 15, 15),
                To = new Thickness(15, 15, 15, 15),
                Duration = TimeSpan.FromSeconds(0.5),
                AccelerationRatio = 1
            };

            notification.BeginAnimation(UIElement.OpacityProperty, opacity);
            notification.BeginAnimation(Label.MarginProperty, margin);
        }

        private void notification_MouseEnter(object sender, MouseEventArgs e)
        {
            var opacity = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5),
                AccelerationRatio = 1
            };
            opacity.Completed += (o, e) => notification.Visibility = Visibility.Hidden;

            notification.BeginAnimation(UIElement.OpacityProperty, opacity);

        }
    }
}
