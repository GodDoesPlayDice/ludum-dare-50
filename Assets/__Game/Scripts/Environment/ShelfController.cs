using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace __Game.Scripts.Environment
{
    public class ShelfController : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private Transform productPlacesParent;

        // temp
        public GameObject potato;

        #endregion

        #region Fields

        private List<GameObject> spawnedProducts;

        #endregion

        #region MonoBehaviour

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ChangeProduct(potato);
            }
        }

        public void ChangeProduct(GameObject newProduct)
        {
            spawnedProducts ??= new List<GameObject>();
            if (spawnedProducts.Count > 0)
            {
                foreach (var product in spawnedProducts)
                {
                    Destroy(product);
                }
            }

            foreach (Transform productPlace in productPlacesParent)
            {
                spawnedProducts.Add(Instantiate(newProduct, productPlace.transform.position,
                    productPlace.transform.rotation, productPlace));
            }
        }

        #endregion
    }
}