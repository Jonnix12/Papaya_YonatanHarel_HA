using SaveSystem;
using UnityEngine;

namespace Test
{
    [System.Serializable]
    public class Enemy : ISave
    {
        [SerializeField] private string _enemyName;
        [SerializeField] private int _enemyLevel;

        public Enemy(string enemyName)
        {
            _enemyLevel = 1;
            _enemyName = enemyName;
        }
    }
}