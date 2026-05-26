using UnityEngine;
using Jam.Game.Menu;

namespace Jam.Game.Menu
{
    /// <summary>
    /// This script provides publicly accessible methods that interact with the pause manager.
    /// Use this script for UI buttons to pause/unpause the game as well as interacting with unity events in general.
    /// </summary>
    public class PauseActor : MonoBehaviour
    {
        private PauseManager _PM;

        void Awake()
        {
            _PM = PauseManager.Instance;
        }

        public void PauseGame()
        {
            _PM.PauseGame();
        }

        public void UnPauseGame()
        {
            _PM.UnPauseGame();
        }

        public void TogglePause()
        {
            _PM.TogglePause();
        }
    }
}