using System;
using System.Windows;
using Microsoft.Win32;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;

namespace OpenRA.ModMaker.UI.Dialogs
{
    public class CustomOpenFileDialog : IFrameworkDialog
    {
        private readonly OpenFileDialogSettings settings;
        private readonly OpenFileDialog openFileDialog;

        public CustomOpenFileDialog(OpenFileDialogSettings settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));

            openFileDialog = new OpenFileDialog
            {
                AddExtension = settings.AddExtension,
                CheckFileExists = settings.CheckFileExists,
                CheckPathExists = settings.CheckPathExists,
                DefaultExt = settings.DefaultExt,
                FileName = settings.FileName,
                Filter = settings.Filter,
                FilterIndex = settings.FilterIndex,
                InitialDirectory = settings.InitialDirectory,
                Multiselect = settings.Multiselect,
                Title = settings.Title
            };
        }
        public bool? ShowDialog(Window owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));

            var result = openFileDialog.ShowDialog(owner);

            // Update settings
            settings.FileName = openFileDialog.FileName;
            settings.FileNames = openFileDialog.FileNames;
            settings.FilterIndex = openFileDialog.FilterIndex;

            return result;
        }
    }
}
