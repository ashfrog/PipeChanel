using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PipeClientDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pipeclient = new PipeChanel.Pipechanel(2, "PipeClientDemo", "PipeServerDemo");
            PipeChanel.Pipechanel.msgReceived+=new PipeChanel.PipeMsg.PipeMsgEventHandler(Pipechanel_msgReceived);
        }
        private void Pipechanel_msgReceived(object sender, PipeChanel.PipeMsg.PipeMsgEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.listBox1.Items.Add(e.receivedMsg);
            }));
        }
        PipeChanel.Pipechanel pipeclient;
        private void button1_Click(object sender, EventArgs e)
        {
            pipeclient.Send(this.textBox1.Text);
        }
    }
}
