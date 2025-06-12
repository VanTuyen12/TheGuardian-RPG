using UnityEngine;

public class Point : MyMonoBehaviour
{
    [SerializeField] protected Point nextPoint;
    public Point NextPoint => this.nextPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNextPoint();
    }

    public virtual void LoadNextPoint()
    {
        if (nextPoint != null) return;
       
        int siblingIndex = this.transform.GetSiblingIndex();//child[0] 
        if (siblingIndex + 1 < this.transform.parent.childCount)//int sl child
        {
            Transform nextSibling = this.transform.parent.GetChild(siblingIndex + 1);//Child[index]
           this.nextPoint = nextSibling.GetComponent<Point>();
        }
    }
}
