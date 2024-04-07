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
        private readonly string Dot = "";

        // �ϐ�
        // �h�b�g�����\�t���O
        private bool CanDot = true;


        public Form1()
        {
            InitializeComponent();
            // �R���\�[����\��
            AllocConsole();
            InfoLogger("�f�o�b�O���b�Z�[�W�ł��B");

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
            // TODO �Ȃ񂩃e�L�X�g�t�@�C�����o�Ȃ�
            logger.Info(msg);
#endif
        }

        /// <summary>
        /// ���l�{�^������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberButton_Click(object sender, EventArgs e)
        {
            var num = ((Button)sender).Text;
            InfoLogger("���l�����F" + num);
            if (Label_Input.Text.Equals("0"))
            {
                Label_Input.Text = num;
            }
            else
            {
                // �h�b�g���������h�b�g������5���܂ł͒ǉ�����
                if (CanDot || (!CanDot && Label_Input.Text.Substring(Label_Input.Text.IndexOf(Dot)).Length < MAX_PRECISION))
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
            if (CanDot)
            {
                Label_Input.Text += Dot;
                CanDot = false;
            }
        }
    }
}
