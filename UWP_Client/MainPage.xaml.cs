﻿using MyMessanger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static int MessageID;
        private static string UserName;
        private static MessangerClientAPI API = new MessangerClientAPI();
        DispatcherTimer timer;

        public MainPage()
        {
            this.InitializeComponent();
            timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 1)
            };

            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            Message msg = API.GetMessage(MessageID);

            while (msg != null)
            {
                MessagesLB.Items.Add(msg);
                MessageID++;
                msg = API.GetMessage(MessageID);
            }
        }

        [Obsolete]
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string UserName = UserNameTB.Text;
            string Message = MessageTB.Text;

            if ((UserName.Length > 1) && (Message.Length > 1))
            {
                Message msg = new MyMessanger.Message(UserName, Message, DateTime.Now);
                API.SendMessageRestSharp(msg);
            }
        }
    }
}
