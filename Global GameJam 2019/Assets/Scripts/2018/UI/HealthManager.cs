using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts._2018.UI
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField]
        public Dictionary<HealthObjectType, Health> HealthObjects;

        public void Start()
        {
            if (HealthObjects == null)
            {
                Debug.Log("NO HEALTH OBJECTS");
                return;
            }
            foreach (var healthObject in HealthObjects)
            {
                healthObject.Value.OnHealthDrained += HealthDrained;
            }
        }

        public void HealthDrained()
        {
        }

        public void DealDamage(HealthObjectType type, int amount)
        {
            HealthObjects[type].DealDamage(amount);
        }

        public void AddHealth(HealthObjectType type, int amount)
        {
            HealthObjects[type].AddHealth(amount);
        }
    }
}
