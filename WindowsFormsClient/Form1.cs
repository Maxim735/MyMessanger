using MyMessanger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft;

namespace WindowsFormsClient
{
    public partial class Form1 : Form
    {
        private static int MessageID = 0;
        private static string UserName;
        private static MessangerClientAPI API = new MessangerClientAPI();
        public Form1()
        {
            InitializeComponent();
        }

        private void Messages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string UserName = UsernameTB.Text;
            string Message = MessageTB.Text;
            if(UserName.Length > 1)
            {
                MyMessanger.Message msg = new MyMessanger.Message(UserName, Message, DateTime.Now);
                API.SendMessage(msg);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var getMessage = new Func<Task>(async () =>
            {
                MyMessanger.Message msg = await API.GetMessageHTTPAsync(MessageID);
                while (msg != null)
                {
                    MessagesLB.Items.Add(msg);
                    MessageID++;
                    msg = await API.GetMessageHTTPAsync(MessageID);
                }
            });
            getMessage.Invoke();
        }
    }
}
