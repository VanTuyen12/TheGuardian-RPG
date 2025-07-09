using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : MyMonoBehaviour where T : PoolObj
{
    //Object Pooling
    private int spawnCount = 0;
    [SerializeField]protected PoolHolder poolHolder;
    [SerializeField]protected PoolPrefabs<T> poolPrefabs;
    public PoolPrefabs<T> PoolPrefabs => poolPrefabs;
    [SerializeField]protected List<T> inPoolObjs = new List<T>();
    
    public virtual T Spawn(T prefab, Vector3 position)
    {
        T newPrefab = Spawn(prefab);
        newPrefab.transform.position = position;

        return newPrefab;
    }

    public virtual T Spawn(T prefab)
    {

        T newObject = GetObjFromPool(prefab);

        if (newObject == null)
        {
            newObject = Instantiate(prefab);
            this.spawnCount++;
            UpdateName(prefab.transform, newObject.transform);
           
        }

        if (poolHolder != null) newObject.transform.SetParent(poolHolder.transform);
        
        return newObject;
    }
    
    public virtual void Despawn(Transform prefab)
    {
        Destroy(prefab.gameObject);
    }
    
    public virtual void Despawn(T obj)
    {
        if (obj is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(false);
            AddObjectToPool(obj);
        }
    }

    protected virtual void AddObjectToPool(T obj)
    {
        this.inPoolObjs.Add(obj);
    }
    
    protected virtual void RemoveObjectFromPool(T obj)
    {
        this.inPoolObjs.Remove(obj);
    }
    
    protected virtual void UpdateName(Transform prefab, Transform newObject)
    {
        newObject.name = prefab.name + "_" + this.spawnCount;
    }
    
    protected virtual T GetObjFromPool(T prefab)
    {
        foreach (var inPoolObj in inPoolObjs)
        {
            if (prefab.GetName() == inPoolObj.GetName())
            {
                RemoveObjectFromPool(inPoolObj);
                return inPoolObj;
            }
        }
        return null;
    }
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoolHolder();
        this.LoadPoolPrefabs();
    }

    private void LoadPoolPrefabs()
    {
        if (poolPrefabs != null) return;
        poolPrefabs = GetComponentInChildren<PoolPrefabs<T>>();
        Debug.Log(transform.name + " :LoadPoolPrefabs ", gameObject);
    }

    protected virtual void LoadPoolHolder()
    {
        if(poolHolder != null) return;
        poolHolder = GetComponentInChildren<PoolHolder>() ?? 
                      new GameObject("PoolHolder").AddComponent<PoolHolder>();
        
        if (poolHolder.transform.parent != this.transform)
            poolHolder.transform.SetParent(this.transform);
        Debug.Log(transform.name+ " :LoadPoolHolder", gameObject);
    }
    
}
