using log4net;
using log4net.Repository.Hierarchy;
using Microsoft.VisualBasic.Logging;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public Form1()
        {
            InitializeComponent();
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
                Label_Input.Text += num;
            }


        }
    }
}
