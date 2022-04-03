using System;
using __Game.Scripts.Actors;
using UnityEngine;

namespace __Game.Scripts.Towers
{
    public class AttackRadiusController : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private TowerController towerController;

        #endregion

        #region MonoBehaviour
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<MobController>() != null)
            {
                towerController.enemies.Add(other.gameObject);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<MobController>() != null)
            {
                towerController.enemies.Remove(other.gameObject);
            }
        }
        
        private void OnTriggerStay(Collider other)
        {
            var obj = other.gameObject;
            if (obj.GetComponent<MobController>() != null && !towerController.enemies.Contains(obj))
            {
                towerController.enemies.Add(obj);
            }
        }

        #endregion
    }
}