using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Todoapp.Classes;
using Todoapp.Resources;
using System.Collections.ObjectModel;


namespace Todoapp
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private ToDoDataContext _context;
        private ObservableCollection<ToDo> _events;
        private void DeleteNew_Click(object sender, EventArgs e)
        {
            EventTextBox.Text = "";
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _context.Dispose();
            _context = null;
            base.OnNavigatedFrom(e);
        }

        private void Save_Click(object sender, EventArgs e)
        {
                var eventns = new ToDo()
                {
                    Event = EventTextBox.Text,
                };

                _context.Events.InsertOnSubmit(eventns);
                _context.SubmitChanges();
                _events.Add(eventns);
                EventTextBox.Text = String.Empty;
        }
    }
}