using UnityEngine;

public class BulletSpawner : Spawner
{
    public virtual Bullet Spawn(Bullet bulletPrefab, Vector3 position)
    {
        Bullet newBullet =Spawn(bulletPrefab);
        newBullet.transform.position = position;

        return newBullet;
    }
    
    public virtual Bullet Spawn(Bullet bulletPrefab)
    {
        Bullet newObject = Instantiate(bulletPrefab);
        newObject.Despawn.SetSpawener(this);
        
        return newObject;
    }  
}
