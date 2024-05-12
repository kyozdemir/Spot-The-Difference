using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpotTheDifference
{
    public class UIController : MonoBehaviour, IBehaviour
    {
        public List<UIPanel> panels;

        public void Initialize()
        {
            panels.ForEach(x => x.Initialize());
            ReturnToMainMenu();
        }

        public UIPanel GetPanel(Panels panel)
        {
            return panels[(int)panel];
        }

        public void LevelCompleted()
        {
            GetPanel(Panels.Hud).HidePanel();
            GetPanel(Panels.LevelComplete).ShowPanel();
        }
        
        public void LevelFailed()
        {
            GetPanel(Panels.Hud).HidePanel();
            GetPanel(Panels.LevelFail).ShowPanel();
        }

        public void ReturnToMainMenu()
        {
            GetPanel(Panels.Hud).HidePanel();
            GetPanel(Panels.LevelComplete).HidePanel();
            GetPanel(Panels.LevelFail).HidePanel();
            GetPanel(Panels.MainMenu).ShowPanel();
        }
        
        public void StartGame()
        {
            GetPanel(Panels.LevelComplete).HidePanel();
            GetPanel(Panels.LevelFail).HidePanel();
            GetPanel(Panels.MainMenu).HidePanel();
            GetPanel(Panels.Hud).ShowPanel();
        }

        
    }
}
