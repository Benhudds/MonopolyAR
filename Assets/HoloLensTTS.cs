using UnityEngine;
using System.Collections;
using SpeechLib;
using System.Xml;
using System.IO;
using System.Threading;

/**************************************************************************************
 * ******************Text to Speech for Windows SAPI *********************************
 * ************************************************************************************
 * v 1.0 - 01/01/2016
 * Marco Martinelli 
 * marco.m@gamesource.it
 * 
 * 
 * Tested on Windows 10, SAPI 4.0 | Windows 8.1
 * More info on www.finalmarco.com
/*************************************************************************************/



public class HoloLensTTS : MonoBehaviour, ITTSInterface
{

    private SpVoice voice;

    public HoloLensTTS()
    {
        voice = new SpVoice();
    }
    
    public void Speak(string str)
    {
        Thread t = new Thread(() => voice.Speak("<speak version='1.0' xmlns='http://www.w3.org/2001/10/synthesis' xml:lang='en-US'>"
                        + str
                        + "</speak>",
                        SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFIsXML));
    }
}


