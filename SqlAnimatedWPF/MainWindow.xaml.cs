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
        MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();

            viewModel = new MainViewModel();

            list.ItemsSource = viewModel.SelectAll();
        }
        private void onClickInsert(object sender, RoutedEventArgs e)
        {
            int res = viewModel.Insert(new CommentDto(appNameInsert.Text, userNameInsert.Text, commentInsert.Text));
            if (res > 0)
            {
                update();
            }
        }
        private void onClickUpdate(object sender, RoutedEventArgs e)
        {
            int res = viewModel.Update(new CommentDto(int.Parse(idUpdate.Text), applicationNameUpdate.Text, userNameUpdate.Text, commentUpdate.Text));
            if (res > 0)
            {
                update();
            }
        }
        private void onClickDelete(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItems.Count == 0)
                return;
            
            int res = viewModel.Delete(((CommentDto)list.SelectedItems[0]).Id);
            if(res > 0)
            {
                update();
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
            list.ItemsSource = viewModel.SelectAll();
        }
    }
}
