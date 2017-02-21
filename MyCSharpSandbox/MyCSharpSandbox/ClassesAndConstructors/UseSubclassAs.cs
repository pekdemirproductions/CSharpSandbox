using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class UseSubclassAs
    {
        public static void Start()
        {
            // Create a Base and a Subclass.
            // Then create a general function that may use
            // the Subclass differently (C# All in One, Page 323)
            VideoPlayer myVideoPlayer = new VideoPlayer();
            MediaPlayer myMediaPlayer = new MediaPlayer();
            
            myVideoPlayer.Play("c:\\FightClub.avi");
            myMediaPlayer.Play("c:\\Music\\RATM-Killing_in_the_name_of.mp3");

            MediaInfo(myVideoPlayer);
            MediaInfo(myMediaPlayer);
        }

        public static void MediaInfo(MediaPlayer newMediaPlayer)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Media Info for: {0}", newMediaPlayer.playedMedia);
            Console.WriteLine("Current Volume is set to: {0}", newMediaPlayer.volume);

            VideoPlayer tempVideoPlayer = newMediaPlayer as VideoPlayer;
            if (tempVideoPlayer != null)
            {
                Console.WriteLine("Video resolution is: {0}", tempVideoPlayer.videoResolution);
            }

            Console.WriteLine("\n [END OF MEDIA INFO] \n");
        }

        public class MediaPlayer
        {
            public int volume { get; private set; } = 50;
            public string playedMedia { get; private set; } 

            public void Play(string newMedia)
            {
                playedMedia = newMedia;
            }

            virtual public void outputNowPlayingMessage()
            {
                Console.WriteLine("Now playing media: {0}", playedMedia);
            }

            public void SetVolume(int newVolume)
            {
                if      (newVolume > 100)   { volume = 100; }
                else if (newVolume < 0)     { volume = 0; }
                else                        { volume = newVolume; }
            }
        }

        public class VideoPlayer : MediaPlayer
        {
            public string videoResolution = "Standard Definition or Unknown";

            override public void outputNowPlayingMessage()
            {
                Console.WriteLine("Now playing video: {0}", playedMedia);
            }

        }
    }
}
