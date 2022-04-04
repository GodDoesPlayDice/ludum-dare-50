using System.Collections.Generic;
using UnityEngine;

namespace __Game.Scripts.UI
{
    public class MobUIController : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private GameObject demandsContainer;
        [SerializeField] private GameObject demandPrefab;

        #endregion

        #region Fields

        private List<DemandController> currentDemands = new List<DemandController>();

        #endregion

        public void CreateDemands(Dictionary<GoodType, int> demands)
        {
            foreach (Transform child in demandsContainer.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (KeyValuePair<GoodType, int> it in demands)
            {
                var instance = Instantiate(demandPrefab, demandsContainer.transform);
                var dc = instance.GetComponent<DemandController>();
                dc.SetProduct(it.Key, it.Value);
                currentDemands.Add(dc);
            }
        }

        public void ChangeDemands(Dictionary<GoodType, int> demands)
        {
            foreach (var it in currentDemands)
            {
                it.SetProduct(it.currentProduct, demands[it.currentProduct]);
            }
        }

        public void ChangeSingleDemand(GoodType type, int count)
        {
            foreach (var it in currentDemands)
            {
                if (it.currentProduct == type)
                {
                    if (count > 0)
                    {
                        it.SetProduct(type, count);
                    }
                    else
                    {
                        it.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}