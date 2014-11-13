using System;
using System.Collections.Generic;

namespace StretchIt
{
    public abstract class MenuPage_t {
        
        //function pointer
        public delegate void MenuOptDelegate();

        private List<Tuple<Frame_t, MenuOptDelegate>> command_options;
        private AV_Output_t output;

        public abstract void back();

        public abstract void display();

        public void addFrameFnPair(Tuple<Frame_t, MenuOptDelegate> fn_pair)
        {
            command_options.Add(fn_pair);
        }

        public void removeFrameFnPair(Tuple<Frame_t, MenuOptDelegate> fn_pair)
        {
            command_options.Remove(fn_pair);
        }
    }
}

