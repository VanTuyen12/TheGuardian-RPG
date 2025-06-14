using UnityEngine;

public abstract class TowerAbstract : MyMonoBehaviour
{
    [SerializeField] protected TowerCtrl towerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }

    protected virtual void LoadTowerCtrl()
    {
        if(this.towerCtrl != null) return;
        towerCtrl = this.transform.parent.GetComponent<TowerCtrl>();
        Debug.Log(transform.name + " :LoadTowerCtrl",gameObject);
    }
}
