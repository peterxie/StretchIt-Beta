using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StretchIt
{
    class AV_Output_t
    {
        private string image_path;
        private string audio_path;
        private DisplayWindow display = new DisplayWindow();

        public AV_Output_t(string image_path_, string audio_path_)
        {
            image_path = image_path_;
            audio_path = audio_path_;
        }

        public void load()
        {
            display.loadOutput(audio_path, image_path);
        }
    }
}
