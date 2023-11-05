using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace FixedZombieCode
{
    public class ZombieEffectsManager : MonoBehaviour
    {
        public enum Effects
        {
            Poison,
            Fire,
            Water,
            Lightning
        }

        [SerializeField] private List<Zombie> _zombies;
        [SerializeField] private Text _avgZombieHealth;
        
        private Dictionary<int,Zombie> _zombiesEffected;

        private readonly List<int> _keysToRemove = new();

        private readonly StringBuilder _stringBuilder = new StringBuilder();
        
        private bool _poisonActive;
        private int _poisonDamage;
        private float _totalDamage;

        private void Awake()
        {
            _avgZombieHealth ??= GetComponent<Text>();
        }

        public void StartPoisonEffect(int damage)
        {
            _poisonDamage = damage;
            _totalDamage = 0;
            
            _zombiesEffected = new Dictionary<int, Zombie>();
            
            _keysToRemove.Clear();
            
            foreach (Zombie zombie in _zombies)
            {
                if (zombie.ShieldActive) continue;
                
                if (!_zombiesEffected.TryGetValue(zombie.ZombieID, out Zombie existingZombie))
                    _zombiesEffected.Add(zombie.ZombieID, zombie);
            }
            
            _poisonActive = true;
        }

        public void StopPoisonEffect()
        {
            _poisonActive = false;
        }

        void Update()
        {
            if (!_poisonActive) return;
            
            float totalHealth = 0f;
            
            foreach (Zombie zombie in _zombiesEffected.Values)
            {
                float damage = _poisonDamage * Time.deltaTime;

                zombie.Health -= damage;
                _totalDamage += damage;

                if (zombie.Health <= 0)
                {
                    zombie.ShowDeathMessage($"I died from: {Effects.Poison}");
                    _keysToRemove.Add(zombie.ZombieID);
                    Destroy(zombie);//con add object pool to significantly improve performance and memory consumption
                    continue;
                }

                totalHealth += zombie.Health;
            }

            foreach (int key in _keysToRemove)
                _zombiesEffected.Remove(key);

            _keysToRemove.Clear();
            
            float avg = totalHealth / _zombiesEffected.Count;
            
            _stringBuilder.Clear();
            _stringBuilder.Append("Zombies effected: ");
            _stringBuilder.Append(_zombiesEffected.Count);
            _stringBuilder.Append(" Damage: ");
            _stringBuilder.Append(_totalDamage);
            _stringBuilder.Append(" AVG health: ");
            _stringBuilder.Append(avg);
            
            _avgZombieHealth.text = _stringBuilder.ToString();
        }
    }
}