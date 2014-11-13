//using System;

namespace StretchIt
{
    enum Game_State_e
    {
        Correct,
        No_Input,
        Back_Button,
        Incorrect
    }

    class Gesture_t
    {
        public bool is_active;
        private string name;
        private Frame_t correct_gesture;
        private AV_Output_t prompt;
        private AV_Output_t celebration;

        //Since gesture is a wrapper class, do we make a gesture constructor that
        //takes the parameters of AV_Output_t's and the Frame_t and constructs those for us

        public Gesture_t(bool _active, string _name, Frame_t _cg, 
            AV_Output_t _prompt, AV_Output_t _celeb)
        {
            is_active = _active;
            name = _name;
            correct_gesture = _cg;
            prompt = _prompt;
            celebration = _celeb;
        }

        public void sendPrompt()
        {
            prompt.load();
        }

        public Game_State_e processGesture(Frame_t user_attempt)
        {
            return correct_gesture.computeDeviation(user_attempt);
        }

        //package this into processGesture()???
        public void sendFeedback()
        {
            celebration.load();
        }
    }
}