using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SpotTheDifference
{
    public class DifferenceBackground : MonoBehaviour, IBehaviour, IPointerClickHandler
    {
        [Header("Background Config")] 
        [SerializeField] private DifferenceBackgroundConfig differenceBackgroundConfig;

        [Header("Cross GameObject")] 
        [SerializeField] private GameObject cross;
        
        [Header("Items on the Background")]
        [SerializeField] private List<DifferenceObject> differenceObjects;

        public event Action<int, int> OnChildDifferenceOnjectSelected;
        public event Action OnWrongChoiceMade;
        
        [Serializable]
        private struct DifferenceBackgroundConfig
        {
            public int id;
        }

        public void Initialize()
        {
            differenceObjects.ForEach(x => x.OnClickedObject += OnClickedDifferenceObject);
        }
        
        public bool HasAllFound()
        {
            return differenceObjects.All(x => x.HasFound);
        }

        public int GetObjectCount()
        {
            return differenceObjects.Count;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //If player clicks the background it fails
            OnWrongChoiceMade?.Invoke();
            Instantiate(cross, eventData.position, quaternion.identity, transform);
            GameManager.Instance.soundManager.PlayGameEffectsSound(GameEffects.Wrong);
            Taptic.Medium();
        }

        public void SelectChildDifferenceObject(int id)
        {
            differenceObjects[id].ObjectSelectedSuccessfully();
        }

        #region Events
        
        private void OnClickedDifferenceObject(int childID)
        {
            OnChildDifferenceOnjectSelected?.Invoke(differenceBackgroundConfig.id,childID);
        }
        
        private void OnDestroy()
        {
            differenceObjects.ForEach(x =>
            {
                if (x is not null)
                {
                    x.OnClickedObject -= OnClickedDifferenceObject;
                }
            });
        }

        #endregion Events
        
        
    }
}
