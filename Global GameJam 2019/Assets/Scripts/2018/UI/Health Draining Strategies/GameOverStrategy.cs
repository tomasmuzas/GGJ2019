﻿using UnityEngine;

namespace Assets.Scripts._2018.UI.Health_Draining_Strategies
{
    public class GameOverStrategy : HealthDrainedStrategy
    {
        public override void HealthDrained(HealthManager manager)
        {
            GameObject.Find("Engine").GetComponent<Darkness>().StartDarkening();
        }
    }
}
