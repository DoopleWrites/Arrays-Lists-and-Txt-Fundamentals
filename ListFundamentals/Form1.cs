using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ListFundamentals
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //Check if textbox is empty
            if (firstNameText.Text == "" || lastNameText.Text == "")
            {
                errorLabel.Text = ("Please enter a valid first/last name.");
                return;
            }

            //Assign textboxes to variables and make them all lowercase
            string firstName;
            string lastName;
            string firstName1;
            string lastName1;

            firstName = firstNameText.Text;
            lastName = lastNameText.Text;
            firstName1 = firstName.ToLower();
            lastName1 = lastName.ToLower();

            //Read the text file
            string[] nameFile = File.ReadAllLines(@"C:\Users\Admin\source\repos\ListFundamentals\ListFundamentals\Names.txt");

            //Convert array to string
            List<string> newNameFile = new List<string>();
            int counter = nameFile.Length;
            int i = 0;
            while (i < counter)
            {
                string line = nameFile[i];
                newNameFile.Add(line);
                i++;
            }

            //Add new name to string
            string newName = (firstName1 + "," + lastName1);
            newNameFile.Add(newName);

            //Convert string back to Array
            string[] writeNameFile = newNameFile.ToArray();

            //Write array back to text file
            File.WriteAllLines(@"C:\Users\Admin\source\repos\ListFundamentals\ListFundamentals\Names.txt", writeNameFile);

            errorLabel.Text = (firstName + " " + lastName + " added successfully.");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (firstNameText.Text == "" || lastNameText.Text == "")
            {
                errorLabel.Text = ("Please enter a valid first/last name.");
                return;
            }

            //Assign textboxes to variables and make them all lowercase
            string firstName;
            string lastName;
            string firstName1;
            string lastName1;

            firstName = firstNameText.Text;
            lastName = lastNameText.Text;
            firstName1 = firstName.ToLower();
            lastName1 = lastName.ToLower();

            //Read the text file
            string[] nameFile = File.ReadAllLines(@"C:\Users\Admin\source\repos\ListFundamentals\ListFundamentals\Names.txt");

            //Convert array to list
            List<string> newNameFile = new List<string>();
            int counter = nameFile.Length;
            int i = 0;
            int removedCount = 0;

            //Write to list unless it's the name
            while (i < counter)
            {
                string line = nameFile[i];
                if (line == firstName1 + "," + lastName1)
                {
                    i++;
                    removedCount++;
                }
                else
                {
                    newNameFile.Add(line);
                    i++;
                }

                //Convert string back to Array
                string[] writeNameFile = newNameFile.ToArray();

                //Write array back to text file
                File.WriteAllLines(@"C:\Users\Admin\source\repos\ListFundamentals\ListFundamentals\Names.txt", writeNameFile);

                if (removedCount == 0)
                {
                    errorLabel.Text = "No names were removed.";
                }
                else
                { 
                    errorLabel.Text = (firstName + " " + lastName + " was removed successfully "+ Convert.ToString(removedCount) + " time/s");
                }

            }

        }

        private void searchButton_Click(object sender, EventArgs e)
        {

            string searchName;
            string searchName1;
            searchName = (searchText.Text);
            searchName1 = searchName.ToLower();

            string[] nameFile = File.ReadAllLines(@"C:\Users\Admin\source\repos\ListFundamentals\ListFundamentals\Names.txt");

            int count = nameFile.Length;
            int i = 0;
            int matches = 0;
            string output = "";
            while (i < count)
            {
                if (nameFile[i].Contains(searchName1))
                {
                    output = (output + searchName + " found on line: " + Convert.ToString(i));
                    output = output + "\n";
                    i++;
                    matches++;
                }
                else
                {
                    i++;
                }
            }
           
            if (matches == 0)
            {
                outputLabel.Text = ("No matches found for " + searchName);
            }
            else
            {
                outputLabel.Text = output;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
