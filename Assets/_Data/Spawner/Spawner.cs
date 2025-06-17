using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : MyMonoBehaviour where T : PoolObj
{
    //Object Pooling
    private int spawnCount = 0;
    [SerializeField]protected List<T> inPoolObjs = new List<T>();
    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObject = Instantiate(prefab);
        
        return newObject;
    }
    public virtual T Spawn(T prefab, Vector3 position)
    {
        T newBullet = Spawn(prefab);
        newBullet.transform.position = position;

        return newBullet;
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

}
