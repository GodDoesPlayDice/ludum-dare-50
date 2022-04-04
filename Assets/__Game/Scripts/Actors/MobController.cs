using System.Collections.Generic;
using UnityEngine;

namespace __Game.Scripts.Actors
{
    public class MobController : MonoBehaviour
    {
        #region Fields

        public Dictionary<GoodType, int> productsRequire;

        #endregion

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
                return true;
            }

            return false;
        }
    }
}