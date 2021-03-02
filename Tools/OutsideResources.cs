using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Among_Us_Calibrator.Tools {
    public static class OutsideResources
    {

        public static ImageViewer OpenPicture(PictureBox x)
        {
            ImageViewer imageViewer = new ImageViewer(x);
            imageViewer.Show();
            return imageViewer;
        }
        public static void PictureClick(object sender, EventArgs e)
        {
            OpenPicture((PictureBox)sender);
        }
        public static void ClickImageViewer(PictureBox x)
        {
            x.Cursor = Cursors.Hand;
            x.Click += PictureClick;
            toolTipper(x, "Click to enlarge image");
        }
        public static void toolTipper(Control x, String text)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(x, text);
        }

        public static void OpenGithub()
        {
            Process.Start("https://github.com/AlphapixelCodes/Among-Us-Bot");
        }
        public static void openTutorial()
        {
            Process.Start("https://www.youtube.com/watch?v=Yypu6tPwrF4");
        }
        public static void OpenAmongus()
        {
            Process.Start("steam://rungameid/945360");
        }
        public static void OpenYoutubeChanel()
        {
            Process.Start("https://www.youtube.com/channel/UCyTsi1Tja0kkDv26gX5CjxQ");
        }
        internal static void ContactMe()
        {
            Process.Start("mailto:alphapixelcodes@gmail.com");
        }
    }
}
