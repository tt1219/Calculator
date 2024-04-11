using log4net;
using log4net.Repository.Hierarchy;
using Microsoft.VisualBasic.Logging;
using System;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // �R���\�[����\�����邽�߂̖��@
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        // �萔
        // �ő吸�x
        private readonly int MAX_PRECISION = 5;
        //
        private readonly string Dot = ".";

        // �ϐ�
        // �����t���O
        private bool IsFirst = true;
        // �h�b�g�����\�t���O
        private bool CanDot = true;
        // �O�񉟉����ꂽ�I�y���[�^�[
        private string PreOperator = string.Empty;
        // �O�񉟉���̌v�Z����
        private decimal PreResult = 0;


        public Form1()
        {
            InitializeComponent();
#if DEBUG
            // �R���\�[����\��
            AllocConsole();
#endif
            InfoLogger("�N�����܂����B");

        }

        /// <summary>
        /// �f�o�b�O���R���\�[���A�����[�X�r���h���e�L�X�g�t�@�C��
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
        /// �����t���O��true�̏ꍇ�A����������
        /// ���l�ƃh�b�g�������͎��̌v�Z���n�܂�̂ŁA��PGM�𗘗p
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
        /// ���l�{�^������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberButton_Click(object sender, EventArgs e)
        {
            var num = ((Button)sender).Text;
            InfoLogger(num);

            // �������́A�t���O�Ə������ʂ�����������
            VariableInitialize();

            if (Label_Input.Text.Equals("0"))
            {
                Label_Input.Text = num;
            }
            else
            {
                // �h�b�g���������h�b�g������5���܂ł͒ǉ�����
                if (CanDot || (!CanDot && Label_Input.Text.Substring(Label_Input.Text.IndexOf(Dot)).Length <= MAX_PRECISION))
                {
                    Label_Input.Text += num;
                }
            }


        }

        /// <summary>
        /// �h�b�g�{�^������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DotButton_Click(object sender, EventArgs e)
        {
            InfoLogger(".(�h�b�g)");
            // �������́A�t���O�Ə������ʂ�����������
            VariableInitialize();

            if (CanDot)
            {
                Label_Input.Text += Dot;
                CanDot = false;
            }
        }

        /// <summary>
        /// �l�����Z�A=�̃{�^�������̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperationButton_Click(object sender, EventArgs e)
        {
            var ope = ((Button)sender).Text;
            InfoLogger(ope);

            // �������́A�t���O�Ə������ʂ�����������
            if (IsFirst)
            {
                IsFirst = false;
                Label_Process.Text = string.Empty;
                PreOperator = string.Empty;
            }

            // 0���͕s��
            if (Label_Input.Text.Equals("0") && ope.Equals("��"))
                return;

            if (!string.IsNullOrEmpty(PreOperator))
            {
                if (PreOperator.Equals("+"))
                {
                    // �����Z
                    PreResult = PreResult + decimal.Parse(Label_Input.Text);
                }
                else if (PreOperator.Equals("-"))
                {
                    // �����Z
                    PreResult = PreResult - decimal.Parse(Label_Input.Text);
                }
                else if (PreOperator.Equals("�~"))
                {
                    // �|���Z
                    PreResult = PreResult * decimal.Parse(Label_Input.Text);
                }
                else if (PreOperator.Equals("��"))
                {
                    // ����Z
                    PreResult = PreResult / decimal.Parse(Label_Input.Text);
                }
                // �v�Z���ʂ̋��ʂ܂�ߏ���
                PreResult = RoundByMaxPrecision(PreResult);
                if (PreResult == 0)
                    CanDot = true;

            }
            else
            {
                PreResult = decimal.Parse(Label_Input.Text);
            }

            // �I�y���[�^���X�V
            PreOperator = ope;
            if (ope.Equals("="))
            {
                // = �������͏���������
                IsFirst = true;
                // �����r���\���ɒl�ݒ�
                Label_Process.Text += " " + Label_Input.Text.ToString() + " " + PreOperator.ToString();
                // �\���͒l��0��
                Label_Input.Text = PreResult.ToString();
            }
            else
            {
                // �\���͒l��0��
                Label_Input.Text = "0";
                // �����r���\���ɒl�ݒ�
                Label_Process.Text = PreResult.ToString() + " " + PreOperator.ToString();
            }

            // �h�b�g�͉����\��
            CanDot = true;

        }

        /// <summary>
        /// CE����������
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
        /// C����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, EventArgs e)
        {
            InfoLogger("C");
            VariableInitialize();
        }

        /// <summary>
        /// �}����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlusMinus_Click(object sender, EventArgs e)
        {
            InfoLogger("�}");

            // �������́A�t���O�Ə������ʂ�����������
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
        /// %������
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
        /// �w��̍ő包�Ɏl�̌ܓ�
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private decimal RoundByMaxPrecision(decimal value) => Math.Round(value, MAX_PRECISION, MidpointRounding.AwayFromZero);
    }
}
