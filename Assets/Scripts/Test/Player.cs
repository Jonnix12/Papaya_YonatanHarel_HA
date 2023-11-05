using SaveSystem;
using UnityEngine;

namespace Test
{
    [System.Serializable]
    public class Player : ISave
    {
        [SerializeField] private string _playerName;
        [SerializeField] private int _playerLevel;
        [SerializeField] private int _playerXP;

        public Player(string playerName)
        {
            _playerLevel = 1;
            _playerName = playerName;
            _playerXP = 0;
        }
    }
}