using System;

public class Frame_t
{
    private int num_pixels;
    private short[] depth_pixels;
    private static short[] default_frame;
    
	public Frame_t()
	{
        num_pixels = 307200; //640 px * 480 px
        depth_pixels = new short[num_pixels];
        default_frame = new short[num_pixels];
	}
    public Frame_t(int _num_pixels)
    {
        num_pixels = _num_pixels;
        depth_pixels = new short[num_pixels];
        default_frame = new short[num_pixels];
    }
    public Frame_t(Frame_t frame_one, Frame_t frame_two)
    {
        num_pixels = frame_one.num_pixels;
        //Not sure which array to copy from either one
        Buffer.BlockCopy(frame_one.depth_pixels, 0, depth_pixels, 0, num_pixels);
        Buffer.BlockCopy(frame_two.default_frame, 0, default_frame, 0, num_pixels);
    }
    public void adjustFrame(short[] rawDepthPixels)
    {
        for (int i = 0; i < num_pixels; ++i)
        {
            short inputDiff = abs(rawDepthPixels[i] - depth_pixels[i]);
            short refDiff = abs(rawDepthPixels[i] - default_frame[i]);
            if (inputDiff > refDiff)
                depth_pixels[i] = inputDiff;
        }
    }
    double computeDeviation(Frame_t inputFrame)
    {
        double error = 0;
        for (int i = 0; i < num_pixels; ++i)
            error += abs(inputFrame[i] - depthPixels[i]);

        return error / num_pixels;
    }
}
