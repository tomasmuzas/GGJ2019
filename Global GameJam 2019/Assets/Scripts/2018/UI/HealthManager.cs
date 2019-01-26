using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

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

                // That's sad...
                switch (obj.Type)
                {
                    case HealthObjectType.Food:
                        obj.HealthSlider = GameObject.Find("Food Health Bar").GetComponentInChildren<Slider>();
                        break;
                }
                HealthObjects.Add(healthObject.Type, obj);
            }
        }

        public void HealthDrained()
        {
            GameObject.Find("Engine").GetComponent<Darkness>().StartDarkening();
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
