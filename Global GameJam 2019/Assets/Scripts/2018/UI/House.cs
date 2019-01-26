using UnityEngine;

namespace Assets.Scripts._2018.UI
{
    public class House : MonoBehaviour
    {
        public Sprite[] States;

        public HealthManager HealthManager;

        public void Start()
        {
            HealthManager = GetComponent<HealthManager>();
        }
    }
}
