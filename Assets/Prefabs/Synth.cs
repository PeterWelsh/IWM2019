using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synth : MonoBehaviour
{
    
    public double frequ = 440.0;
    private double increment;
    private double phase;
    private double sampling_freq = 48000.0;

    public float gain;
    public float volume = 0.001f;

    public float[] frequencies;
    public int thisFreq;

    

    private void Start()
    {
      
        frequencies = new float[8];
        frequencies[0] = 1440;
        frequencies[1] = 1494;
        frequencies[2] = 1554;
        frequencies[3] = 1587;
        frequencies[4] = 1659;
        frequencies[5] = 1740;
        frequencies[6] = 1831;
        frequencies[7] = 1880;
       
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            playNote(1831);
            //gain = volume;
            //frequ = frequencies[thisFreq];
            //thisFreq++;
            //if(thisFreq > 7)
            //{
            //    thisFreq = 0;
            //}
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            EndNote();
            //gain = 0.0f;
        }
    }
    private void OnAudioFilterRead(float[] data, int channels)
    {

        increment = frequ * 2.0 * Mathf.PI / sampling_freq;

        for (int i = 0; i < data.Length; i += channels)
        {
            phase += increment;


            
                if (gain * Mathf.Sin((float)phase) >= 0 * gain)
                {
                    data[i] = (float)gain * 0.6f;
                }
                else
                {
                    data[i] = (-(float)gain) * 0.6f;
                }

             

            if (channels == 2)
            {
                data[i + 1] = data[i];
            }

            if (phase > (Mathf.PI * 2))
            {
                phase = 0.0;
            }
        }



    }

   public void playNote(float f)
    {
        gain = volume;
        frequ = f;
    }

    public void EndNote()
    {
        gain = 0.0f;
    }

    
}
