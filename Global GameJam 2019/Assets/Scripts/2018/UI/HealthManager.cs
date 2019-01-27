using System;
using System.Collections.Generic;

using Assets.Scripts._2018.UI.Health_Draining_Strategies;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts._2018.UI
{
    public class HealthManager : MonoBehaviour
    {
        public Dictionary<HealthObjectType, Health> HealthObjects;

        // For editor
        public List<Health> HealthItems;

        public HealthDrainedStrategy HealthDrainedStrategy;

        public void Start()
        {
            if (HealthDrainedStrategy == null)
            {
                throw new ArgumentException("Health Drained Strategy cannot be empty!");
            }

            HealthObjects = new Dictionary<HealthObjectType, Health>();

            foreach (var healthObject in HealthItems)
            {
                var obj = Instantiate(healthObject);
                obj.OnHealthDrained += HealthDrainedStrategy.HealthDrained;

                // Damn that's terrible, I'm sorry:D
                switch (obj.Type)
                {
                    case HealthObjectType.Food:
                        obj.HealthSlider = GameObject.Find("Food Health Bar").GetComponentInChildren<Slider>();
                        break;
                    case HealthObjectType.Alcohol:
                        obj.HealthSlider = GameObject.Find("Alcohol Health Bar").GetComponentInChildren<Slider>();
                        break;
                    case HealthObjectType.Health:
                        break;
                }

                HealthObjects.Add(healthObject.Type, obj);
            }
        }

        public void DealDamage(HealthObjectType type, int amount)
        {
            HealthObjects[type].DealDamage(amount);
        }

        public void AddHealth(HealthObjectType type, int amount)
        {
            HealthObjects[type].AddHealth(amount);
            GameObject.Find("Engine").GetComponent<Darkness>().StopDarkening();
        }

        public float GetPercentage(HealthObjectType type)
        {
            return HealthObjects[type].GetPercentage();
        }
    }
}
