using UnityEngine;

public abstract class EnemyManagerAbstract : MyMonoBehaviour
{
   [SerializeField] protected EnemyManagerCtrl enemyManagerCtrl;
   protected override void LoadComponents()
   {
      base.LoadComponents();
      this.LoadEnemyManager();
   }
   
   protected virtual void LoadEnemyManager()
   {
      if(enemyManagerCtrl != null) return;
      this.enemyManagerCtrl = GetComponentInParent<EnemyManagerCtrl>();
      Debug.Log(transform.name+ " :LoadEnemyManager",gameObject);
   }
}
