using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using model;

namespace veiwmodel
{
    public class CategoryVeiwModel:INotifyPropertyChanged
    {
        public CategoryVeiwModel() 
        {
            this.CategoriesCollection = new ObservableCollection<category>(new Categories());
            this.CategoryTitle = "Categories";
            this.CategoryDescription = "List of stuffs";
        }
        public void NotifyPropertyChanged(String propertyName) 
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private string title;
        public string CategoryTitle 
        {
            get { return this.title;}
            set 
            {
                this.title = value;
                NotifyPropertyChanged("Title");
            }
        }

        private string description;
        public string CategoryDescription 
        {
            get { return this.description; }
            set 
            {
                this.description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public ObservableCollection<category> CategoriesCollection { get; set; }
    }
}
