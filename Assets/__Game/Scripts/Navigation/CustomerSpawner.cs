using System;
using System.Collections;
using System.Collections.Generic;
using __Game.Scripts.Actors;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider))]
public class CustomerSpawner : MonoBehaviour
{
    [Serializable]
    public class CustomerCostHolder
    {
        public GameObject customerPrefab;
        public float cost;
    }

    #region Inspector

    [SerializeField] private float startCost = 1f;
    [SerializeField] private float costDelta = 0.01f;
    [SerializeField] private float minSpawnTime = 0.5f;
    [SerializeField] private float maxSpawnTime = 1f;
    [SerializeField] private BoxCollider endCollider;
    [SerializeField] private CustomerCostHolder[] customersPrefabs;

    #endregion

    #region Fields

    private BoxCollider spawnerCollider;
    private Bounds spawnerBounds;
    private GoodType[] allGoodsTypes;
    private float currentCost;
    private float nextSpawnTime;
    private float difficultyMultiplier = 1f;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        allGoodsTypes = Resources.LoadAll("", typeof(GoodType)) as GoodType[];
        currentCost = startCost;
        spawnerCollider = GetComponent<BoxCollider>();
        spawnerBounds = spawnerCollider.bounds;
        nextSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextSpawnTime <= Time.time)
        {
            SpawnCustomer();
            nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
        }
    }

    private void FixedUpdate()
    {
        currentCost += costDelta;
    }

    private GameObject SpawnCustomer()
    {
        //var customerCost = Random.Range(0f, currentCost);
        var customer = Instantiate(customersPrefabs[0].customerPrefab, CalcCustomerPosition(), Quaternion.identity);
        PrepareCustomer(customer);
        return customer;
    }

    // consider of previous positions?
    private Vector3 CalcCustomerPosition()
    {
        return new Vector3(Random.Range(spawnerBounds.min.x, spawnerBounds.max.x), 0f,
            Random.Range(spawnerBounds.min.z, spawnerBounds.max.z));
    }

    private CharacterMovement PrepareCustomer(GameObject customer)
    {
        var result = customer.GetComponent<CharacterMovement>();
        var bounds = endCollider.bounds;
        result.target = new Vector3(Random.Range(bounds.min.x, bounds.max.x), 0f,
            Random.Range(bounds.min.z, bounds.max.z));
        return result;
    }
    
}