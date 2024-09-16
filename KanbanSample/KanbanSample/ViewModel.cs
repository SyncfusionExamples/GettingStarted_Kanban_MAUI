﻿using Syncfusion.Maui.Kanban;
using System.Collections.ObjectModel;

namespace KanbanSample
{
    public class ViewModel
    {
        public ObservableCollection<KanbanModel> Cards { get; set; }
        public ViewModel()
        {
            Cards = new ObservableCollection<KanbanModel>();
            Cards.Add(new KanbanModel()
            {
                ID = 1,
                Title = "iOS - 1002",
                ImageURL = "People_Circle1.png",
                Category = "Open",
                Description = "Analyze customer requirements",
                IndicatorFill = Colors.Red,
                Tags = new List<string> { "Incident", "Customer" }
            });
            Cards.Add(new KanbanModel()
            {
                ID = 6,
                Title = "Xamarin - 4576",
                ImageURL = "People_Circle2.png",
                Category = "Open",
                Description = "Show the retrieved data from the server in grid control",
                IndicatorFill = Colors.Green,
                Tags = new List<string> { "Story", "Customer" }
            });
            Cards.Add(new KanbanModel()
            {
                ID = 13,
                Title = "UWP - 13",
                ImageURL = "People_Circle3.png",
                Category = "In Progress",
                Description = "Add responsive support to application",
                IndicatorFill = Colors.Brown,
                Tags = new List<string> { "Story", "Customer" }
            });
            Cards.Add(new KanbanModel()
            {
                ID = 2543,
                Title = "IOS- 11",
                Category = "Code Review",
                ImageURL = "People_Circle4.png",
                Description = "Check login page validation",
                IndicatorFill = Colors.Brown,
                Tags = new List<string> { "Story", "Customer" }
            });
            Cards.Add(new KanbanModel()
            {
                ID = 123,
                Title = "UWP-21",
                Category = "Done",
                ImageURL = "People_Circle5.png",
                Description = "Check login page validation",
                IndicatorFill = Colors.Brown,
                Tags = new List<string> { "Story", "Customer" }
            });
        }
           
    }
}
