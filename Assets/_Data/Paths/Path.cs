using System.Collections.Generic;
using UnityEngine;

public class Path : MyMonoBehaviour
{
    [SerializeField]public List<Point> points;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoint();
    }

    public virtual void LoadPoint()
    {
        if(this.points.Count > 0) return;
        foreach (Transform child in this.transform)
        {
            Point point = child.GetComponent<Point>();
            point.LoadNextPoint();
            this.points.Add(point);
        }
        Debug.Log(transform.name + " :LoadPaths" , gameObject);
    }

    public virtual Point GetPoint(int index)
    {
        return points[index];
    }
}
