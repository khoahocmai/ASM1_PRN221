﻿#pragma checksum "..\..\..\RoomPopup.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6CD6374A5033B7167DB6B43F1D0960360E37B436"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DoDuongDangKhoaWPF;
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


namespace DoDuongDangKhoaWPF {
    
    
    /// <summary>
    /// RoomPopup
    /// </summary>
    public partial class RoomPopup : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\RoomPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRoomId;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\RoomPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRoomNumber;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\RoomPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRoomDetailDescription;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\RoomPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRoomMaxCapacity;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\RoomPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbRoomTypeName;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\RoomPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRoomStatus;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\RoomPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRoomPricePerDay;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\RoomPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddUpdate;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DoDuongDangKhoaWPF;component/roompopup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\RoomPopup.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtRoomId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtRoomNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtRoomDetailDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtRoomMaxCapacity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cbbRoomTypeName = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.txtRoomStatus = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtRoomPricePerDay = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnAddUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\RoomPopup.xaml"
            this.btnAddUpdate.Click += new System.Windows.RoutedEventHandler(this.btnAddUpdate_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
