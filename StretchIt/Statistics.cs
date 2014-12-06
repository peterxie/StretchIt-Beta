using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace StretchIt
{
    public partial class Statistics_t : Form
    {
        private int all_longest_streak; //all-time
        private int all_number_executed_moves; //all-time number of executed moves
        private int all_number_correct_moves; //all-time number of correct executed moves
        private double all_percent_correct; //all-time percent correct

        private int tmp_streak_count;
        private int recent_longest_streak; //maximum number of correct gestures in a row in a given game
        private int recent_num_executed_moves; //number of moves executed in the current game
        private int recent_num_correct_moves; //number of moves correctly executed in current game
        private double recent_percent_correct; //percent moves correct in the current game
        
        public Statistics_t()
        {
            this.DoubleBuffered = true;

            InitializeComponent();
            this.Visible = false;

            foreach (Control c in this.Controls)
            {
                c.Anchor = AnchorStyles.None;
            }

            loadStatistics();
            display();
        }

        private void display()
        {
            streakAllTimeValue.Text = all_longest_streak.ToString();
            correctAllTimeValue.Text = all_number_correct_moves.ToString();
            totalAllTimeValue.Text = all_number_executed_moves.ToString();
            percentAllTimeValue.Text = all_percent_correct.ToString("F2") + "%";
            streakRecentValue.Text = recent_longest_streak.ToString();
            correctRecentValue.Text = recent_num_correct_moves.ToString();
            totalRecentValue.Text = recent_num_executed_moves.ToString();
            percentRecentValue.Text = recent_percent_correct.ToString("F2") + "%";
        }

        public void recordResult(bool correctInput)
        {
            ++recent_num_executed_moves;
            ++all_number_executed_moves;
            if (correctInput)
            {
                ++tmp_streak_count;
                ++recent_num_correct_moves;
                ++all_number_correct_moves;
            }
            else
            {
                recent_longest_streak = Math.Max(tmp_streak_count, recent_longest_streak);
                all_longest_streak = Math.Max(recent_longest_streak, all_longest_streak);
                tmp_streak_count = 0;
            }
            recent_percent_correct = ((double) recent_num_correct_moves / recent_num_executed_moves) * 100;
        }

        public void loadStatistics()
        {
            try
            {
                using(StreamReader file = new StreamReader(GlobalVar.STATS_PATH_C))
                {
                    all_longest_streak = int.Parse(file.ReadLine());
                    all_number_executed_moves = int.Parse(file.ReadLine());
                    all_number_correct_moves = int.Parse(file.ReadLine());
                    all_percent_correct = double.Parse(file.ReadLine());
                    recent_longest_streak = int.Parse(file.ReadLine());
                    recent_num_executed_moves = int.Parse(file.ReadLine());
                    recent_num_correct_moves = int.Parse(file.ReadLine());
                    recent_percent_correct = double.Parse(file.ReadLine());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception caught in loadStatistics: {0}", e);
                useDefaults();
            }
        }

        private void useDefaults()
        {
            all_longest_streak = 0;
            all_percent_correct = 0;
            all_number_executed_moves = 0;
            all_number_correct_moves = 0;
            recent_longest_streak = 0;
            recent_num_correct_moves = 0;
            recent_num_executed_moves = 0;
            recent_percent_correct = 0;
        }

        public void saveStatistics()
        {
            if (all_number_executed_moves == 0)
            {
                all_percent_correct = 0;
            }

            else
            {
                all_percent_correct = ((double) all_number_correct_moves / all_number_executed_moves);
            }

            StreamWriter file = new StreamWriter(GlobalVar.STATS_PATH_C);
            file.WriteLine(all_longest_streak);
            file.WriteLine(all_number_executed_moves);
            file.WriteLine(all_number_correct_moves);
            file.WriteLine(all_percent_correct);
            file.WriteLine(recent_longest_streak);
            file.WriteLine(recent_num_executed_moves);
            file.WriteLine(recent_num_correct_moves);
            file.WriteLine(recent_percent_correct);
            file.Close();
        }

        /* Event Handling Functions */

        private void backLabel_Click(object sender, EventArgs e)
        {
            GlobalVar.MAIN_MENU.Activate();
            GlobalVar.MAIN_MENU.Visible = true;
            this.Visible = false;
        }

        private void Statistics_t_Activated(object sender, EventArgs e)
        {
            display();
        }

        private void Statistics_t_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("You must exit via the Back button.");
        }

        private void resetLabel_Click(object sender, EventArgs e)
        {
            useDefaults();
            display();
            saveStatistics();
        }
    }
}
