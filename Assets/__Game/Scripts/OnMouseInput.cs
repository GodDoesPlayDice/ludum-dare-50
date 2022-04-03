using System;
using __Game.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace __Game.Scripts
{
    public class OnMouseInput : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private IInteractable interactableController;

        private void Awake()
        {
            interactableController = GetComponent<IInteractable>();
        }

        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            interactableController?.ToBeingPointedMode();
        }

        public void OnPointerExit(PointerEventData pointerEventData)
        {
            interactableController?.ToNotBeingPointedMode();
        }

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            interactableController?.Interact(pointerEventData.position);
        }
    }
}