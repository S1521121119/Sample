using System;
using System.Windows.Forms;

namespace UserDataBinding
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DataBindingEnvironment env = new DataBindingEnvironment();
            DataBindingService dataBindingService = new DataBindingService(this);

            GlobalVariable.UserData = new UserDataClass(env, dataBindingService);

            DataBindingTool.RegisterDataChangedEvent(GlobalVariable.UserData, TBName, TBData, TBCommand, TBStatus);

            Timer TmrUpdataUI = new Timer();

            TmrUpdataUI.Tick += dataBindingService.TimerTickedToUpdateUIControl;
            TmrUpdataUI.Interval = 1000;
            TmrUpdataUI.Start();
        }

        private void txt_UserInput_TextChanged(object sender, EventArgs e)
        {
            var input = ((TextBox)sender).Text;

            GlobalVariable.UserData.TBName = input;
            GlobalVariable.UserData.TBData = input.Length;
            GlobalVariable.UserData.TBCommand = input.ToUpper();
            GlobalVariable.UserData.TBStatus = string.IsNullOrEmpty(input);
        }
    }
}