using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToBeNamed.Misc
{
    public class WorldShenanigans : MonoBehaviour
    {
        public List<GameObject> Rotators;
        public List<GameObject> Scalers;

        [SerializeField]
        [Range(0f, 100f)]
        private float RotationSpeed;

        [SerializeField]
        [Range(0f, 100f)]
        private float ScaleSpeed;

        [SerializeField]
        [Range(2f, 100f)]
        private float ScaleMagnitude;

        private float ScaleValue;

        void Update()
        {
            ScaleValue = Mathf.Abs(Mathf.Sin(ScaleValue) * ScaleMagnitude) + 1;

            foreach (GameObject r in Rotators)
            {
                r.transform.Rotate(transform.up * RotationSpeed);
            }

            foreach (GameObject s in Scalers)
            {             
                s.transform.localScale = Vector3.Slerp(s.transform.localScale, Vector3.one * ScaleValue, ScaleSpeed * Time.deltaTime);
            }
        }
    }
}