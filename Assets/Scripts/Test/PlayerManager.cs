using SaveSystem;
using UnityEngine;

namespace Test
{
    public class PlayerManager : MonoBehaviour
    {
        private const string PLAYER_ONE_KEY = "player1";
        private const string PLAYER_TWO_KEY = "player2";
        
        [SerializeField] private Player _player1;
        [SerializeField] private Player _player2;
        
        private void Start()
        {
            if (!GameSaveUtility.LoadObject(PLAYER_ONE_KEY,out _player1))
                _player1 = new Player(PLAYER_ONE_KEY);
            
            if (!GameSaveUtility.LoadObject(PLAYER_TWO_KEY,out _player2))
                _player2 = new Player(PLAYER_TWO_KEY);
        }

        private void OnDestroy()
        {
            GameSaveUtility.SaveObject(PLAYER_ONE_KEY,_player1);
            GameSaveUtility.SaveObject(PLAYER_TWO_KEY,_player2);
        }
    }
}