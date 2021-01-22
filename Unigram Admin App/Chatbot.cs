using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using AIMLbot;
//using System.Speech;
//using System.Speech.Synthesis;

namespace Unigram_Admin_App
{
    public partial class Chatbot : Form
    {
        public Chatbot()
        {
            InitializeComponent();
        }

        private void radChat1_Click(object sender, EventArgs e)
        {          

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            InputBox.Init("Nhập chữ tại đây...");
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            //GetBotResponse();
            Bot AI = new Bot();
            AI.loadSettings(); //It will Load Settings from its Config Folder with this code
            AI.loadAIMLFromFiles(); //With this Code It Will Load AIML Files from its AIML Folder
            AI.isAcceptingUserInput = false; //With this Code it will Disable UserInput For Now
            User myuser = new User("Tên người dùng tại đây", AI); //With This Code We Will Add The User Through AI/Bot
            AI.isAcceptingUserInput = true; //Now The User Input is Enabled Again with this Code
            Request r = new Request(InputBox.Text, myuser, AI); //With This Code it will Request The Response From AIML Folders
            Result res = AI.Chat(r); //With This Code It Will Get Result
            OutputBox.Text = "Người máy Unigram: " + res.Output; //With this Code It Will Write the Result of Textbox1 Response to Textbox2 text
            //Now Coding Is Finished!
            //Now Add/Copy & Paste AIML Folder & Config Folder to the Project Directory
            //Now Test the Bot
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Bot AI = new Bot();
                AI.loadSettings(); //It will Load Settings from its Config Folder with this code
                AI.loadAIMLFromFiles(); //With this Code It Will Load AIML Files from its AIML Folder
                AI.isAcceptingUserInput = false; //With this Code it will Disable UserInput For Now
                User myuser = new User("Tên người dùng tại đây", AI); //With This Code We Will Add The User Through AI/Bot
                AI.isAcceptingUserInput = true; //Now The User Input is Enabled Again with this Code
                Request r = new Request(InputBox.Text, myuser, AI); //With This Code it will Request The Response From AIML Folders
                Result res = AI.Chat(r); //With This Code It Will Get Result
                OutputBox.Text = "Người máy Unigram: " + res.Output; //With this Code It Will Write the Result of Textbox1 Response to Textbox2 text
                                                                //Now Coding Is Finished!
                                                                //Now Add/Copy & Paste AIML Folder & Config Folder to the Project Directory
                                                                //Now Test the Bot
                e.Handled = e.SuppressKeyPress = true; //This Code for Disabling Beep Sound On Enter Key
            }
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void OutputBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
