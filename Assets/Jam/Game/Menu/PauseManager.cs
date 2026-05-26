using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Jam.Game.Menu
{
    /// <summary>
    /// Singleton that manages pausing behaviour in all gameobjects that require it.
    /// only one of these should exist at any given time, if none exist and one is asked for, it will create one itself.
    /// </summary>
    public class PauseManager : MonoBehaviour
    {
        public bool IsPaused { get; private set; }
        public UnityAction gamePaused;
        public UnityAction gameUnPaused;
        private static PauseManager _Instance;
        public static PauseManager Instance
        {
            get // when something asks for what this variable is, it runs the code in the brackets
            {
                if (_Instance) return _Instance; // if theres already an instance that exists then return that
                else return CreateInstance(); // if there is no instance then create a new one and return that
            }
        }
        // this area of code just manages how this object behaves as a singleton
        #region Singleton Management
        void Awake()
        {
            SingletonCheck(); // make sure we are the only instance of this class
            DontDestroyOnLoad(this.gameObject); // keeps the object when new scenes are loaded
        }

        void SingletonCheck() // check to make sure we are the only instance of this script around, if its a duplicate then it deletes itself
        {
            if (_Instance != null && _Instance != this)
            {
                Debug.LogError($"Duplicate PauseManager instance found on object {this.gameObject.name}, destroying duplicate instance.");
                Destroy(this.gameObject);
            }
            else
            {
                _Instance = this;
            }
        }

        void OnDestroy() // when this object is destroyed it has to set the static instance to be null or else it will contain a refrence to a destroyed object
        {
            if (this == _Instance)
            {
                Debug.Log($"Current PauseManager instance is being destroyed on object {this.gameObject.name}.");
                _Instance = null;
            }
        }

        /// <summary>
        /// Creates a new pause manager and returns it
        /// </summary>
        private static PauseManager CreateInstance()
        {
            GameObject obj = new("Pause Manager");
            var pm = obj.AddComponent<PauseManager>();
            pm.SingletonCheck();
            Debug.Log($"Created PauseManager instance");
            return _Instance;
        }
        #endregion

        public void PauseGame()
        {
            if (IsPaused) return;

            IsPaused = true;
            Time.timeScale = 0;
            gamePaused.Invoke();
        }

        public void UnPauseGame()
        {
            if (!IsPaused) return;

            IsPaused = false;
            Time.timeScale = 1;
            gameUnPaused.Invoke();
        }

        public void TogglePause()
        {
            if (IsPaused) UnPauseGame();
            else PauseGame();
        }
    }
}
