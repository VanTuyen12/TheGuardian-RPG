using UnityEngine;

public class ItemDropManager : Singleton<ItemDropManager>
{
    [SerializeField] protected ItemDropSpawner spawner;
    public ItemDropSpawner Spawner => spawner;
    private float spawnHeight = 1f;
    private float forceAmount = 3f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDropSpawner();
    }

    protected virtual void LoadItemDropSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<ItemDropSpawner>();
        Debug.Log(transform.name + ":LoadItemDropSpawner", gameObject);
    }

    public virtual void Drop(ItemCode itemCode, int dropCoint, Vector3 dropPosition)
    {
        Vector3 spawnPosition = dropPosition + new Vector3(Random.Range(-2, 2), spawnHeight, Random.Range(-2, 2));
        ItemDropCtrl itemPrefab = spawner.PoolPrefabs.GetByName("Gold");
        
        ItemDropCtrl newItem = spawner.Spawn(itemPrefab, spawnPosition);
        newItem.gameObject.SetActive(true);
        
        Vector3 rdDirection = Random.onUnitSphere;
        rdDirection.y = Mathf.Abs(rdDirection.y);
        newItem.Rigidbody.AddForce(rdDirection * forceAmount,ForceMode.Impulse);
            
    }
}