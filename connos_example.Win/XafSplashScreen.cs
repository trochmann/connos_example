﻿using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using DevExpress.ExpressApp.Win.Utils;
using DevExpress.Skins;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Svg;
using DevExpress.XtraSplashScreen;

namespace connos_example.Win
{
    public partial class XafSplashScreen : SplashScreen
    {
        private void LoadBlankLogo()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string blankLogoResourceName = assembly.GetName().Name + ".Images.Logo.svg";
            Stream svgStream = assembly.GetManifestResourceStream(blankLogoResourceName);
            if (svgStream != null)
            {
                svgStream.Position = 0;
            }
        }
        protected override void DrawContent(GraphicsCache graphicsCache, Skin skin)
        {
            Rectangle bounds = ClientRectangle;
            bounds.Width--; bounds.Height--;
            graphicsCache.Graphics.DrawRectangle(graphicsCache.GetPen(Color.FromArgb(255, 87, 87, 87), 1), bounds);
        }

        public XafSplashScreen()
        {
            InitializeComponent();
            LoadBlankLogo();
            labelCopyright.Text = "Copyright © " + DateTime.Now.Year.ToString() + " Reinert Immobilienverwaltung GmbH" + System.Environment.NewLine + "All rights reserved.";
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
            if ((UpdateSplashCommand)cmd == UpdateSplashCommand.Description)
            {
                labelStatus.Text = (string)arg;
            }
        }

        #endregion

    }
}