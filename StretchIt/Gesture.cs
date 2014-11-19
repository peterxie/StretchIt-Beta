namespace StretchIt
{
    class Gesture_t
    {
        private string name;
        private Frame_t correct_gesture;
        private AV_Output_t prompt;
        private AV_Output_t celebration;

        public Gesture_t(string name_, string cg_path_, 
            string prompt_audio_, string prompt_image_,
            string celeb_audio_, string celeb_image_)
        {
            name = name_;
            correct_gesture = new Frame_t(cg_path_);
            prompt = new AV_Output_t(prompt_image_, prompt_audio_);
            celebration = new AV_Output_t(celeb_image_, celeb_audio_);
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
    }
}