﻿#pragma checksum "I:\Bar Projects\MyProjects\DodgeGame\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "751C2C5F4B0CDDDB21F475A4634F02FF18118953F295798B1BD8EAA383F74957"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DodgeGame
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
            case 1: // MainPage.xaml line 1
                {
                    this._page = (global::Windows.UI.Xaml.Controls.Page)(target);
                }
                break;
            case 2: // MainPage.xaml line 10
                {
                    this.canvas = (global::Windows.UI.Xaml.Controls.Canvas)(target);
                }
                break;
            case 3: // MainPage.xaml line 11
                {
                    this.healthText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // MainPage.xaml line 13
                {
                    this.startNewButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.startNewButton).Click += this.startNewButton_Click;
                }
                break;
            case 5: // MainPage.xaml line 14
                {
                    this.saveGameButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.saveGameButton).Click += this.saveGameButton_Click;
                }
                break;
            case 6: // MainPage.xaml line 15
                {
                    this.loadGameButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 7: // MainPage.xaml line 17
                {
                    this.diffucultyButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 8: // MainPage.xaml line 27
                {
                    this.pauseButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.pauseButton).Click += this.pauseButton_Click;
                }
                break;
            case 9: // MainPage.xaml line 28
                {
                    this.pause_play = (global::Windows.UI.Xaml.Controls.SymbolIcon)(target);
                }
                break;
            case 10: // MainPage.xaml line 20
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element10 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element10).Click += this.MenuFlyoutItem_Click;
                }
                break;
            case 11: // MainPage.xaml line 21
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element11 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element11).Click += this.MenuFlyoutItem_Click_1;
                }
                break;
            case 12: // MainPage.xaml line 22
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element12 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element12).Click += this.MenuFlyoutItem_Click_2;
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
