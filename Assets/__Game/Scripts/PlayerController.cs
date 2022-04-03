using __Game.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace __Game.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        #region Ispector

        [SerializeField]

        #endregion

        #region Fields

        private Vector3 mousePosition;
        private Vector3 clickPosInWorld;
        private GameObject clickedObject;

        #endregion
        #region References



        #endregion

        #region MonoBehaviour

                public void OnAim(InputAction.CallbackContext context)
                {
                    var v = context.ReadValue<Vector2>();
                    mousePosition = new Vector3(v.x, v.y, 0f);
                }
        
                public void OnFire(InputAction.CallbackContext context)
                {
                    if (context.performed)
                    {
                        TryToInteract(GetObjectUnderPointer(mousePosition));
                    }
                }
                
                private bool TryToInteract(GameObject obj)
                {
                    var interactableController = obj.GetComponent<IInteractable>();
                    if (interactableController == null) return false;
                    interactableController.Interact(clickPosInWorld);
                    return true;
                }
                
                private GameObject GetObjectUnderPointer(Vector3 mousePosition)
                {
                    if (Camera.main == null) return null;
                    var ray = Camera.main.ScreenPointToRay(mousePosition);
                    if (Physics.Raycast(ray, out var hit))
                    {
                        clickPosInWorld = hit.point;
                        return hit.collider.gameObject;
                    }
                    return null;
                }

        #endregion
    }
}