using System;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts._2018.UI
{
    public class HealthManager : MonoBehaviour
    {
        public Dictionary<HealthObjectType, Health> HealthObjects;

        // For editor
        public List<Health> HealthItems;

        public void Start()
        {
            HealthObjects = new Dictionary<HealthObjectType, Health>();

            foreach (var healthObject in HealthItems)
            {
                var obj = Instantiate(healthObject);
                obj.OnHealthDrained += HealthDrained;
                HealthObjects.Add(healthObject.Type, obj);
            }
        }

        public void HealthDrained()
        {
            print("Player died!");
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
