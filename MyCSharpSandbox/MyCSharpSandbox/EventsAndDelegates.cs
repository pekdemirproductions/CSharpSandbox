using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace MyCSharpSandbox
{
    class EventsAndDelegates
    {
        // Quelle: https://www.youtube.com/watch?v=jQgwEsJISy0

        public static void Start()
        {
            var video = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder();      // Publisher
            var mailService = new Mailservice();        // Subscriber
            var messageService = new Messageservice();   // Subscriber

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncodingPaused += mailService.OnVideoPaused;

            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
            videoEncoder.VideoEncodingPaused += messageService.OnVideoPaused;

            videoEncoder.Encode(video);
        }

        public class VideoEventArgs : EventArgs
        {
            public Video Video { get; set; }
        }

        public class VideoEncoder
        {
            // Was wir brauchen, um andere Klassen zu informieren, wenn die Video-Kodierung fertig ist:
            // 1- Define a delegate - The contract between the publisher and the subscriber
            // 2- Defíne an event based on that delegate
            // 3- Raise the event

            public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);       // 1- The Delegate

            public event VideoEncodedEventHandler VideoEncoded;     // 2- An event based on the Delegate above
            public event VideoEncodedEventHandler VideoEncodingPaused;

            public void Encode(Video video)
            {
                // Encoding Logic
                Console.WriteLine("Encoding Video...");
                Thread.Sleep(3000);
                OnVideoEncoded(video);       // 3- Raise the event (defined below)
                OnVideoEncodingPaused();

                // _mailService.send(new Mail());
                // _messageService.Send(new Text());
            }

            protected virtual void OnVideoEncoded(Video video)
            {
                if (VideoEncoded != null)
                    VideoEncoded(this, new VideoEventArgs() { Video = video});
            }

            protected virtual void OnVideoEncodingPaused()
            {
                if (VideoEncodingPaused != null)
                    VideoEncodingPaused(this, new VideoEventArgs() { });
            }

        }

        public class Video
        {
            public string Title { get; set; }
        }

        public class Mailservice
        {
            public void OnVideoEncoded(object source, EventArgs e)
            {
                Console.WriteLine("Mail-Service: Video encoding finished! Sending an email ...");
            }

            public void OnVideoPaused(object source, EventArgs e)
            {
                Console.WriteLine("Mail-Service: Video encoding paused! Sending an email ...!");
            }
        }

        public class Messageservice
        {
            public void OnVideoEncoded(object source, EventArgs e)
            {
                Console.WriteLine("Message-Service: Video encoding finished! Sending a message ...");
            }
            public void OnVideoPaused(object source, EventArgs e)
            {
                Console.WriteLine("Message-Service: Video encoding Paused! Sending a Message ...");
            }
        }



    }
}
