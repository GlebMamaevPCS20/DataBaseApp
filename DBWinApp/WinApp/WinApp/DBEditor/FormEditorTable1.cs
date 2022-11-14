using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBaseLib;

namespace WinAPI.DBEditor
{
    public partial class FormEditorTable1 : Form
    {
        public FormEditorTable1()
        {
            InitializeComponent();
        }
        string _tableName = "Информация о клиенте";

        private void Table1_Load(object sender, EventArgs e)
        {
            DataBaseCommadsManager manager = new DataBaseCommadsManager();
            dataGridView1.DataSource = manager.GetDataTable(_tableName);
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            string[] args = new string[4];
            args[0] = textBox2.Text;
            args[1] = textBox3.Text;
            args[2] = textBox4.Text;
            //args[3] = textBox5.Text;
            

            DataBaseCommadsManager manager = new DataBaseCommadsManager();
            manager.Insert(args, _tableName);
            manager.GetDataTable(_tableName);
            dataGridView1.DataSource = manager.GetDataTable(_tableName);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            
            int currentRow = dataGridView1.CurrentCell.RowIndex;
            string[] args = new string[1];
            args[0] = dataGridView1[0, currentRow].Value.ToString();
            
            DataBaseCommadsManager manager = new DataBaseCommadsManager();
            manager.Delete(args, _tableName);
            dataGridView1.DataSource = manager.GetDataTable(_tableName);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int currentRow = dataGridView1.CurrentCell.RowIndex;
            string[] args = new string[4];
            args[0] = dataGridView1[0, currentRow].Value.ToString();
            args[1] = textBox2.Text;
            args[2] = textBox3.Text;
            args[3] = textBox4.Text;
            button1.Enabled = true;
            button2.Enabled = true;
            DataBaseCommadsManager manager = new DataBaseCommadsManager();
            manager.Update(args, _tableName);
            dataGridView1.DataSource = manager.GetDataTable(_tableName);

        }
        private void button3_Click(object sender, EventArgs e)
        {
            int currentRow = dataGridView1.CurrentCell.RowIndex;
            if (button3.Text == "Режим редактирования")
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Text = "Выйти из режима редактирования";
                textBox1.Text = dataGridView1[0, currentRow].Value.ToString();
                textBox2.Text = dataGridView1[1, currentRow].Value.ToString();
                textBox3.Text = dataGridView1[2, currentRow].Value.ToString();
                textBox4.Text = dataGridView1[3, currentRow].Value.ToString();

            }
                
            else
            {
                button3.Text = "Режим редактирования";
                button1.Enabled = true;
                button2.Enabled = true;
            }
              
        }

       
    }
}
