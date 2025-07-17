using System;
using UnityEngine;

public class MuzzleEffect : MyMonoBehaviour
{
    [SerializeField] protected MuzzleCodeName muzzle;
    

    private void OnEnable()
    {
        SpawnMuzzle();
    }

    protected virtual void SpawnMuzzle()
    {
        if(muzzle == MuzzleCodeName.NoName) return;
        EffectSpawner effectSpawner = EffectSingleton.Instance.Spawner;
        EffectCtrl prefab = effectSpawner.PoolPrefabs.GetByName(muzzle.ToString());
        EffectCtrl newEffect = effectSpawner.Spawn(prefab,transform.position);
       newEffect.gameObject.SetActive(true);
    }
}
