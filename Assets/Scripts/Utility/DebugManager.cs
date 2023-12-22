using UnityEngine;

namespace TKK.Utility
{
    public  enum DEBUGMODE
    {
        RELEASE,
        VERBOSE,
    }

    public static class DebugManager 
    {
        public static DEBUGMODE DebugMode;
    
        public static void ChangeDebugMode(bool isVerbose)
        {
            DebugMode = isVerbose ? DEBUGMODE.VERBOSE : DEBUGMODE.RELEASE;
            PlayerPrefs.SetInt("DebugMode",(int)DebugMode);
        }
    }
}