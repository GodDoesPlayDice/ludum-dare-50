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
            transform.localScale = new Vector3(1, 2f, 1);
        }

        public void ToNotBeingPointedMode()
        {
            transform.localScale = Vector3.one;
        }
        public void Interact(Vector3? atPosition)
        {
            
        }
    }
}