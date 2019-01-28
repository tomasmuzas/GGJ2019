using UnityEngine;

namespace Assets.Scripts._2018.UI.Health_Draining_Strategies
{
    public class DestroyStrategy : HealthDrainedStrategy
    {
        public override void HealthDrained(HealthManager manager)
        {
            GameObject.Find("Engine").GetComponent<GameOverWin>().GameWin();
            Destroy(manager.transform.parent.gameObject);
        }
    }
}
