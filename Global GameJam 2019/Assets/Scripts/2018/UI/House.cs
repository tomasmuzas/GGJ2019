using System;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts._2018.UI
{
    public class House : MonoBehaviour
    {
        public Sprite[] States;

        private HealthManager HealthManager;

        public void Start()
        {
            HealthManager = GetComponent<HealthManager>();
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            print("Collision happened");
            if (collision.gameObject.tag == "Projectile")
            {
                var dmg = collision.GetComponent<Skill>().Damage;
                HealthManager.DealDamage(HealthObjectType.Health, (int)dmg);
                var currentSprite = GetCurrentSprite();
                if (currentSprite < States.Length)
                {
                    GetComponent<SpriteRenderer>().sprite = States[currentSprite];
                }
                Destroy(collision.gameObject);
            }
        }

        public int GetCurrentSprite()
        {
            if (States.Length == 0)
            {
                throw new ArgumentException("There must be at least one state");
            }

            var percentagePerSprite = 100 / States.Length;

            var currentPercentage = (int)HealthManager.GetPercentage(HealthObjectType.Health);

            var index = currentPercentage / (int)percentagePerSprite;
            return index;
        }
    }
}
