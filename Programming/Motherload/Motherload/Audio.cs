using SdlDotNet.Audio;
using SdlDotNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Motherload
{
    class Audio
    {
      
        private string musicString = "c2c1.wav";
        public string MusicString
        {
            set {  value = musicString;
            PlayAudio();
            }
         }
        public void PlayAudio()
        {
            try
            {
                Music bgMusic = new Music(musicString);
                MusicPlayer.Volume = 80;
                MusicPlayer.Load(bgMusic);
                MusicPlayer.Play();
            }
            catch
            {}

        }
        public void StopMusic()
        {
            MusicPlayer.Stop();
        }
        public void playBoem()
        {

            try
            {
                Sound Boem = new Sound("boem.ogg");
                Boem.Volume = 100;
                Boem.FadeIn(50);
                Boem.Play();
            }
            catch 
            {
                
               
            }
           
        }
        public void PlayMetalClash(int volume)
        {
            try
            {
                Sound Metal = new Sound("crash_metal.ogg");
                Metal.Volume = volume;
                Metal.FadeIn(50);
                Metal.Play();
            }
            catch 
            {
                
               
            }
           
        }
        public void YheayBaby()
        {
            try
            {
                Sound Yheah = new Sound("YeahBaby.ogg");
                Yheah.FadeIn(50);
                Yheah.Play();
            }
            catch 
            {
                
            
            }
           
        }
    
      
     
    }
}
