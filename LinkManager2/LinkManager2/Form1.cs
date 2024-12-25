using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System;

namespace LinkManager2

{
    public partial class Form1 : Form

    {
        private List<string> links = new List<string>();
        private const string filePath = "links.txt"; 

        public Form1()

        {

            InitializeComponent();
            LoadLinks(); 

        }


        private void LoadLinks()

        {
            if (File.Exists(filePath)) 

            {

                links = new List<string>(File.ReadAllLines(filePath)); 
                listBoxLinks.Items.AddRange(links.ToArray()); 

            }
        }


        private void SaveLinks()

        {

            File.WriteAllLines(filePath, links); 

        }


        private void btnAdd_Click_1(object sender, EventArgs e)

        {

            string link = txtLink.Text;

            if (!string.IsNullOrWhiteSpace(link))

            {

                links.Add(link); 
                listBoxLinks.Items.Add(link); 
                txtLink.Clear(); 
                MessageBox.Show("Ссылка добавлена."); 
                SaveLinks(); 

            }

            else

            {

                MessageBox.Show("Введите правильную ссылку."); 

            }

        }


        private void btnOpen_Click_1(object sender, EventArgs e)

        {
            if (listBoxLinks.SelectedItem != null) 

            {
                string selectedLink = listBoxLinks.SelectedItem.ToString(); 

                Process.Start(new ProcessStartInfo 

                {

                    FileName = selectedLink,
                    UseShellExecute = true

                });


                MessageBox.Show("Переход по ссылке...");

            }

            else

            {

                MessageBox.Show("Выберите ссылку для открытия."); 

            }

        }


        private void btnDelete_Click_1(object sender, EventArgs e)

        {
            if (listBoxLinks.SelectedItem != null) 

            {

                string selectedLink = listBoxLinks.SelectedItem.ToString();
                links.Remove(selectedLink); 
                listBoxLinks.Items.Remove(selectedLink); 
                MessageBox.Show("Ссылка удалена."); 
                SaveLinks(); 

            }

            else

            {

                MessageBox.Show("Выберите ссылку для удаления."); 

            }

        }

    }

}






