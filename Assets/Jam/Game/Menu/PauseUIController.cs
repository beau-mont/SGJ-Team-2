using UnityEngine;
using UnityEngine.InputSystem;
using Jam.Game.Menu;

namespace Jam.Game.Menu
{
    /// <summary>
    /// This script is an example of how to use the PauseManager.
    /// It enables the pauseUI GameObject when the game is paused and disables it when the game is unpaused.
    /// </summary>
    public class PauseUIController : MonoBehaviour
    {
        [SerializeField] private GameObject pauseUI; // the gameobject to toggle on/off when the game is paused/unpaused
        private PauseManager _PM; // a private variable containing a refrence to the current PauseManager singleton instance
        private InputAction pause;

        void Awake()
        {
            _PM = PauseManager.Instance; // get a refrence to the current PauseManager instance

            pause = InputSystem.actions.FindAction("Pause"); // get the input system thingy

            if (_PM.IsPaused) pauseUI.SetActive(true); // check what state the game is in and act accordingly
            else pauseUI.SetActive(false);
        }

        void OnEnable() // subscribe to the UnityActions when enabled
        {
            _PM.gamePaused += EnablePauseUI;
            _PM.gameUnPaused += DisablePauseUI;
        }

        void OnDisable() // un-subscribe from the UnityActions when disabled
        {
            _PM.gamePaused -= EnablePauseUI;
            _PM.gameUnPaused -= DisablePauseUI;
        }

        void Update() // if we press the pause button then toggle the pause state
        {
            if (pause.WasPressedThisFrame()) // move this to a player controller later?
            {
                _PM.TogglePause();
            }
        }

        private void EnablePauseUI()
        {
            pauseUI.SetActive(true);
        }

        private void DisablePauseUI()
        {
            pauseUI.SetActive(false);
        }
    }
}