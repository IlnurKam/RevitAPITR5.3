using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITR5._3
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "Revit API training";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath = @"C:\Program files\RevitAPITraining\";

            var panel = application.CreateRibbonPanel(tabName, "Стены");

            var button = new PushButtonData("Тип", "Смена типа стен", 
                Path.Combine(utilsFolderPath, "RevitAPITraningUI.dll"), 
                "RevitAPITraningUI.Main");

            Uri uriImage = new Uri(@"C:\Program Files\RevitApiTraining\Images\RevitAPITrainingUI_32.png", UriKind.Absolute);
            BitmapImage largeImage = new BitmapImage(uriImage);
            button.LargeImage = largeImage;

            panel.AddItem(button);

            return Result.Succeeded;
        }
    }
}
