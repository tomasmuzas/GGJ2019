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

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "DamageDealer")
            {
                HealthManager.DealDamage(HealthObjectType.Health, 1);
                GetComponent<SpriteRenderer>().sprite = States[GetCurrentSprite()];
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

            var index = (int)HealthManager.GetPercentage(HealthObjectType.Health) / (int)percentagePerSprite;

            return index;

        }
    }
}
