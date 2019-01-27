using UnityEngine;

namespace Assets.Scripts._2018.UI.Health_Draining_Strategies
{
    public abstract class HealthDrainedStrategy : MonoBehaviour
    {
        public abstract void HealthDrained(HealthManager manager);
    }
}