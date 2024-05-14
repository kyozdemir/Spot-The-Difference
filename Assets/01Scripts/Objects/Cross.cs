using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpotTheDifference
{
    public class Cross : MonoBehaviour
    {
        private void Start()
        {
            //Destroy the cross
            //I prefer object pooling but no need for that
            Destroy(gameObject,1f);
        }
    }
}
