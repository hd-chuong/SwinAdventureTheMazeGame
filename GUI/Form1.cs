using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaseStudy9
{    
    public partial class GUIForm : Form
    {
        private const string DEFAULT_DATA_FILE = "E:/Y1/OOP/W9/GameData.txt";
        GameData _gameData;
        CommandProcessor _commandProcessor;

        public GameData GameData { get => _gameData; set => _gameData = value; }
        public CommandProcessor CommandProcessor { get => _commandProcessor; set => _commandProcessor = value; }

        public GUIForm()
        {
            InitializeComponent();
            GameData = new GameData();
            CommandProcessor = new CommandProcessor();

        }

        private void New_Click(object sender, EventArgs e)
        {
            GameData.New();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            GameData.Load(DEFAULT_DATA_FILE);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            GameData.Save(DEFAULT_DATA_FILE);
        }

        private void Execute_button_Click(object sender, EventArgs e)
        {
            textBox2.Text = CommandProcessor.Execute(GameData.Player, textBox1.Text);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void GUIForm_Load(object sender, EventArgs e)
        {

        }
    }
}
