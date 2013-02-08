﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Practices.Unity;

namespace AutoFXProfitsServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AutoFXToolsServerShell : Window
    {
        private AutoFXToolsServerShellViewModel _autoFXToolsServerShellViewModel;
        private ErrorMessageWindow _errorMessageWindow;

        public AutoFXToolsServerShell()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets MainWindowViewModel
        /// </summary>
        [Dependency]
        public AutoFXToolsServerShellViewModel AutoFXToolsServerShellViewModel
        {
            set
            {
                _autoFXToolsServerShellViewModel = value;
                this.DataContext = _autoFXToolsServerShellViewModel;
            }
        }

        private void SearchTermsComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _autoFXToolsServerShellViewModel.SelectionFilterSelectionChanged();
        }

        private void EmailTemplateSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _autoFXToolsServerShellViewModel.EmailTemplateSelectionChanged();
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _errorMessageWindow = new ErrorMessageWindow {Owner = this};
            _errorMessageWindow.ShowDialog();
            if (_errorMessageWindow.MessageBoxSelection)
            {
                _autoFXToolsServerShellViewModel.FreeResources();
            }
            else
            {
                e.Cancel = true;
                _errorMessageWindow.Close();
            }
        }

        private void ListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _autoFXToolsServerShellViewModel.UpdateSelectedUserDetails();
        }
    }
}