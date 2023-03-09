using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeSimulatorGame
{
    public partial class Form1 : Form
    {
        int Money = 0;
        int Networth = 100;
        int Age = 18;
        int IQ = 75;
        int JobLevel = 1;
        int MathsS = 1;
        int ArtS = 1;
        int HoursSpentWorking = 0;

        public Form1()
        {
            InitializeComponent();
        }

        public void GetAllData(object sender, EventArgs e)
        {
            //This void is more like a game Loop/Update function

            if (MathsS >= 5 && JobLevel == 1)
            {
                //Upgrade job
                JobLevel++;
                IQ += 3;
                LabelWorkPrice.Text = "Working for: $10 per hour (click)";
                JobType.Text = "Job: new Maths teacher";
                ChangeNextJobs(sender, e);
            }

            else if (ArtS >= 5 && JobLevel == 1)
            {
                //Upgrade job
                JobLevel++;
                IQ += 3;
                LabelWorkPrice.Text = "Working for: $10 per hour (click)";
                JobType.Text = "Job: new Art teacher";
                ChangeNextJobs(sender, e);
            }

            else if (MathsS >= 15 && JobLevel == 2)
            {
                //Upgrade job
                JobLevel++;
                IQ += 7;
                LabelWorkPrice.Text = "Working for: $25 per hour (click)";
                JobType.Text = "Job: Maths teacher";
                ChangeNextJobs(sender, e);
            }

            else if (ArtS >= 15 && JobLevel == 2)
            {
                //Upgrade job
                JobLevel++;
                IQ += 7;
                LabelWorkPrice.Text = "Working for: $25 per hour (click)";
                JobType.Text = "Job: Art teacher";
                ChangeNextJobs(sender, e);
            }

            UpdateCounters(sender, e);
            AgeManager(sender, e);
        }

        private void AgeManager(object sender, EventArgs e)
        {
            //This will just add up to 5 years to your age, you can add more if you want to
            if (HoursSpentWorking >= 100 && HoursSpentWorking < 200 && Age < 19)
            {
                Age++;
            }

            else if (HoursSpentWorking >= 200 && HoursSpentWorking < 300 && Age < 20)
            {
                Age++;
            }

            else if (HoursSpentWorking >= 300 && HoursSpentWorking < 400 && Age < 21)
            {
                Age++;
            }

            else if (HoursSpentWorking >= 400 && HoursSpentWorking < 500 && Age < 22)
            {
                Age++;
            }

            else if (HoursSpentWorking >= 500 && HoursSpentWorking < 600 && Age < 23)
            {
                Age++;
            }
        }

        private void ChangeNextJobs(object sender, EventArgs e)
        {
            if (JobLevel == 2)
            {
                NextJob1.Text = "Job: Maths teacher";
                NextJob2.Text = "Job: Art teacher";
                NextJob3.Text = "Job: ???";
                NextJob1Needed.Text = "Needed: Maths skill lvl 15";
                NextJob2Needed.Text = "Needed: Art skill lvl 15";
                NextJob3Needed.Text = "Needed: ???";
            }

            else if (JobLevel == 3)
            {
                NextJob1.Text = "Job: ???";
                NextJob2.Text = "Job: ???";
                NextJob3.Text = "Job: ???";
                NextJob1Needed.Text = "Needed: ???";
                NextJob2Needed.Text = "Needed: ???";
                NextJob3Needed.Text = "Needed: ???";
            }
        }

        private void UpdateCounters(object sender, EventArgs e)
        {
            PurseLabel.Text = "Purse: $" + Money.ToString();
            AgeLabel.Text = "Age: " + Age.ToString();
            iqLabel.Text = "IQ: " + IQ.ToString();
            NetworthLabel.Text = "Networth: $" + Networth.ToString();
            ArtSkill.Text = "Art:  " + ArtS.ToString();
            MathsSkill.Text = "Maths: " + MathsS.ToString();
            HoursSpentWorkingLabel.Text = "Hours working: " + HoursSpentWorking.ToString();
        }

        private void BtnWork_Click(object sender, EventArgs e)
        {
            HoursSpentWorking++;
            GetAllData(sender, e);
            if (JobLevel == 1)
            {
                Money += 2;
            }

            else if (JobLevel == 2)
            {
                Money += 10;
            }

            else if (JobLevel == 3)
            {
                Money += 25;
            }
        }

        private void LearnMaths_Click(object sender, EventArgs e)
        {
            if (Money >= 50)
            {
                Money -= 50;
                MathsS++;
                Networth+=120;
            }
            GetAllData(sender, e);
        }

        private void LearnArt_Click(object sender, EventArgs e)
        {
            if (Money >= 50)
            {
                Money -= 50;
                ArtS++;
                Networth+=120;
            }
            GetAllData(sender, e);
        }

        private void YourName_Click(object sender, EventArgs e)
        {
            if (RenameTextBox.Visible == false)
            {
                RenameTextBox.Visible = true;
            }

            else if (RenameTextBox.Visible == true)
            {
                if (RenameTextBox.Text == "Name here")
                {
                    YourName.Text = "Bob";
                    RenameTextBox.Visible = false;
                }

                else
                {
                    YourName.Text = RenameTextBox.Text.ToString();
                    RenameTextBox.Visible = false;
                    RenameTextBox.Clear();
                }
            }
        }
    }
}
