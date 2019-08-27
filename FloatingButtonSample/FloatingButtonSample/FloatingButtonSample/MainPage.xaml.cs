using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FloatingButtonSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private List<ListItem> ListData = new List<ListItem>();

        public MainPage()
        {
            InitializeComponent();

            // 初期データを準備
            for (int i = 1; i < 100; i++)
            {
                ListData.Add(new ListItem("2019/10/10", "title" + i, "content" + i));
            }

            // ListViewにデータソースをセット
            listView.ItemsSource = ListData;

        }

        // リスト1件のデータを表すクラス
        public class ListItem
        {
            public string Date { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }

            public ListItem(string date, string title, string content)
            {
                this.Date = date;
                this.Title = title;
                this.Content = content;
            }
        }

    }
}
