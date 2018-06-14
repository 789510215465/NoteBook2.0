using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BasicWpfNotepad
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        // 定義檔案儲存路徑
        string filePath = "";
        // 定義用作判斷是否儲存的參考值
        string savedtext = "";

        public MainWindow()
        {
            InitializeComponent();
        }


        // 開啟檔案按鈕
        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            // 產生開啟檔案視窗 OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應 
            if (result == true)
            {
                // 取得檔案路徑 
                filePath = dlg.FileName;

                // 讀取檔案
                TextArea.Text = System.IO.File.ReadAllText(filePath);
            }
        }


        // 存檔檔案按鈕
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // 產生開啟檔案視窗 OpenFileDialog 
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應 
            if (result == true)
            {
                // 取得檔案路徑 
                filePath = dlg.FileName;

                // 儲存檔案
                System.IO.File.WriteAllText(filePath, TextArea.Text);
            }
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e) {
            TextArea.Clear();
        }


        private void SaveAsBtn_Click(object sender, RoutedEventArgs e) {
            // 產生開啟檔案視窗 OpenFileDialog 
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應 
            if (result == true)
            {
                // 取得檔案路徑 
                filePath = dlg.FileName;

                // 儲存檔案
                System.IO.File.WriteAllText(filePath, TextArea.Text);
            }
        }
        
        // 小型字體
        private void SmallFont_Click(object sender, RoutedEventArgs e)
        {
            double fsize = TextArea.FontSize;
            if (fsize != 12.0)
            {
                TextArea.FontSize = 12;
            }
        }

        // 中型字體
        private void MidFont_Click(object sender, RoutedEventArgs e)
        {
            double fsize = TextArea.FontSize;
            if (fsize != 20.0)
            {
                TextArea.FontSize = 20;
            }
        }

        // 大型字體
        private void BigFont_Click(object sender, RoutedEventArgs e)
        {
            double fsize = TextArea.FontSize;
            if (fsize != 28.0)
            {
                TextArea.FontSize = 28;
            }
        }


        // 滑鼠點擊時可移動視窗
        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        // 關閉視窗
        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            if (savedtext != TextArea.Text)
            {
                if (MessageBox.Show("啊啦?你想關閉檔案啦?你要儲存這些變更嗎?本宮秉持著熱心助人溫柔善良的優良人品來提醒囉!如果想要儲存就點下面這個'是',如果你只是手殘按到鍵盤沒有要變更什麼就選另一個'否',如果你只是很好奇這段文字為甚麼麼長而花了不少時間來閱讀,我只會對你說:你把你寶貴的時間浪費在這裡真的好嗎喔呼呼呼,你有那麼多時間不如去減個肥交個女朋友並讚美太陽一番,又或者蹲在角落當個永遠的邊緣人也是可以的啦!算算時間也不早了那麼本宮就告辭囉,呦齁齁齁齁齁齁~~~", "Save or Not", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    // 儲存檔案
                    System.IO.File.WriteAllText(filePath, TextArea.Text);
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        // 最大化或還原
        private void maximumButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        //最小化
        private void minimunButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // 介面色彩模式切換
        private void DarkmodeSwitch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            // 從背景與字的顏色判斷要換成哪種顏色
            if (TextArea.Background == Brushes.White)
            {
                TextArea.Foreground = Brushes.White;
                TextArea.Background = Brushes.Gray;
                filename.Foreground = Brushes.White;
                TitleBar.Background = Brushes.Gray;
                stopButton.Background = Brushes.Gray;
                stopButton.Foreground = Brushes.White;
                maximumButton.Background = Brushes.Gray;
                maximumButton.Foreground = Brushes.White;
                minimunButton.Background = Brushes.Gray;
                minimunButton.Foreground = Brushes.White;
            }
            else if (TextArea.Foreground == Brushes.White)
            {
                TextArea.Foreground = Brushes.DarkGray;
                TextArea.Background = Brushes.White;
                filename.Foreground = Brushes.Gray;
                TitleBar.Background = Brushes.White;
                stopButton.Background = Brushes.White;
                stopButton.Foreground = Brushes.Gray;
                maximumButton.Background = Brushes.White;
                maximumButton.Foreground = Brushes.Gray;
                minimunButton.Background = Brushes.White;
                minimunButton.Foreground = Brushes.Gray;
            }
            if (DarkmodeSwitchInside.Fill == Brushes.Gray)
            {
                DarkmodeSwitchInside.Fill = Brushes.White;
            }
            else
            {
                DarkmodeSwitchInside.Fill = Brushes.Gray;
            }

        }

    }
}

