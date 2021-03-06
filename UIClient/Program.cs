﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using Autofac;
using ServiceManager;

namespace UIClient
{
    static class Program
    {
        private static IContainer Container { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler1;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // DI-контейнер здесь не очень нужен, но я захотел поизучать Autofac
            var builder = new ContainerBuilder();
            builder.RegisterType<MainForm>();
            builder.Register((c, forType) =>
            {
                return LogManager.GetLogger(forType.Named<Type>("TypeOf").FullName);
            }).
            As<ILogger>();

            builder.RegisterInstance(new ConfigLoader()).As<IConnectionStringLoader>().SingleInstance();

            builder.RegisterType<ServiceConnector>();

            builder.RegisterType<ConnectionSettingsDialog.ConnectionDialog>();

            builder.Register((c, p) =>
            {
                return new MainPresenter(Container.Resolve<MainForm>(),
                    Container.Resolve<ServiceConnector>(),
                    Container.Resolve<ConnectionSettingsDialog.ConnectionDialog>(),
                    Container.Resolve<ILogger>(new NamedParameter("TypeOf", typeof(MainPresenter))));
            }).
            As<MainPresenter>();

            Container = builder.Build();
            /////////////////
            
            var presenter = Container.Resolve<MainPresenter>();
            Application.Run(presenter.MainForm);
        }

        private static void UnhandledExceptionHandler1(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Критическая ошибка, смотри лог", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            var logger = Container.Resolve<ILogger>(new NamedParameter("TypeOf", typeof(Program)));
            logger.Fatal(e.ExceptionObject);
            Application.Exit();
        }
    }
}
