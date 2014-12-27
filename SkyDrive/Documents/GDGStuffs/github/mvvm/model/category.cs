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
using System.Collections.Generic;

namespace model
{
    public class category
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class Categories : List<category>
    {
        public Categories()
        {
            this.Add(new category()
            {
                ID = 1,
                Title = "Books",
                Description = "This is a list that includes all the books available",
            });
            this.Add(new category()
            {
                ID = 2,
                Title = "TextBooks",
                Description = "This is a list that includes all the books available",
            });
            this.Add(new category()
            {
                ID = 3,
                Title = "Novels",
                Description = "This is a list that includes all the books available",
            });
            this.Add(new category()
            {
                ID = 4,
                Title = "Encyclopedia",
                Description = "This is a list that includes all the books available",
            });
        }
    }
}
