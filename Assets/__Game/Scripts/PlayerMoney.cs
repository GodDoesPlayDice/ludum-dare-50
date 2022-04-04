using System;
using UnityEngine;
using UnityEngine.Events;

namespace __Game.Scripts
{
    public class PlayerMoney : MonoBehaviour
    {
        #region Inspector

        [SerializeField] public int startMoney = 1000;

        #endregion

        #region Fields

        public static PlayerMoney Instance { get; private set; }
        public int CurrentMoney { get; private set; } = 0;

        public UnityEvent<int> OnCurrentMoneyChanged;

        #endregion

        #region MonoBehaviour
        private void Awake() 
        { 
            // If there is an instance, and it's not me, delete myself.
    
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            }

            OnCurrentMoneyChanged ??= new UnityEvent<int>();
        }
        private void Start()
        {
            AddMoney(startMoney);
        }

        public void AddMoney(int amount)
        {
            CurrentMoney += amount;
            OnCurrentMoneyChanged.Invoke(CurrentMoney);
        }

        
        #endregion
    }
}