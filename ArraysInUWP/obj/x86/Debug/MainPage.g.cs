﻿#pragma checksum "C:\Users\User\Documents\GitHub\MyProjects\ArraysInUWP\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "30CC392425E873277765EEC57DB8BE83C2530C59ECCEBF7E26F085DA085D2529"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArraysInUWP
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 26
                {
                    this.nameInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // MainPage.xaml line 27
                {
                    this.gradeInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // MainPage.xaml line 37
                {
                    this.sortButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 5: // MainPage.xaml line 38
                {
                    this.listOutput = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.listOutput).SizeChanged += this.listOutput_SizeChanged;
                }
                break;
            case 6: // MainPage.xaml line 30
                {
                    this.enterButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.enterButton).Click += this.Button_Click;
                }
                break;
            case 7: // MainPage.xaml line 31
                {
                    this.copyButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.copyButton).Click += this.Copy_Click;
                }
                break;
            case 8: // MainPage.xaml line 32
                {
                    this.removeSelectedButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.removeSelectedButton).Click += this.RemoveSelected_Click;
                }
                break;
            case 9: // MainPage.xaml line 33
                {
                    this.removeFirst = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.removeFirst).Click += this.RemoveFirst_Click;
                }
                break;
            case 10: // MainPage.xaml line 34
                {
                    this.removeLast = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.removeLast).Click += this.RemoveLast_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

