using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public sealed partial class vsAI : App5.Common.LayoutAwarePage
    {
        public vsAI()
        {
            this.InitializeComponent();
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

       // Pointer mpos;
        private void Image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
          
           
        }
        private void Image_PointerMove(object sender, PointerRoutedEventArgs e)
        {
            
        }

        private void Carrier_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            
        }

        private void Image_ManipulationStarted_1(object sender, ManipulationStartedRoutedEventArgs e)
        {
            e.Handled = true;
            VisualStateManager.GoToState(this, "Dragging", true);
            

        }

        private void Image_ManipulationDelta_1(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            Image image = sender as Image;

            this.translateTransform.X += e.Delta.Translation.X;
            this.translateTransform.Y += e.Delta.Translation.Y;
            if (e.IsInertial)
            {
                e.Complete();
            }
        }
        private void Image_ManipulationCompleted_1(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            e.Handled = true;
            VisualStateManager.GoToState(this, "NotDragging", true);

        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.


        #endregion

        String poss = "";
        private void myRectangle_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (poss.Equals(""))
            {
                this.translateTransform.X = 0;
                this.translateTransform.Y = 0;
                e.Handled = true;
            }
            else
            {
                Image timg = this.FindName(poss) as Image;
                this.myRectangle.Margin = timg.Margin;
                this.translateTransform.X = 0;
                this.translateTransform.Y = 0;

            }
        }
        ImageSource it;
        private void m0_0_DragEnter(object sender, DragEventArgs e)
        {
            
            poss = this.Name;
            Image image = sender as Image;
            image.Opacity = 0.5;
            image.Source = this.jj.Source;

        }

        private void m0_0_DragLeave(object sender, DragEventArgs e)
        {
            poss = "";
            Image image = sender as Image;
            image.Opacity = 1;
        }


       
    }
}
