﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace PublishTool
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static Dispatcher DispatcherHelper;
        public static MainWindow APP;
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = APP;
            APP = new MainWindow();
            DispatcherHelper = APP.Dispatcher;
            //APP.Show();
        }
    }
}
