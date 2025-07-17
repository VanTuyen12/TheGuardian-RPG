using UnityEngine;

public class EffectSingleton : Singleton<EffectSingleton>
{
    [SerializeField]  protected EffectSpawner spawner;
    public EffectSpawner Spawner => spawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectSpawner();
    }
    
    protected virtual void LoadEffectSpawner()
    {
        if(this.spawner != null) return;
        spawner =GetComponent<EffectSpawner>();
        Debug.Log(transform.name + " :LoadEffectSpawner",gameObject);
    }
}
