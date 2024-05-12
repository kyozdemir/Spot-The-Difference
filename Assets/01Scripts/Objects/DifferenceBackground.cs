using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SpotTheDifference
{
    public class DifferenceBackground : MonoBehaviour, IBehaviour, IPointerClickHandler
    {
        [Header("Background Config")] 
        [SerializeField] private DifferenceBackgroundConfig differenceBackgroundConfig;
        
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
            OnWrongChoiceMade?.Invoke();
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
