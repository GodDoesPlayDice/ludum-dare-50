using System;
using System.Collections;
using System.Collections.Generic;
using __Game.Scripts.Actors;
using UnityEngine;
using UnityEngine.Rendering;

public class CustomerCache : MonoBehaviour
{
    // #region Inspector
    //
    // [SerializeField] private GameObject[] prefabs;
    //
    // #endregion
    
    #region Fields

    private Dictionary<string, List<GameObject>> instances;

    #endregion

    public void Initialize(GameObject[] prefabs)
    {
        instances = new Dictionary<string, List<GameObject>>();
        
        foreach (var it in prefabs)
        {
            instances.Add(it.GetComponent<MobController>().identifier, new List<GameObject>());
        }
    }

    public GameObject Get(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        var id = prefab.GetComponent<MobController>().identifier;
        if (instances[id].Count > 0)
        {
            var result = instances[id][0];
            instances[id].RemoveAt(0);
            result.transform.position = position;
            result.transform.rotation = rotation;
            result.SetActive(true);
            return result;
        }
        else
        {
            return Instantiate(prefab, position, rotation);
        }
    }

    public void Release(GameObject customer)
    {
        var id = customer.GetComponent<MobController>().identifier;
        instances[id].Add(customer);
        customer.SetActive(false);
    }
}
