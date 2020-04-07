﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using Autofac;

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
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(UnhandledExceptionHandler);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // DI-контейнер здесь не очень нужен, но я захотел поизучать Autofac
            var builder = new ContainerBuilder();
            builder.RegisterType<MainPresenter>();
            //builder.RegisterType<MainForm>();
            builder.RegisterInstance(new MainForm());
            builder.Register((c, forType) =>
            {
                return LogManager.GetLogger(forType.Named<Type>("TypeOf").FullName);
            }).
            As<ILogger>();

            builder.Register((c, forType) =>
            {
                return new MainPresenter(Container.Resolve<MainForm>(),
                    Container.Resolve<ILogger>(new NamedParameter("TypeOf", typeof(MainPresenter))));
            }).
            As<MainPresenter>();

            Container = builder.Build();
            /////////////////
            
            var mainForm = new MainForm();
            var presenter = Container.Resolve<MainPresenter>();
                //new MainPresenter(
                //Container.Resolve<MainForm>(), 
                //Container.Resolve<ILogger>(new NamedParameter("TypeOf", typeof(MainPresenter))));
            Application.Run(presenter.MainForm);
        }

        private static void UnhandledExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Критическая ошибка, смотри лог", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //!! TODO лог ошибки
            Application.Exit();
        }
    }
}
