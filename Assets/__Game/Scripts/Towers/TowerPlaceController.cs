using __Game.Scripts.Interfaces;
using UnityEngine;

namespace __Game.Scripts.Towers
{
    public class TowerPlaceController : MonoBehaviour, IInteractable
    {
        public InteractableType InteractableType { get; set; } = InteractableType.TowerPlace;

        public void OnPointerEnter()
        {
        }

        public void OnPointerExit()
        {
            
        }
        public void Interact(Vector3? atPosition)
        {
            
        }
    }
}