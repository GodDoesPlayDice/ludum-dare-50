using UnityEngine;

namespace __Game.Scripts.Interfaces
{
    public enum InteractableType
    {
        Tower,
        Mob,
        TowerPlace,
    }

    public interface IInteractable
    {
        public void Interact(Vector3? atPosition)
        {
        }

        public void OnPointerEnter()
        {
        }

        public void OnPointerExit()
        {
        }

        public InteractableType InteractableType { get; set; }
    }
}