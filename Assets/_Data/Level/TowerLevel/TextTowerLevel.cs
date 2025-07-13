using UnityEngine;

public class TextTowerLevel : TextLevel
{
    [SerializeField]protected TowerCtrl towerCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }

    protected virtual void LoadTowerCtrl()
    {
        if (this.towerCtrl != null) return;
        towerCtrl = GetComponentInParent<TowerCtrl>();
        Debug.Log(transform.name + " :LoadTowerCtrl " , gameObject);
    }

    protected override void UpdatingLevel()
    {
        textMeshPro.text = towerCtrl.Level.CurrentLevel.ToString();
    }
}
