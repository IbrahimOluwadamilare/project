using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Church_App.Resources;
using System.Xml.Linq;

namespace Church_App.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }
        public bool IsDataLoaded { get; private set; }
        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            //
            // First, let's load the XML data from the file
            // containing all 154 sonnets.
            //
            XDocument xdoc = XDocument.Load("Content/ShakespeareSonnets.xml");

            //
            // Then, we select the each 'Sonnet' block and build an
            // ItemViewModel for each one
            //
            // The reason we do it this way instead of just a single complex
            // LINQ query is that we need to do special handling for lines
            // 1, 13 and 14 of each sonnet
            //
            var dataEnum = xdoc.Descendants("Sonnet");

            foreach (XElement e in dataEnum)
            {
                //
                // Create an empty ItemViewModel
                //
                ItemViewModel ivm = new ItemViewModel();

                //
                // The main item shown in the ListBox is the number
                // of the sonnet in Roman numerals
                //
                ivm.LineOne = (string)e.Element("Number").Value;

                //
                // Now, we get an IEnumerable enabling the procesing
                // of each <Line> element in the <Body> tag
                //
                int lineNum = 1;
                string sonnetBody = "";

                var bodyEnum = e.Element("Body").Descendants("Line");


                foreach (XElement line in bodyEnum)
                {
                    //
                    // If it's the first line, we put the value into the ItemViewModel
                    // in the LineTwo property so it shows on the main page underneath the
                    // Sonnet number
                    if (lineNum == 1)
                        ivm.LineTwo = (string)line.Value;

                    
                        sonnetBody = sonnetBody + "\r\n" + line.Value;
                    
                }
                ivm.LineThree = sonnetBody;

                //
                // And finally, we add it to the Items collection used
                // as a DataBinding source for ListBox
                this.Items.Add(ivm);
            }

            this.IsDataLoaded = true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

      
    }
}