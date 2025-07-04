using UnityEngine;
using TMPro;
public abstract class TextAbstract : MyMonoBehaviour
{
    [SerializeField]protected TextMeshProUGUI txtCount;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextPro();
    }

    protected virtual void LoadTextPro()
    {
        if (this.txtCount != null) return;
        txtCount = GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + " :LoadTextPro " , gameObject);
    }
}
