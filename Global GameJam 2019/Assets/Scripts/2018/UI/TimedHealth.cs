using System.Collections;

using UnityEngine;

namespace Assets.Scripts._2018.UI
{
    public class TimedHealth : Health, ITimed
    {
        public void Start()
        {
            base.Start();
            StartTicking();
        }

        [SerializeField]
        private float _tickIntervalInSeconds;

        public float TickIntervalInSeconds
        {
            get => _tickIntervalInSeconds;
            set => _tickIntervalInSeconds = value;
        }

        [SerializeField]
        private int _damagePerSecond;

        public int DamagePerSecond
        {
            get => _damagePerSecond;
            set => _damagePerSecond = value;
        }

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
