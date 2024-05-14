using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpotTheDifference
{
    public static class Constants 
    {
        public static class Prefs
        {
            public const int MAX_HEALTH_COUNT = 3;
        }
    }

    public enum ClickSound
    {
        ButtonClick = 0
    }

    public enum GameEffects
    {
        Correct = 0,
        Wrong = 1
    }
    
    public enum GameStateSound
    {
        StartGame = 0,
        LevelComplete = 1,
        LevelFail = 2
    }

    public enum Panels
    {
        MainMenu = 0,
        Hud = 1,
        LevelComplete = 2,
        LevelFail = 3
    }
}
