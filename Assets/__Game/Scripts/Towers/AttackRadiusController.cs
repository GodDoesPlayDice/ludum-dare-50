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
                towerController.enemiesInAttackRadius.Add(other.gameObject);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<MobController>() != null)
            {
                towerController.enemiesInAttackRadius.Remove(other.gameObject);
            }
        }

        #endregion
    }
}