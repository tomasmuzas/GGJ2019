using System;

using UnityEngine;

namespace Assets.Scripts._2018.UI
{
    public delegate void Event();

    public class Health : MonoBehaviour
    {
        public GameObject[] HealthSprites;
        public GameObject HealthPanel;

        public HealthObjectType Type;

        [SerializeField]
        private int _hp;

        [SerializeField]
        private int _hpMax;

        public int HpMax
        {
            get => _hpMax;
            set => _hpMax = value;
        }

        public event Event OnHealthDrained;

        public void Start()
        {
            _hp = HpMax;
        }

        public void DealDamage(int amount)
        {
            _hp -= amount;
            if (_hp <= 0)
            {
                OnHealthDrained?.Invoke();
            }

            Draw();
        }

        public void Draw()
        {
            //foreach (Transform child in HealthPanel.transform)
            //{
            //    Destroy(child.gameObject);
            //}

            //for (int i = 0; i < _hp; i++)
            //{
            //    Instantiate(HealthSprites[i], HealthPanel.transform);
            //}
        }

        public void AddHealth(int amount)
        {
            if (_hp + amount <= HpMax)
            {
                _hp += amount;
            }

            Draw();
        }
    }
}
