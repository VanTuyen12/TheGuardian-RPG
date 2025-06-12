using System.Collections.Generic;
using UnityEngine;

public class PathsManager : Singleton<PathsManager>
{
   [SerializeField]protected List<Path> paths = new List<Path>();
   
   protected override void LoadComponents()
   {
      base.LoadComponents();
      this.LoadPaths();
   }

   protected virtual void LoadPaths()
   {
      if(this.paths.Count > 0) return;
      foreach (Transform child in this.transform)
      {
         Path path = child.GetComponent<Path>();
         path.LoadPoint();
         this.paths.Add(path);
      }
      Debug.Log(transform.name + " :LoadPaths" , gameObject);
   }

   public virtual Path GetPath(int index)
   {
      return this.paths[index];
   }

   public virtual Path GetPath(string pathName)
   {
      foreach (Path path in this.paths)
      {
         if(pathName == path.name) return path;
      }
      return null;
   }
}
