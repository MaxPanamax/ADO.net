using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lis_6_end_HW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "Book"|| textBox1.Text == "Author"|| textBox1.Text == "Publisher")
            {      
            if(textBox1.Text=="Book")
            {
                 using (Lirary2Entities db = new Lirary2Entities())
                 {

                         var bk = (from c in db.Book
                          select new
                          {
                              Id = c.Id,
                              Title=c.Title,
                              IdAuthor=c.IdAuthor,
                              Pages=c.Pages,
                              Price=c.Price,
                              IdPublisher=c.IdPublisher,
                          }).ToList();
                         dataGridView1.DataSource = null;
                         dataGridView1.DataSource = bk;
                 }
            }
            if(textBox1.Text=="Author")
            {
                using (Lirary2Entities db = new Lirary2Entities())
                {

                    var bk = (from c in db.Author
                              select new
                              {
                                  Id = c.Id,
                                  FirstName = c.FirstName,
                                  LastName = c.LastName
                              }).ToList();
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = bk;
                }
            }
            if(textBox1.Text=="Publisher")
            {
                using (Lirary2Entities db = new Lirary2Entities())
                {

                    var bk = (from c in db.Publisher
                              select new
                              {
                                  Id = c.Id,
                                  PublisherName=c.PublisherName,
                                  Address=c.Address,
                              }).ToList();
                    dataGridView3.DataSource = null;
                    dataGridView3.DataSource = bk;
                }
            }
            }
            else
            {
                MessageBox.Show("Неправильное имя таблицы");
            }

            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                dataGridView4.DataSource = null;
                dataGridView4.DataSource = dataGridView1.DataSource;
            }
            if(tabControl1.SelectedIndex == 1)
            {
                dataGridView4.DataSource = null;
                dataGridView4.DataSource = dataGridView2.DataSource;
            }
            if(tabControl1.SelectedIndex==2)
            {
                dataGridView4.DataSource = null;
                dataGridView4.DataSource = dataGridView3.DataSource;
            } 
        }
    }
}
