using System.Collections;

using UnityEngine;

namespace Assets.Scripts._2018.UI
{
    public class TimedHealth : Health, ITimed
    {
        public void Start()
        {
            StartTicking();
        }

        public float TickIntervalInSeconds { get; set; }

        public int DamagePerSecond { get; set; }

        public void StartTicking()
        {
            StartCoroutine(DealDamageOverTime());
        }

        private IEnumerator DealDamageOverTime()
        {
            while (true)
            {
                DealDamage(DamagePerSecond);
                yield return new WaitForSeconds(TickIntervalInSeconds);
            }
        }
    }
}
