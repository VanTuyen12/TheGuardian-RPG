using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public abstract class SoundCtrl : PoolObj
{
    [SerializeField] protected AudioSource  audioSource;
    public AudioSource AudioSource => audioSource;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAudioSorce();
    }

    protected virtual void LoadAudioSorce()
    {
        if (this.audioSource != null) return;
        this.audioSource = this.GetComponent<AudioSource>();
        Debug.Log(transform.name + " :LoadAudioSorce ",gameObject);
    }
}
