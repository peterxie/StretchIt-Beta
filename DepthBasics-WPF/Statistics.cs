using System;
using System.IO;

namespace StretchIt
{
    public class Statistics_t : MenuPage_t
    {
        private string path;
        private int all_longest_streak; //all-time
        private double all_percent_correct;
        private int rec_longest_streak; //recent
        private double rec_percent_correct;

        public override void back()
        {

        }

        //not listed in design doc, but assuming we need this
        public override void display()
        {

        }

        public void loadStatistics()
        {
            StreamReader file = new StreamReader(path);
            all_longest_streak = int.Parse(file.ReadLine());
            all_percent_correct = double.Parse(file.ReadLine());
            rec_longest_streak = int.Parse(file.ReadLine());
            rec_percent_correct = double.Parse(file.ReadLine());
        }

        public void saveStatistics()
        {
            StreamWriter file = new StreamWriter(path);
            file.WriteLine(all_longest_streak);
            file.WriteLine(all_percent_correct);
            file.WriteLine(rec_longest_streak);
            file.WriteLine(rec_percent_correct);
        }
    }
}
