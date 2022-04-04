using __Game.Scripts.Towers;
using UnityEngine;

namespace __Game.Scripts.Anim
{
    public class TowerShootAnimEvent : MonoBehaviour
    {
        [SerializeField] private TowerController towerController;

        public void ShootEvent()
        {
            var spawned = Instantiate(towerController.projectile, towerController.shootPoint);
            spawned.GetComponent<Rigidbody>().velocity = towerController.currentShootDir * towerController.projectileSpeed;
        }
    }
}