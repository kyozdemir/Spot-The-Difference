using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpotTheDifference
{
    public class LevelController : MonoBehaviour, IBehaviour
    {
        [SerializeField] private List<DifferenceBackground> backgrounds;

        public event Action<bool> OnDifferenceSelected;
        
        public void Initialize()
        {
            backgrounds.ForEach(x =>
            {
                x.Initialize();
                x.OnChildDifferenceOnjectSelected += OnDifferenceObjectSelected;
                x.OnWrongChoiceMade += OnWrongChoiceMade;
            });
        }

        private bool HasAllFound()
        {
            return backgrounds[0].HasAllFound();
        }

        public int GetObjectCount()
        {
            return backgrounds[0].GetObjectCount();
        }
        
        public void Activate() { }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
        
        
        #region Events
        
        private void OnDifferenceObjectSelected(int bgID, int childID)
        {
            backgrounds.ForEach(x => x.SelectChildDifferenceObject(childID));
            OnDifferenceSelected?.Invoke(true);
            GameManager.Instance.soundManager.PlayGameEffectsSound(GameEffects.Correct);
            Taptic.Light();
            if (HasAllFound())
            {
                GameManager.Instance.LevelCompleted();
            }
        }

        private void OnWrongChoiceMade()
        {
            OnDifferenceSelected?.Invoke(false);
        }
        
        private void OnDestroy()
        {
            backgrounds.ForEach(x =>
            {
                if (x is not null)
                {
                    x.OnChildDifferenceOnjectSelected -= OnDifferenceObjectSelected;
                    x.OnWrongChoiceMade -= OnWrongChoiceMade;
                }
            });
        }

        #endregion Events

        #region Game State Methods

        public void LevelCompleted()
        {
            
        }
        
        public void LevelFailed()
        {
            
        }
        
        public void ReturnedToMainMenu()
        {
            
        }
        
        public void StartGame()
        {
            
        }

        #endregion
        
    }
}
