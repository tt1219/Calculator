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
        private readonly string Dot = ".";

        // 変数
        // 初期フラグ
        private bool IsFirst = true;
        // ドット押下可能フラグ
        private bool CanDot = true;
        // 前回押下されたオペレーター
        private string PreOperator = string.Empty;
        // 前回押下後の計算結果
        private decimal PreResult = 0;


        public Form1()
        {
            InitializeComponent();
#if DEBUG
            // コンソールを表示
            AllocConsole();
#endif
            InfoLogger("起動しました。");

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
            logger.Info(msg);
#endif
        }

        /// <summary>
        /// 初期フラグがtrueの場合、初期化する
        /// 数値とドット押下時は次の計算が始まるので、当PGMを利用
        /// </summary>
        private void VariableInitialize()
        {
            if (IsFirst)
            {
                IsFirst = false;
                Label_Process.Text = string.Empty;
                Label_Input.Text = "0";
                PreResult = 0;
                PreOperator = string.Empty;
            }
        }

        /// <summary>
        /// 数値ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberButton_Click(object sender, EventArgs e)
        {
            var num = ((Button)sender).Text;
            InfoLogger(num);

            // 初期時は、フラグと処理結果を初期化する
            VariableInitialize();

            if (Label_Input.Text.Equals("0"))
            {
                Label_Input.Text = num;
            }
            else
            {
                // ドット未押下かドット押下後5桁までは追加する
                if (CanDot || (!CanDot && Label_Input.Text.Substring(Label_Input.Text.IndexOf(Dot)).Length <= MAX_PRECISION))
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
            InfoLogger(".(ドット)");
            // 初期時は、フラグと処理結果を初期化する
            VariableInitialize();

            if (CanDot)
            {
                Label_Input.Text += Dot;
                CanDot = false;
            }
        }

        /// <summary>
        /// 四則演算、=のボタン押下の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperationButton_Click(object sender, EventArgs e)
        {
            var ope = ((Button)sender).Text;
            InfoLogger(ope);

            // 初期時は、フラグと処理結果を初期化する
            if (IsFirst)
            {
                IsFirst = false;
                Label_Process.Text = string.Empty;
                PreOperator = string.Empty;
            }

            // 0割は不可
            if (Label_Input.Text.Equals("0") && ope.Equals("÷"))
                return;

            if (!string.IsNullOrEmpty(PreOperator))
            {
                if (PreOperator.Equals("+"))
                {
                    // 足し算
                    PreResult = PreResult + decimal.Parse(Label_Input.Text);
                }
                else if (PreOperator.Equals("-"))
                {
                    // 引き算
                    PreResult = PreResult - decimal.Parse(Label_Input.Text);
                }
                else if (PreOperator.Equals("×"))
                {
                    // 掛け算
                    PreResult = PreResult * decimal.Parse(Label_Input.Text);
                }
                else if (PreOperator.Equals("÷"))
                {
                    // 割り算
                    PreResult = PreResult / decimal.Parse(Label_Input.Text);
                }
                // 計算結果の共通まるめ処理
                PreResult = RoundByMaxPrecision(PreResult);
                if (PreResult == 0)
                    CanDot = true;

            }
            else
            {
                PreResult = decimal.Parse(Label_Input.Text);
            }

            // オペレータを更新
            PreOperator = ope;
            if (ope.Equals("="))
            {
                // = 押下時は初期化する
                IsFirst = true;
                // 処理途中表示に値設定
                Label_Process.Text += " " + Label_Input.Text.ToString() + " " + PreOperator.ToString();
                // 表入力値を0へ
                Label_Input.Text = PreResult.ToString();
            }
            else
            {
                // 表入力値を0へ
                Label_Input.Text = "0";
                // 処理途中表示に値設定
                Label_Process.Text = PreResult.ToString() + " " + PreOperator.ToString();
            }

            // ドットは押下可能に
            CanDot = true;

        }

        /// <summary>
        /// CE押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearEntry_Click(object sender, EventArgs e)
        {
            InfoLogger("CE");
            Label_Input.Text = "0";
            CanDot = true;
        }

        /// <summary>
        /// C押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, EventArgs e)
        {
            InfoLogger("C");
            VariableInitialize();
        }

        /// <summary>
        /// ±押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlusMinus_Click(object sender, EventArgs e)
        {
            InfoLogger("±");

            // 初期時は、フラグと処理結果を初期化する
            if (IsFirst)
            {
                IsFirst = false;
            }

            if (!Label_Input.Text.Equals("0"))
            {
                if (Label_Input.Text.Contains("-"))
                {
                    Label_Input.Text = Label_Input.Text.Replace("-", string.Empty);
                }
                else
                {
                    Label_Input.Text = "-" + Label_Input.Text;
                }
            }
        }

        /// <summary>
        /// %押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Percent_Click(object sender, EventArgs e)
        {
            InfoLogger("%");

            if (!Label_Input.Text.Equals("0"))
            {
                var percented = decimal.Parse(Label_Input.Text) / 100;
                var rouded = RoundByMaxPrecision(percented);
                if (rouded == 0)
                {
                    Label_Input.Text = "0";
                    CanDot = true;
                }
                else
                {
                    Label_Input.Text = RoundByMaxPrecision(percented).ToString();
                    if (Label_Input.Text.Contains('.'))
                        CanDot = false;
                }
            }
        }

        /// <summary>
        /// 指定の最大桁に四捨五入
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private decimal RoundByMaxPrecision(decimal value) => Math.Round(value, MAX_PRECISION, MidpointRounding.AwayFromZero);
    }
}
