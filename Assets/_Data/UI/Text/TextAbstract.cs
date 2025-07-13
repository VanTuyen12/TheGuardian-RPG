using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public abstract class TextAbstract : MyMonoBehaviour
{
    [SerializeField]protected TextMeshProUGUI txtProUi;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextPro();
    }

    protected virtual void LoadTextPro()
    {
        if (this.txtProUi != null) return;
        txtProUi = GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + " :LoadTextPro " , gameObject);
    }
}
