﻿#pragma checksum "..\..\..\..\UserControls\ShowComics.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9584F2D4C75608CFE0EBC323C03BBA9CCFBBC125"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using LibraryAssigmentWPF.UserControls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace LibraryAssigmentWPF.UserControls {
    
    
    /// <summary>
    /// ShowComics
    /// </summary>
    public partial class ShowComics : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\UserControls\ShowComics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock title;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\UserControls\ShowComics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\UserControls\ShowComics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LibraryAssigmentWPF.UserControls.MenuButton btnReturn;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\UserControls\ShowComics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LibraryAssigmentWPF.UserControls.MenuButton btnWord;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\UserControls\ShowComics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LibraryAssigmentWPF.UserControls.MenuButton btnFind;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\UserControls\ShowComics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LibraryAssigmentWPF.UserControls.MenuButton btnRevert;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\UserControls\ShowComics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LibraryAssigmentWPF.UserControls.ClearableTextBox textBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LibraryAssigmentWPF;component/usercontrols/showcomics.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\ShowComics.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.listBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.btnReturn = ((LibraryAssigmentWPF.UserControls.MenuButton)(target));
            return;
            case 4:
            this.btnWord = ((LibraryAssigmentWPF.UserControls.MenuButton)(target));
            return;
            case 5:
            this.btnFind = ((LibraryAssigmentWPF.UserControls.MenuButton)(target));
            return;
            case 6:
            this.btnRevert = ((LibraryAssigmentWPF.UserControls.MenuButton)(target));
            return;
            case 7:
            this.textBox = ((LibraryAssigmentWPF.UserControls.ClearableTextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

