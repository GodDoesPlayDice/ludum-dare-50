using System;
using System.Collections.Generic;
using __Game.Scripts.UI;
using UnityEngine;

namespace __Game.Scripts.Actors
{
    [RequireComponent(typeof(MobUIController))]
    public class MobController : MonoBehaviour
    {
        #region Inspector

        public string identifier;

        #endregion
        
        #region Fields

        public Dictionary<GoodType, int> productsRequire { get; private set; }

        private MobUIController uiController;

        #endregion

        
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            uiController = GetComponent<MobUIController>();
        }

        public bool GiveProduct(GoodType type, int count)
        {
            if (productsRequire.ContainsKey(type) && productsRequire[type] > 0)
            {
                var requireLeft = productsRequire[type] - count;
                if (requireLeft > 0)
                {
                    productsRequire[type] = requireLeft;
                }
                else
                {
                    productsRequire.Remove(type);
                }
                uiController.ChangeSingleDemand(type, requireLeft);
                return true;
            }

            return false;
        }

        public void SetDemands(Dictionary<GoodType, int> demands)
        {
            if (uiController == null)
            {
                Init();
            }
            productsRequire = demands;
            uiController.CreateDemands(demands);
        }
    }
}