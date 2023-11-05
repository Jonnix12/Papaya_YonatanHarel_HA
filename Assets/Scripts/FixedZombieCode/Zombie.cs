using UnityEngine;

namespace FixedZombieCode
{
    public class Zombie : MonoBehaviour
    {
        public bool ShieldActive { get; set; }
        public float Health { get; set; }
        
        public int ZombieID { get; private set; }
        
        public void ShowDeathMessage(string s)
        {
        }
    }
}