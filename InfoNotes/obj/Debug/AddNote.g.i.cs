﻿

#pragma checksum "F:\Almodad\projects\Visual studio 2015\InfoNotes\InfoNotes\AddNote.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4CDA815E12DC70541464BB521E1C9F0B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InfoNotes
{
    partial class AddNote : global::Windows.UI.Xaml.Controls.Page
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.AppBarButton btnSave; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.AppBarButton btnCancel; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox titleTextBox; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ComboBox ComboBoxMenu; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox descriptionTextBox; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///AddNote.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            btnSave = (global::Windows.UI.Xaml.Controls.AppBarButton)this.FindName("btnSave");
            btnCancel = (global::Windows.UI.Xaml.Controls.AppBarButton)this.FindName("btnCancel");
            titleTextBox = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("titleTextBox");
            ComboBoxMenu = (global::Windows.UI.Xaml.Controls.ComboBox)this.FindName("ComboBoxMenu");
            descriptionTextBox = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("descriptionTextBox");
        }
    }
}



