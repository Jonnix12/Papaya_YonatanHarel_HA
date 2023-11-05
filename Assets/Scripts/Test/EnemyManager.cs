using System.Collections.Generic;
using System.Linq;
using SaveSystem;
using UnityEngine;

namespace Test
{
    public class EnemyManager: MonoBehaviour
    {
        private const string ENEMY_LIST_KEY = "enemyList";
        
        [SerializeField] private List<Enemy> _enemies;

        private readonly string[] _namesList = 
        {
            "Ron",
            "Shalom",
            "Yoshi",
        };

        private void Start()
        {
            if (GameSaveUtility.LoadObjects(ENEMY_LIST_KEY, out IEnumerable<Enemy> enemies))
                _enemies = enemies.ToList();
            else
            {
                _enemies = new List<Enemy>();

                for (int i = 0; i < 10; i++)
                    _enemies.Add(new Enemy(_namesList[Random.Range(0, _namesList.Length)]));
            }
        }
        
        [ContextMenu("Delete data")]
        public void DeleteData()=>
            GameSaveUtility.DeleteKey(ENEMY_LIST_KEY);

        private void OnDestroy()
        {
            GameSaveUtility.SaveObjects(ENEMY_LIST_KEY, _enemies);
        }
    }
}