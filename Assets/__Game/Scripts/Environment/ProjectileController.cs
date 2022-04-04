using System;
using __Game.Scripts.Actors;
using UnityEngine;

namespace __Game.Scripts.Environment
{
    public class ProjectileController : MonoBehaviour
    {
        public GoodType productSO;

        private float liveTime = 0;
        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.TryGetComponent<MobController>(out var mobController);
            if (mobController != null && mobController.productsRequire.ContainsKey(productSO))
            {
                mobController.GiveProduct(productSO, 1);
                Destroy(gameObject);
            }
        }
        

        private void FixedUpdate()
        {
            if (transform.position.y <= -2) Destroy(gameObject);
            liveTime += Time.fixedDeltaTime;
            if (liveTime > 2 ) Destroy(gameObject);
        }
    }
}