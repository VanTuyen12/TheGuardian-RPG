using UnityEngine;

public abstract class Spawner : MyMonoBehaviour
{
    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObject = Instantiate(prefab);
        return newObject;
    }

    public virtual void Despawn(Transform prefab)
    {
        Debug.Log("Despawn" + prefab.name);
        Destroy(prefab.gameObject);
    }
}
