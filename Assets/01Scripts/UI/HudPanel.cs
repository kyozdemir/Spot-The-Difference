using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpotTheDifference
{
    public class HudPanel : UIPanel
    {
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private LifeCounter lifeCounter;
        [SerializeField] private FoundObjectCounter foundObjectCounter;

        public override void Initialize()
        {
            base.Initialize();
            foundObjectCounter.Initialize();
            lifeCounter.Initialize();
        }

        public override void ShowPanel()
        {
            lifeCounter.StartGame();
            foundObjectCounter.StartGame();
            UpdateLabels();
            base.ShowPanel();
        }

        public override void UpdateLabels()
        {
            levelText.SetText($"LEVEL {GameManager.Instance.levelManager.CurrentLevelNumber+1}");
            base.UpdateLabels();
        }
    }
}
