using __Game.Scripts.Towers;
using UnityEngine;

namespace __Game.Scripts.Anim
{
    public class TowerAnimEvents : MonoBehaviour
    {
        [SerializeField] private TowerController towerController;

        public void ShootEvent()
        {
            var spawned = Instantiate(towerController.projectile, towerController.shootPoint.position, Quaternion.identity);
            spawned.GetComponent<Rigidbody>().velocity = towerController.currentShootDir * towerController.projectileSpeed;
        }

        public void DespawnEvent()
        {
            towerController.DespawnTower();
        }
    }
}