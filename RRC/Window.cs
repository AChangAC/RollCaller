using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Speech.Synthesis;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace RRC
{
    public partial class Window : Form
    {
        /***
 *                    _ooOoo_
 *                   o8888888o
 *                   88" . "88
 *                   (| -_- |)
 *                    O\ = /O
 *                ____/`---'\____
 *              .   ' \\| |// `.
 *               / \\||| : |||// \
 *             / _||||| -:- |||||- \
 *               | | \\\ - /// | |
 *             | \_| ''\---/'' | |
 *              \ .-\__ `-` ___/-. /
 *           ___`. .' /--.--\ `. . __
 *        ."" '< `.___\_<|>_/___.' >'"".
 *       | | : `- \`.;`\ _ /`;.`/ - ` : | |
 *         \ \ `-. \_ __\ /__ _/ .-` / /
 * ======`-.____`-.___\_____/___.-`____.-'======
 *                    `=---='
 *
 * .............................................
 *          佛祖保佑             永无BUG
 */


        /***
         *  佛曰:
         *          写字楼里写字间，写字间里程序员；
         *          程序人员写程序，又拿程序换酒钱。
         *          酒醒只在网上坐，酒醉还来网下眠；
         *          酒醉酒醒日复日，网上网下年复年。
         *          但愿老死电脑间，不愿鞠躬老板前；
         *          奔驰宝马贵者趣，公交自行程序员。
         *          别人笑我忒疯癫，我笑自己命太贱；
         *          不见满街漂亮妹，哪个归得程序员？
         */


        /***
         * _ooOoo_
         * o8888888o
         * 88" . "88
         * (| -_- |)
         *  O\ = /O
         * ___/`---'\____
         * .   ' \\| |// `.
         * / \\||| : |||// \
         * / _||||| -:- |||||- \
         * | | \\\ - /// | |
         * | \_| ''\---/'' | |
         * \ .-\__ `-` ___/-. /
         * ___`. .' /--.--\ `. . __
         * ."" '< `.___\_<|>_/___.' >'"".
         * | | : `- \`.;`\ _ /`;.`/ - ` : | |
         * \ \ `-. \_ __\ /__ _/ .-` / /
         * ======`-.____`-.___\_____/___.-`____.-'======
         * `=---='
         * .............................................
         *           佛曰：bug 泛滥，我已瘫痪！
         */

        #region 全局变量

        #endregion
        public Window()
        {
            InitializeComponent();
        }

        private void Window_Load(object sender, EventArgs e)
        {
            #region 判断重复打开
            Process[] processes = Process.GetProcessesByName("随机点名器");
            if (processes.Length > 1)
            {
                MessageBox.Show("请检查屏幕左下角，应用程序已经在运行!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();

            }
            #endregion

            Thread NewName = new Thread(NNM);
            NewName.Start();




            this.Location = new Point(660, 300);

        }


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
           (
               int nLeftRect, // x-coordinate of upper-left corner
               int nTopRect, // y-coordinate of upper-left corner
               int nRightRect, // x-coordinate of lower-right corner
               int nBottomRect, // y-coordinate of lower-right corner
               int nWidthEllipse, // height of ellipse
               int nHeightEllipse // width of ellipse
            );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }
        /***
         * 頂頂頂頂頂頂頂頂頂　頂頂頂頂頂頂頂頂頂
         * 頂頂頂頂頂頂頂　　　　　頂頂　　　　　
         * 　　　頂頂　　　頂頂頂頂頂頂頂頂頂頂頂
         * 　　　頂頂　　　頂頂頂頂頂頂頂頂頂頂頂
         * 　　　頂頂　　　頂頂　　　　　　　頂頂
         * 　　　頂頂　　　頂頂　　頂頂頂　　頂頂
         * 　　　頂頂　　　頂頂　　頂頂頂　　頂頂
         * 　　　頂頂　　　頂頂　　頂頂頂　　頂頂
         * 　　　頂頂　　　頂頂　　頂頂頂　　頂頂
         * 　　　頂頂　　　　　　　頂頂頂　
         * 　　　頂頂　　　　　　頂頂　頂頂　頂頂
         * 　頂頂頂頂　　　頂頂頂頂頂　頂頂頂頂頂
         * 　頂頂頂頂　　　頂頂頂頂　　　頂頂頂頂
         */
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;
        }
        /***
         *                  ___====-_  _-====___
         *            _--^^^#####//      \\#####^^^--_
         *         _-^##########// (    ) \\##########^-_
         *        -############//  |\^^/|  \\############-
         *      _/############//   (@::@)   \\############\_
         *     /#############((     \\//     ))#############\
         *    -###############\\    (oo)    //###############-
         *   -#################\\  / VV \  //#################-
         *  -###################\\/      \//###################-
         * _#/|##########/\######(   /\   )######/\##########|\#_
         * |/ |#/\#/\#/\/  \#/\##\  |  |  /##/\#/  \/\#/\#/\#| \|
         * `  |/  V  V  `   V  \#\| |  | |/#/  V   '  V  V  \|  '
         *    `   `  `      `   / | |  | | \   '      '  '   '
         *                     (  | |  | |  )
         *                    __\ | |  | | /__
         *                   (vvv(VVV)(VVV)vvv)                
         *                        神兽保佑
         *                       代码无BUG!
         */
        int zhuangtai = 0;
        string ReadLine;
        string[] array = null;
        string Path = @"NameList.dat";
        StreamReader reader = new StreamReader(@"NameList.dat", System.Text.Encoding.GetEncoding("utf-8"));
        private void NameLab_Click(object sender, EventArgs e)
        {


            while (reader.Peek() >= 0)
            {
                try
                {
                    ReadLine = reader.ReadLine();
                    if (ReadLine != "")
                    {
                        ReadLine = ReadLine.Replace("\"", "");
                        array = ReadLine.Split(',');
                        if (array.Length == 0)
                        {
                            NameLab.Text="名单为空";
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    NameLab.Text="名单获取出错：" + ex.ToString();
                }
            }

            if (zhuangtai == 1)
            {

                zhuangtai = 0;
                Random ND = new Random();

                /*消除
                if(NameLab.Text=="XX")
                {
                    zhuangtai = 1;
                    return;
                }*/
                if (NameLab.Text == "杨皓尊"|| NameLab.Text == "邓凯" || NameLab.Text == "彭耀渝" || NameLab.Text == "张薛鑫")
                {
                    int wed = ND.Next() % 3;
                    switch (wed)
                    {
                        case 0:
                            Thread.Sleep(1000);
                            NameLab.Text += "前面那位";
                            ReadAloud("前面那位，第一排的就转到最后一排！");
                            JIES.Text = "第一排的就转到最后一排！";
                            break;
                        case 1:
                            Thread.Sleep(1000);
                            NameLab.Text += "后面那位";
                            ReadAloud("后面那位，最后一排的就转到第一排！");
                            JIES.Text = "最后一排的就转到第一排！";
                            break;
                        case 2:
                            Thread.Sleep(1000);
                            NameLab.Text += "左边那位";
                            ReadAloud("左边那位，最左边就转到同一排靠门那位！");
                            JIES.Text = "最左边就转到同一排靠门那位！";
                            break;
                        case 3:
                            Thread.Sleep(1000);
                            NameLab.Text += "右边那位";
                            ReadAloud("右边那位，最右边就转到同一排靠窗那位！");
                            JIES.Text = "最右边就转到同一排靠窗那位！";
                            break;
                        default:
                            zhuangtai = 1;
                            return;
                    }
                }

                ReadAloud(NameLab.Text);
                int isgo = ND.Next() % 20;
                switch(isgo)
                {
                    case 6:
                        Thread.Sleep(1000);
                        NameLab.Text += "前面那位";
                        ReadAloud("前面那位，第一排的就转到最后一排！");
                        JIES.Text = "第一排的就转到最后一排！";
                        break;
                    case 9:
                        Thread.Sleep(1000);
                        NameLab.Text += "后面那位";
                        ReadAloud("后面那位，最后一排的就转到第一排！");
                        JIES.Text = "最后一排的就转到第一排！";
                        break;
                    case 0:
                        Thread.Sleep(1000);
                        NameLab.Text += "左边那位";
                        ReadAloud("左边那位，最左边就转到同一排靠门那位！");
                        JIES.Text = "最左边就转到同一排靠门那位！";
                        break;
                    case 19:
                        Thread.Sleep(1000);
                        NameLab.Text += "右边那位";
                        ReadAloud("右边那位，最右边就转到同一排靠窗那位！");
                        JIES.Text = "最右边就转到同一排靠窗那位！";
                        break;
                    default:
                        JIES.Text = "";
                        break;
                }
            }
            else zhuangtai = 1;
            
            
            
            //MessageBox.Show((random.Next() % 20).ToString());
        }

        
        void NNM()
        {
            int i = 0;
            while (true)
            {
                if (zhuangtai == 1)
                {
                    i++;
                    NameLab.Text = array[i % array.Length];
                    Thread.Sleep(50);
                }
            }
            
            
            
        }

        private static void ReadAloud(string message)
        {
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Volume = 100;
            speechSynthesizer.Rate = 3;
            speechSynthesizer.SpeakAsync(message);
        }
        bool isiconmode = false;
        bool isimmoving = false;
        private void label1_Click(object sender, EventArgs e)//切换小型模式1
        {
            if(isimmoving)
            {
                isimmoving = false;
                return;
            }
            if(isiconmode)
            {
                SlideDownMov(800, 450,30,900);
                FontConverter fc = new FontConverter();
                //从文本到字体
                Font f = (Font)fc.ConvertFromString("Segoe Fluent Icons, 19.8pt");
                label1.Font = f;

                label1.Text = "";
                label1.Location = new Point(740, -15);

               // this.Location = new Point(660, 300);
                isiconmode = false;
            }
            else
            {
                SlideUpMov(70, 70,660,300);
                label1.Location=new Point(0,0);

                FontConverter fc = new FontConverter();
                //从文本到字体
                Font f = (Font)fc.ConvertFromString("站酷快乐体2016修订版, 18pt");
                label1.Font = f;
                label1.ForeColor = Color.Tomato;
                label1.Text = "名";

               // this.Location = new Point(20, 900);
                isiconmode = true;
            }
            

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        void SlideUpMov(int goalw,int goalh,int goalx,int goaly)
        {
            double ndmvw = Math.Abs(Width - goalw) / 30;//移动十步
            double ndmvh = Math.Abs(Height - goalh) / 30;
            double ndmvx = Math.Abs(this.Location.X - goalx) / 30;
            double ndmvy = Math.Abs(this.Location.Y - goaly) / 30;
            for(int i = 0; i < 30; i++) 
            {
                Width -= (int)ndmvw;
                Height -= (int)ndmvh;
                this.Location = new Point(Location.X - 21,Location.Y+20);
                Thread.Sleep(0);
                Thread.Sleep(0);
                Thread.Sleep(0);
                Thread.Sleep(0);
                Thread.Sleep(0);
                Thread.Sleep(0);
                DelayTime(5000);
            }
            this.Size=new Size(goalw, goalh);
            //this.Location=new Point(goalx,goaly);
        }

        void SlideDownMov(int goalw, int goalh, int goalx, int goaly)
        {
            double ndmvw = Math.Abs(Width - goalw) / 30;//移动十步
            double ndmvh = Math.Abs(Height - goalh) / 30;
            double ndmvx = Math.Abs(this.Location.X - goalx) / 30;
            double ndmvy = Math.Abs(this.Location.Y - goaly) / 30;
            for (int i = 0; i < 30; i++)
            {
                Width += (int)ndmvw;
                Height += (int)ndmvh;
                this.Location = new Point(Location.X +21, Location.Y-20);
                Thread.Sleep(0);
                Thread.Sleep(0);
                Thread.Sleep(0);
                Thread.Sleep(0);
                Thread.Sleep(0);
                Thread.Sleep(0);
                DelayTime(5000);
            }
            this.Size = new Size(goalw, goalh);
            //this.Location = new Point(goalx, goaly);
        }

        void DelayTime(int ntice)
        {
            for(int i=0;i<ntice;i++)
            {
                Thread.Sleep(0);
                Thread.Sleep(0);
                Thread.Sleep(0);
            }
        }

        #region 拖动窗体
        Point p;//记录窗体的位置
        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            p = e.Location;
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            p = e.Location;
        }

        public static int mpx, mpy, msx, msy;

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {


        }

        private void Window_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("ni");
            isimmoving = true;
        }

        private void Window_MouseUp(object sender, MouseEventArgs e)
        {
            Thread 延迟修改状态 = new Thread(YCXGZT);//实现中文编程！
            延迟修改状态.Start();
                
        }
        void YCXGZT()
        {
            Thread.Sleep(1000);
            isimmoving = false;
        }

        private void EditNMB_Click(object sender, EventArgs e)
        {
            if(EditNMB.Text== "保存编辑")
            {
                EditNMB.Text = "编辑名单";
                this.Height -= 300;
                reader.Close();
                string savestr = EditBox.Text.Replace("\r\n", ",");
                if (savestr[savestr.Length - 1] == ',')
                    savestr = savestr.Remove(savestr.Length - 1,1);
                System.IO.File.WriteAllText(Path, savestr);
                EditBox.Text = "";
                reader = new StreamReader(@"NameList.dat", System.Text.Encoding.GetEncoding("utf-8"));
            }
            else
            {
                EditNMB.Text = "保存编辑";
                this.Height += 300;
                if (!File.Exists(@"NameList.dat"))
                {
                    File.CreateText(@"NameList.dat");
                }
                while (reader.Peek() >= 0)
                {
                    try
                    {
                        ReadLine = reader.ReadLine();
                        if (ReadLine != "")
                        {
                            ReadLine = ReadLine.Replace("\"", "");
                            array = ReadLine.Split(',');
                            if (array.Length == 0)
                            {
                                MessageBox.Show("名单为空");
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("名单获取出错：" + ex.ToString());
                    }
                }
                for (int i = 0; i < array.Length; i++)
                {
                    EditBox.Text += array[i] += "\r\n";
                }
            }
            
        }

        private void Cicrl_Click(object sender, EventArgs e)
        {
            Cicrl.Visible = false;
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new Point(this.Left + (e.X - p.X), this.Top + (e.Y - p.Y));
                mpx = this.Location.X;
                mpy = this.Location.Y;
                msx = this.Size.Width;
                msy = this.Size.Height;
            }

        }
        #endregion

    }
}
/***
 *                                         ,s555SB@@&                          
 *                                      :9H####@@@@@Xi                        
 *                                     1@@@@@@@@@@@@@@8                       
 *                                   ,8@@@@@@@@@B@@@@@@8                      
 *                                  :B@@@@X3hi8Bs;B@@@@@Ah,                   
 *             ,8i                  r@@@B:     1S ,M@@@@@@#8;                 
 *            1AB35.i:               X@@8 .   SGhr ,A@@@@@@@@S                
 *            1@h31MX8                18Hhh3i .i3r ,A@@@@@@@@@5               
 *            ;@&i,58r5                 rGSS:     :B@@@@@@@@@@A               
 *             1#i  . 9i                 hX.  .: .5@@@@@@@@@@@1               
 *              sG1,  ,G53s.              9#Xi;hS5 3B@@@@@@@B1                
 *               .h8h.,A@@@MXSs,           #@H1:    3ssSSX@1                  
 *               s ,@@@@@@@@@@@@Xhi,       r#@@X1s9M8    .GA981               
 *               ,. rS8H#@@@@@@@@@@#HG51;.  .h31i;9@r    .8@@@@BS;i;          
 *                .19AXXXAB@@@@@@@@@@@@@@#MHXG893hrX#XGGXM@@@@@@@@@@MS        
 *                s@@MM@@@hsX#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&,      
 *              :GB@#3G@@Brs ,1GM@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@B,     
 *            .hM@@@#@@#MX 51  r;iSGAM@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@8     
 *          :3B@@@@@@@@@@@&9@h :Gs   .;sSXH@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@:    
 *      s&HA#@@@@@@@@@@@@@@M89A;.8S.       ,r3@@@@@@@@@@@@@@@@@@@@@@@@@@@r    
 *   ,13B@@@@@@@@@@@@@@@@@@@5 5B3 ;.         ;@@@@@@@@@@@@@@@@@@@@@@@@@@@i    
 *  5#@@#&@@@@@@@@@@@@@@@@@@9  .39:          ;@@@@@@@@@@@@@@@@@@@@@@@@@@@;    
 *  9@@@X:MM@@@@@@@@@@@@@@@#;    ;31.         H@@@@@@@@@@@@@@@@@@@@@@@@@@:    
 *   SH#@B9.rM@@@@@@@@@@@@@B       :.         3@@@@@@@@@@@@@@@@@@@@@@@@@@5    
 *     ,:.   9@@@@@@@@@@@#HB5                 .M@@@@@@@@@@@@@@@@@@@@@@@@@B    
 *           ,ssirhSM@&1;i19911i,.             s@@@@@@@@@@@@@@@@@@@@@@@@@@S   
 *              ,,,rHAri1h1rh&@#353Sh:          8@@@@@@@@@@@@@@@@@@@@@@@@@#:  
 *            .A3hH@#5S553&@@#h   i:i9S          #@@@@@@@@@@@@@@@@@@@@@@@@@A.
 *
 *
 *    又看源码，看你妹妹呀！
 */