using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FluentAssertions.Mvc.Tests;
using System.Web.Mvc;
using System.Web.Routing;
using FluentAssertions.Mvc;
using FluentAssertions;

namespace test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var test = new RouteDataAssertions_Tests();
            test.HaveDataToken_GivenExpectedArea_ShouldPass();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }


    }
}
