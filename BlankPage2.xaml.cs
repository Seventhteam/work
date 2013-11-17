using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “基本页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234237 上有介绍

namespace App5
{
    /// <summary>
    /// 基本页，提供大多数应用程序通用的特性。
    /// </summary>
    public sealed partial class BlankPage2 : App5.Common.LayoutAwarePage
    {
        public BlankPage2()
        {
            this.InitializeComponent();
            start();
        }

        /// <summary>
        /// 使用在导航过程中传递的内容填充页。在从以前的会话
        /// 重新创建页时，也会提供任何已保存状态。
        /// </summary>
        /// <param name="navigationParameter">最初请求此页时传递给
        /// <see cref="Frame.Navigate(Type, Object)"/> 的参数值。
        /// </param>
        /// <param name="pageState">此页在以前会话期间保留的状态
        /// 字典。首次访问页面时为 null。</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// 保留与此页关联的状态，以防挂起应用程序或
        /// 从导航缓存中放弃此页。值必须符合
        /// <see cref="SuspensionManager.SessionState"/> 的序列化要求。
        /// </summary>
        /// <param name="pageState">要使用可序列化状态填充的空字典。</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {

        }
        private void gamepage_Button(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(gamepage));
        }

        Image imnow;
        TranslateTransform tnow;
        public int[][] myfield = new int[12][];
        public int[][] ships = new int[5][];
        public void start()
        {
            for (int i = 0; i < 12; i++)
            {
                myfield[i] = new int[12];
                for (int j = 0; j < 12; j++)
                {
                    myfield[i][j] = 0;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                ships[i] = new int[3];
                for (int j = 0; j < 3; j++)
                {
                    myfield[i][j] = 0;
                }
            }
        }
        private void zerocl()
        {
            tpx = imnow.Margin.Left - mm.Margin.Left;




            if (imnow != ship1)
            {
                tpy = imnow.Margin.Top + this.ship1.Margin.Top - mm.Margin.Top;
            }
            else
            { tpy = imnow.Margin.Top - mm.Margin.Top; }
            if (tnow.X != 0)
            {
                int i = 1, j = 1;
                while (i < (imnow.Height / 50 + 1))
                {
                    j = 1;
                    while (j < (imnow.Width / 50 + 1))
                    {
                        myfield[i + (int)(tnow.Y + tpy) / 50][j + (int)(tnow.X + tpx) / 50] = 0;
                        
                        j++;
                    }
                    i++;
                }
            }
            String str = "";
            for (int g = 1; g < 11; g++)
            {
                for (int k = 1; k < 11; k++)
                {
                    str = str + myfield[g][k] + ",";
                }
                str = str + "\n";
            }
            t1.Text = str;
        }
        private void Image_ManipulationStarted_1(object sender, ManipulationStartedRoutedEventArgs e)
        {
            
            //VisualStateManager.GoToState(this, "Dragging", true);
            Image im = sender as Image;
            im.Opacity = 0.5;
            imnow = ship1;
            tnow = tf1;
            e.Handled = true;
            zerocl();

        }

        private void Image_ManipulationDelta_1(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            Image image = sender as Image;

            tnow.X += e.Delta.Translation.X;
            tnow.Y += e.Delta.Translation.Y;
            if (e.IsInertial)
            {
                e.Complete();
            }
        }
        private void Image_ManipulationCompleted_1(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            imnow = sender as Image;
            if (imnow == ship1)
            { tnow = tf1; }
            if (imnow == ship2)
            { tnow = tf2; }
            if (imnow == ship3)
            { tnow = tf3; }
            if (imnow == ship4)
            { tnow = tf4; }
            if (imnow == ship5)
            { tnow = tf5; }
            tpx = imnow.Margin.Left - mm.Margin.Left;
            



            if (imnow != ship1)
            {
                tpy = imnow.Margin.Top + this.ship1.Margin.Top - mm.Margin.Top;
            }
            else
            { tpy = imnow.Margin.Top - mm.Margin.Top; }
            //tpy = imnow.Margin.Top - mm.Margin.Top;
            
            imnow.Opacity = 1;
            if (tnow.Y + tpy > -25 && tnow.Y + tpy + imnow.ActualHeight < 525 && tnow.X + tpx > -25 && tnow.X + tpx + imnow.ActualWidth < 525)
            {

                tnow.X = Math.Round((tnow.X + tpx) / 50) * 50 - tpx;
                tnow.Y = Math.Round((tnow.Y + tpy) / 50) * 50 - tpy;
                e.Handled = true;

                int i = 1, j = 1,ch=0;
                while (i < (imnow.Height / 50 + 1))
                {
                    j = 1;
                    while (j < (imnow.Width / 50 + 1))
                    {
                        if (myfield[i + (int)(tnow.Y + tpy) / 50][j + (int)(tnow.X + tpx) / 50] == 1)
                        {
                            ch = 1;
                        }
                        j++;
                    }
                    i++;
                }
                if (ch == 1)
                {
                    tnow.X = 0;
                    tnow.Y = 0;
                    
                    tnow = null;
                    imnow = null;
                    e.Handled = true;
                }
                else
                {
                    i = 1;
                    while (i < (imnow.Height / 50 + 1))
                    {
                        j = 1;
                        while (j < (imnow.Width / 50 + 1))
                        {
                            myfield[i + (int)(tnow.Y + tpy) / 50][j + (int)(tnow.X + tpx) / 50] = 1;
                            
                            j++;
                        }
                        i++;
                    }
                    String str = "";
                    for (int g = 1; g < 11; g++)
                    {
                        for (int k = 1; k < 11; k++)
                        {
                            str = str + myfield[g][k] + ",";
                        }
                        str = str + "\n";
                    }
                    t1.Text = str;
                }
                tnow = null;
                imnow = null;
            }
            else
            {
                tnow.X = 0;
                tnow.Y = 0;
                tnow = null;
                imnow = null;
                e.Handled = true;

            }

        }

        double tpx, tpy;
        private void myRectangle_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            
        }

        private void ship1_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {

            Image im = sender as Image;
            imnow = im; tnow = tf1; zerocl();
            double tpw = im.Height;
            im.Height = im.Width;
            im.Width = tpw;

            imnow = im;
            tnow = tf1;
            tnow.X = 0;
            tnow.Y = 0;
            if (im.Width == 50)
            {ships[0][0] = 1;}
            else
            { ships[0][0] = 0;}
            e.Handled=true;
            

        }

        private void ship2_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            Image im = sender as Image;
            im.Opacity = 0.5;
            imnow = ship2;
            tnow = tf2;
            e.Handled = true;
            zerocl();
        }

        private void ship3_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            Image im = sender as Image;
            im.Opacity = 0.5;
            imnow = ship3;
            tnow = tf3;
            e.Handled = true;
            zerocl();
        }

        private void ship4_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            Image im = sender as Image;
            im.Opacity = 0.5;
            imnow = ship4;
            tnow = tf4;
            e.Handled = true;
            zerocl();
        }

        private void ship5_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            Image im = sender as Image;
            im.Opacity = 0.5;
            imnow = ship5;
            tnow = tf5;
            e.Handled = true;
            zerocl();
        }

        private void ship2_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Image im = sender as Image;
            imnow = im; tnow = tf2; zerocl();
            double tpw = im.Height;
            im.Height = im.Width;
            im.Width = tpw;

            imnow = im;
            tnow = tf2;
            tnow.X = 0;
            tnow.Y = 0;
            if (im.Width == 50)
            { ships[1][0] = 1; }
            else
            { ships[1][0] = 0; }
            e.Handled = true;
        }

        private void ship3_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Image im = sender as Image;
            imnow = im; tnow = tf3; zerocl();
            double tpw = im.Height;
            im.Height = im.Width;
            im.Width = tpw;

            imnow = im;
            tnow = tf3;
            tnow.X = 0;
            tnow.Y = 0;
            if (im.Width == 50)
            { ships[2][0] = 1; }
            else
            { ships[2][0] = 0; }
            e.Handled = true;
        }

        private void ship4_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Image im = sender as Image;
            imnow = im; tnow = tf4; zerocl();
            double tpw = im.Height;
            im.Height = im.Width;
            im.Width = tpw;

            imnow = im;
            tnow = tf4;
            tnow.X = 0;
            tnow.Y = 0;
            if (im.Width == 50)
            { ships[3][0] = 1; }
            else
            { ships[3][0] = 0; }
            e.Handled = true;
        }

        private void ship5_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Image im = sender as Image;
            imnow = im; tnow = tf5; zerocl();
            double tpw = im.Height;
            im.Height = im.Width;
            im.Width = tpw;

            imnow = im;
            tnow.X = 0;
            tnow.Y = 0;
            if (im.Width == 50)
            { ships[4][0] = 1; }
            else
            { ships[4][0] = 0; }
            e.Handled = true;

        }

        private void backButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            ships[0][1] = (int)tf1.Y;
            ships[0][2] = (int)tf1.X;
            ships[1][1] = (int)tf2.Y;
            ships[1][2] = (int)tf2.X;
            ships[2][1] = (int)tf3.Y;
            ships[2][2] = (int)tf3.X;
            ships[3][1] = (int)tf4.Y;
            ships[3][2] = (int)tf4.X;
            ships[4][1] = (int)tf5.Y;
            ships[4][2] = (int)tf5.X;
            this.Frame.Navigate(typeof(gamepage),this);
        }

    }
}
