using __Game.Scripts.Interfaces;
using UnityEngine;

namespace __Game.Scripts.Towers
{
    public class TowerController : MonoBehaviour, IInteractable
    {
        #region Inspector

        public InteractableType InteractableType { get; set; } = InteractableType.Tower;
        [SerializeField] private GameObject projectile;

        [SerializeField] private MeshRenderer attackRadiusMeshRenderer;

        [Header("Combat settings")] [SerializeField]
        private float baseAttackRadius = 3;

        [SerializeField] private float baseAttackRate = 1f;

        #endregion

        #region MonoBehaviour

        public void ToBeingPointedMode()
        {
            attackRadiusMeshRenderer.enabled = true;
        }

        public void ToNotBeingPointedMode()
        {
            attackRadiusMeshRenderer.enabled = false;
        }

        public void Interact(Vector3? atPosition)
        {
            Debug.Log("interact with tower");
        }

        #endregion
    }
}