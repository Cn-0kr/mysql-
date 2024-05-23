/*Formsize: 1487,959左右*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 球员比赛身价评估
{
    public partial class RaceDataInputForm : Form
    {
        private Image backgroundImage;
        private List<ImageItem> imageItems;

        public RaceDataInputForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(RaceDataInputForm_Load);
            this.MouseClick += new MouseEventHandler(RaceDataInputForm_MouseClick);

        }

        private void RaceDataInputForm_Load(object sender, EventArgs e)
        {
            // 从资源加载背景图片
            backgroundImage = Properties.Resources.backgroundImage;
            // 使窗体支持双缓冲，以减少闪烁
            this.DoubleBuffered = true;

            // 初始化 imageItems 列表
            imageItems = new List<ImageItem>
            {
                new ImageItem(Properties.Resources.player1, new Rectangle(50, 200, Properties.Resources.player1.Width / 2, Properties.Resources.player1.Height / 2), typeof(P1dataform)),
                new ImageItem(Properties.Resources.player2, new Rectangle(250, 350, Properties.Resources.player2.Width / 2, Properties.Resources.player2.Height / 2), typeof(P2dataform)),
                new ImageItem(Properties.Resources.player3, new Rectangle(250, 50, Properties.Resources.player3.Width / 2, Properties.Resources.player3.Height / 2), typeof(P3dataform)),
                new ImageItem(Properties.Resources.player4, new Rectangle(150, 100, Properties.Resources.player4.Width / 2, Properties.Resources.player4.Height / 2), typeof(P4dataform)),
                new ImageItem(Properties.Resources.player5, new Rectangle(150, 300, Properties.Resources.player5.Width / 2, Properties.Resources.player5.Height / 2), typeof(P5dataform)),
                new ImageItem(Properties.Resources.player6, new Rectangle(300, 150, Properties.Resources.player6.Width / 2, Properties.Resources.player6.Height / 2), typeof(P6dataform)),
                new ImageItem(Properties.Resources.player7, new Rectangle(500, 315, Properties.Resources.player7.Width / 2, Properties.Resources.player7.Height / 2), typeof(P7dataform)),
                new ImageItem(Properties.Resources.player8, new Rectangle(315, 250, Properties.Resources.player8.Width / 2, Properties.Resources.player8.Height / 2), typeof(P8dataform)),
                new ImageItem(Properties.Resources.player9, new Rectangle(575, 175, Properties.Resources.player9.Width / 2, Properties.Resources.player9.Height / 2), typeof(P9dataform)),
                new ImageItem(Properties.Resources.player10, new Rectangle(465, 195, Properties.Resources.player10.Width / 2, Properties.Resources.player10.Height / 2), typeof(P10dataform)),
                new ImageItem(Properties.Resources.player11, new Rectangle(500, 85, Properties.Resources.player11.Width / 2, Properties.Resources.player11.Height / 2), typeof(P11dataform)),

                // Add more ImageItems for player4-player11 with appropriate positions and form types...
            };
        }

        // 定义 ImageItem 类来存储图片信息
        public class ImageItem
    {
        public Image Image { get; set; }
        public Rectangle Rect { get; set; }
        public Type FormType { get; set; }
        public bool IsFormOpen { get; set; }

        public ImageItem(Image image, Rectangle rect, Type formType)
        {
            Image = image;
            Rect = rect;
            FormType = formType;
            IsFormOpen = false;
        }
    }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (backgroundImage != null)
            {
                // 获取窗体的大小
                int width = this.ClientSize.Width;
                int height = this.ClientSize.Height;

                // 在窗体上绘制背景图片，并使其填充整个窗体
                e.Graphics.DrawImage(backgroundImage, 0, 0, width, height);
            }

            // 绘制每个 ImageItem 的图片
            foreach (var item in imageItems)
            {
                e.Graphics.DrawImage(item.Image, item.Rect);
            }
        }

        private void RaceDataInputForm_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var item in imageItems)
            {
                // 检查鼠标点击位置是否在图片的区域内
                if (item.Rect.Contains(e.Location) && !item.IsFormOpen)
                {
                    item.IsFormOpen = true; // 标记为已打开
                    // 创建并显示目标窗体
                    Form form = (Form)Activator.CreateInstance(item.FormType);
                    form.FormClosed += (s, args) => item.IsFormOpen = false; // 窗体关闭时重置标记
                    form.Show();
                }
            }
        }
    }
}
