# GettingStarted_Kanban_MAUI
## Creating an application using .NET MAUI Kanban Board control

1. Create a new .NET MAUI application in Visual Studio.
2. Syncfusion .NET MAUI components are available in [nuget.org](https://www.nuget.org/). To add SfKanban to your project, open the NuGet package manager in Visual Studio, search for Syncfusion.Maui.Kanban and then install it.
3. To initialize the control, import the Kanban namespace.
4. Initialize [SfKanban]().

#### XAML
```xaml
<ContentPage . . .    
             xmlns:kanban="clr-namespace:Syncfusion.Maui.Kanban;assembly=Syncfusion.Maui.Kanban">

    <kanban:SfKanban/>
    
</ContentPage>
```
 #### C#
 ``` C#
using Syncfusion.Maui.Kanban;
namespace KanbanGettingStarted
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();           
            SfKanban kanban = new SfKanban(); 
            this.Content = kanban;
        }
    }   
}
```

## Register the handler

Syncfusion.Maui.Core nuget is a dependent package for all Syncfusion controls of .NET MAUI. In the MauiProgram.cs file, register the handler for Syncfusion core.
#### C#
```C#
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.Xaml;
using Syncfusion.Maui.Core.Hosting;

namespace KanbanGettingStarted
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
            .UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

            return builder.Build();
        }
    }
}
```

## Initialize view model

Create a ViewModel class with a collection property to hold a collection of [`KanbanModel`]() instances as shown below. Each [`KanbanModel`]() instance represent a card in Kanban control.

#### C#
``` C#
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
```

Set the `ViewModel` instance as the `BindingContext` of your Page; this is done to bind properties of `ViewModel` to [`SfKanban`]().

N> Add namespace of ViewModel class in your XAML page if you prefer to set BindingContext in XAML.
#### XAML
```xaml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
            xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
            x:Class="KanbanGettingStarted.MainPage"
            xmlns:chart="clr-namespace:Syncfusion.Maui.Kanban;assembly=Syncfusion.Maui.Kanban"
            xmlns:local="clr-namespace:KanbanGettingStarted"> 

    <ContentPage.BindingContext>
        <local:ViewModel/>  
    </ContentPage.BindingContext>
</ContentPage>
```
#### C#
```C#
    this.BindingContext = new ViewModel();
```
## Binding data to SfKanban

Bind the above data to [`SfKanban`]() using [`ItemsSource`]() property.

#### XAML
```xaml
<kanban:SfKanban ItemsSource="{Binding Cards}">
</kanban:SfKanban>
```
#### C#
```C#
kanban.SetBinding(SfKanban.ItemsSourceProperty, "Cards");
```
## Defining columns

The columns are generated automatically based on the different values of [`Category`]() in the [`KanbanModel`]() class from [`ItemsSource`](). But, you can also define the columns by setting [`AutoGenerateColumns`]() property to false and adding [`KanbanColumn`]() instance to [`Columns`]() property of [`SfKanban`]().
Define the categories of column using [`Categories`]() property of [`KanbanColumn`]() and cards will be added to the respective columns.
#### XAML
```xaml
<kanban:SfKanban x:Name="kanban" AutoGenerateColumns="False" HorizontalOptions="FillAndExpand" VerticalOptions="FillAndExpand" ItemsSource="{Binding Cards}">   
   <kanban:SfKanban.Columns>
         <kanban:KanbanColumn Title="To Do" Categories="Open" />
         <kanban:KanbanColumn Title="In Progress" Categories="In Progress" />
         <kanban:KanbanColumn Title="Code Review" Categories="Code Review" />
         <kanban:KanbanColumn Title="Done"  Categories="Done"/>
   </kanban:SfKanban.Columns>
 
</kanban:SfKanban> 
```

#### C#
```C#
kanban.AutoGenerateColumns = false; 
kanban.SetBinding(SfKanban.ItemsSourceProperty, "Cards");

KanbanColumn openColumn = new KanbanColumn();
openColumn.Title = "Open";
openColumn.Categories = new List<object>() { "Open" };
kanban.Columns.Add(openColumn);

KanbanColumn progressColumn = new KanbanColumn();
progressColumn.Title = "In Progress";
progressColumn.Categories = new List<object>() { "In Progress" };
kanban.Columns.Add(progressColumn);

KanbanColumn codeColumn = new KanbanColumn();
codeColumn.Title = "Code Review";
codeColumn.Categories = new List<object>() { "Code Review" };
kanban.Columns.Add(codeColumn);

KanbanColumn doneColumn = new KanbanColumn();
doneColumn.Title = "Done";
doneColumn.Categories = new List<object>() { "Done" };
kanban.Columns.Add(doneColumn);
```

This is how the final output will look like.

<img width="716" alt="Kanban_getting_started" src="https://github.com/user-attachments/assets/6046fbe9-c429-4474-812d-fa53180344b5">

