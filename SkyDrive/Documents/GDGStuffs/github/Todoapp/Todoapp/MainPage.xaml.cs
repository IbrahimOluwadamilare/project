using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Todoapp.Resources;
using Todoapp.Classes;
using System.Collections.ObjectModel;

namespace Todoapp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private ToDoDataContext _context;
        private ObservableCollection<ToDo> _events;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _context = new ToDoDataContext(ToDoDataContext.ConnectionString);
            _events = new ObservableCollection<ToDo>(_context.Events);
            EventsListBox.ItemsSource = _events;
            
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _context.Dispose();
            _context = null;
            base.OnNavigatedFrom(e);
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewEvent.xaml", UriKind.Relative));
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (EventsListBox.SelectedItem != null) 
            {
                var even = EventsListBox.SelectedItem as ToDo;

                if (!_context.Events.Any(j => j.Equals(even))) 
                {
                    _context.Events.Attach(even);
                }
                _context.Events.DeleteOnSubmit(even);
                _context.SubmitChanges();
                _events.Remove(even);
            }
        }


    }
}