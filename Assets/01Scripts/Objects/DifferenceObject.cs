using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace SpotTheDifference
{
    public class DifferenceObject : MonoBehaviour, IPointerClickHandler
    {
        [Header("Object Config")] 
        [SerializeField] private DifferenceObjectConfig differenceObjectConfig;

        [Header("Checkmark")]
        [SerializeField] private GameObject checkmarkGObj;

        public event Action<int> OnClickedObject;

        public bool HasFound => differenceObjectConfig.hasFound;
        public int ID => differenceObjectConfig.id;
        
        [Serializable]
        private struct DifferenceObjectConfig
        {
            public int id;
            public bool hasFound;
        }

        public void ObjectSelectedSuccessfully()
        {
            differenceObjectConfig.hasFound = true;
            checkmarkGObj.SetActive(true);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //User clicked the true object
            if(differenceObjectConfig.hasFound) return;
            ObjectSelectedSuccessfully();
            OnClickedObject?.Invoke(differenceObjectConfig.id);
        }
    }
}
