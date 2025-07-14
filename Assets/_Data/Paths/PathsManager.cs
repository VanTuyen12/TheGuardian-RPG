using System.Collections.Generic;
using UnityEngine;

public class PathsManager : Singleton<PathsManager>
{
   [SerializeField]protected List<PathMoving> paths = new List<PathMoving>();
   
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
         PathMoving pathMoving = child.GetComponent<PathMoving>();
         pathMoving.LoadPoint();
         this.paths.Add(pathMoving);
      }
      Debug.Log(transform.name + " :LoadPaths" , gameObject);
   }

   public virtual PathMoving GetPath(int index)
   {
      return this.paths[index];
   }

   public virtual PathMoving GetPath(string pathName)
   {
      foreach (PathMoving path in this.paths)
      {
         if(pathName == path.name) return path;
      }
      return null;
   }
}
