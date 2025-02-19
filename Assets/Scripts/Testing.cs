using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Testing : MonoBehaviour
    {
        private bool _isPetting;

        void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.CompareTag("dog"))
            {
                if (_isPetting) return;
                Debug.Log("Petting with right hand");

            }
        }

        void OnTriggerExit(Collider collider)
        {
            if(collider.gameObject.CompareTag("dog"))
            {
                Debug.Log("Stopped petting with right hand");
            }
        }
    }
}