using UnityEngine;

public class SoundSpawnerCtrl : Singleton<SoundSpawnerCtrl>
{
   [SerializeField] protected SoundSpawner soundSp;
   public SoundSpawner SoundSp => soundSp;
   protected override void LoadComponents()
   {
      base.LoadComponents();
      this.LoadSoundSpawner();
   }

   private void LoadSoundSpawner()
   {
      if(soundSp !=  null) return;
      soundSp = GetComponent<SoundSpawner>();
      Debug.Log(transform.name + " :LoadSoundSpawner ", gameObject);
   }
}
