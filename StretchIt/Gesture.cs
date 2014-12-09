using System;

namespace StretchIt
{
    class Gesture_t
    {
        private string name;
        private Frame_t correct_gesture;
        private AV_Output_t prompt;
        private AV_Output_t celebration;

        public Gesture_t(string name_, string cg_path_, 
            string prompt_audio_, string prompt_image_)
        {
            name = name_;
            correct_gesture = new Frame_t(cg_path_);
            prompt = new AV_Output_t(prompt_image_, prompt_audio_);

            int seed = unchecked(DateTime.Now.Ticks.GetHashCode());
            Random r1 = new Random(seed);
            Random r2 = new Random(seed);
            int audio_idx = r1.Next(GlobalVar.CELEB_AUDIO_FILES.Length);
            int image_idx = r2.Next(GlobalVar.CELEB_IMAGE_FILES.Length);

            celebration = new AV_Output_t(GlobalVar.CELEB_IMAGE_FILES[image_idx], GlobalVar.CELEB_AUDIO_FILES[audio_idx]);
        }

        public void sendPrompt()
        {
            prompt.load();
        }

        public Gesture_rc_e processGesture(Frame_t user_attempt)
        {
            return correct_gesture.computeDeviation(user_attempt);
        }

        public void sendFeedback()
        {
            celebration.load();
        }

        public void closeWindow()
        {
            prompt.closeWindow();
        }
    }
}