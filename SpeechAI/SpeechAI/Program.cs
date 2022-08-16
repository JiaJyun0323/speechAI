using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech.PronunciationAssessment;

namespace SpeechAI
{
    internal class Program
    {
        public static string res;
        static void Main(string[] args)
        {
            for(int i=0; i < 3; i++)
            {
                RecognitionWithMicrophoneAsync().Wait();
            }



            //SynthesisToSpeakerAsync().Wait();

        }




        public static async Task RecognitionWithMicrophoneAsync()
        {
            // <recognitionWithMicrophone>
            // Creates an instance of a speech config with specified subscription key and service region.
            // Replace with your own subscription key and service region (e.g., "westus").
            // The default language is "en-us".
            var config = SpeechConfig.FromSubscription("8824f906af8d47cc9f61a000d5fccfd1", "koreacentral");

            // Creates a speech recognizer using microphone as audio input.
            using (var recognizer = new SpeechRecognizer(config))
            {
                // Starts recognizing.
                Console.WriteLine("我叫你問問題:)");

                // Starts speech recognition, and returns after a single utterance is recognized. The end of a
                // single utterance is determined by listening for silence at the end or until a maximum of 15
                // seconds of audio is processed.  The task returns the recognition text as result.
                // Note: Since RecognizeOnceAsync() returns only a single utterance, it is suitable only for single
                // shot recognition like command or query.
                // For long-running multi-utterance recognition, use StartContinuousRecognitionAsync() instead.
                var result = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);

                // Checks result.

                Console.WriteLine("問題:"+result.Text);

                var synthesizer = new SpeechSynthesizer(config);
                string text = result.Text;

                if (text == "Hello.")
                {
                    var result2 = await synthesizer.SpeakTextAsync("hey");
                    Console.WriteLine("AI:hey");
                }
                else if (text == "How are you?")
                {
                    var result2 = await synthesizer.SpeakTextAsync("I find");
                    Console.WriteLine("AI:I find");
                }
                else if(text == "Joining us.")
                {
                    var result2 = await synthesizer.SpeakTextAsync("ok");
                    Console.WriteLine("AI:ok");
                }
                else
                {
                    var result2 = await synthesizer.SpeakTextAsync("please say again");
                    Console.WriteLine("AI:please say again");
                }
            }
            // </recognitionWithMicrophone>
        }
    }
}
