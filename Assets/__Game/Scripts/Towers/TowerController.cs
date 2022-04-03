using __Game.Scripts.Interfaces;
using UnityEngine;

namespace __Game.Scripts.Towers
{
    public class TowerController : MonoBehaviour, IInteractable
    {
        #region Inspector

        public InteractableType InteractableType { get; set; } = InteractableType.Tower;
        public bool IsBeingPointed { get; set; } = false;
        [SerializeField] private GameObject projectile;

        [Header("Combat settings")] [SerializeField]
        private float baseAttackRadius = 3;

        [SerializeField] private float baseAttackRate = 1f;

        #endregion

        #region MonoBehaviour

        public void ToBeingPointedMode()
        {
            transform.localScale = Vector3.one * 2; 
        }

        public void ToNotBeingPointedMode()
        {
            transform.localScale = Vector3.one; 
        }

        public void Interact(Vector3? atPosition)
        {
            Debug.Log("interact with tower");
        }

        #endregion
    }
}