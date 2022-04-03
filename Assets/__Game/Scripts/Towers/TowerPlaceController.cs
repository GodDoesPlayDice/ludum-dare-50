using __Game.Scripts.Interfaces;
using UnityEngine;

namespace __Game.Scripts.Towers
{
    public class TowerPlaceController : MonoBehaviour, IInteractable
    {
        public InteractableType InteractableType { get; set; } = InteractableType.TowerPlace;
        public bool IsBeingPointed { get; set; } = false;
        public void ToBeingPointedMode()
        {
        }

        public void ToNotBeingPointedMode()
        {
            
        }
        public void Interact(Vector3? atPosition)
        {
            
        }
    }
}