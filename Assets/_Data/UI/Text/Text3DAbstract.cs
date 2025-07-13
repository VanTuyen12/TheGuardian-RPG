using TMPro;
using UnityEngine;

public abstract class Text3DAbstract : MyMonoBehaviour
{
    [SerializeField] protected TextMeshPro textMeshPro;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextMeshPro();
    }

    protected virtual void LoadTextMeshPro()
    {
        if (this.textMeshPro != null) return;
        textMeshPro = GetComponent<TextMeshPro>();
        Debug.Log(transform.name + " :LoadTextMeshPro " , gameObject);
    }
}
