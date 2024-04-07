using log4net;
using log4net.Repository.Hierarchy;
using Microsoft.VisualBasic.Logging;
using System;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        // コンソールを表示するための魔法
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        // 定数
        // 最大精度
        private readonly int MAX_PRECISION = 5;
        //
        private readonly string Dot = "";

        // 変数
        // ドット押下可能フラグ
        private bool CanDot = true;


        public Form1()
        {
            InitializeComponent();
            // コンソールを表示
            AllocConsole();
            InfoLogger("デバッグメッセージです。");

        }

        /// <summary>
        /// デバッグ時コンソール、リリースビルド時テキストファイル
        /// </summary>
        /// <param name="msg"></param>
        private void InfoLogger(string msg)
        {
#if DEBUG
            Console.WriteLine(msg);
#else
            // TODO なんかテキストファイルが出ない
            logger.Info(msg);
#endif
        }

        /// <summary>
        /// 数値ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberButton_Click(object sender, EventArgs e)
        {
            var num = ((Button)sender).Text;
            InfoLogger("数値押下：" + num);
            if (Label_Input.Text.Equals("0"))
            {
                Label_Input.Text = num;
            }
            else
            {
                // ドット未押下かドット押下後5桁までは追加する
                if (CanDot || (!CanDot && Label_Input.Text.Substring(Label_Input.Text.IndexOf(Dot)).Length < MAX_PRECISION))
                {
                    Label_Input.Text += num;
                }
            }


        }

        /// <summary>
        /// ドットボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DotButton_Click(object sender, EventArgs e)
        {
            if (CanDot)
            {
                Label_Input.Text += Dot;
                CanDot = false;
            }
        }
    }
}
