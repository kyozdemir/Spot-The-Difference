using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpotTheDifference
{
    public class UIPanel : MonoBehaviour, IBehaviour
    {
        public virtual void Initialize() { }

        public virtual void HidePanel()
        {
            gameObject.SetActive(false);
        }

        public virtual void ShowPanel()
        {
            gameObject.SetActive(true);
        }

        public virtual void UpdateLabels() { }
    }
}
