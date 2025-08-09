using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] protected SoundName bgName = SoundName.LastStand;
    [SerializeField] protected MusicCtrl bgMusic;
    [SerializeField] protected SoundSpawnerCtrl soundSpCtrl;
    public SoundSpawnerCtrl SoundSpCtrl => soundSpCtrl;

    [Range(0f, 1f)]
    [SerializeField] protected float volumeMusic = 1f;

    [Range(0f, 1f)]
    [SerializeField] protected float volumeSfx = 1f;
    [SerializeField] protected List<MusicCtrl> listMusic;
    [SerializeField] protected List<SFXCtrl> listSfx;

    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadSoundSpawnerCtrl();
        ClearNullReferences();
        StartMusicBackground();
    }
    private void ClearNullReferences()
    {
        listMusic.RemoveAll(m => m == null);
        listSfx.RemoveAll(s => s == null);
    }
    protected override void Start()
    {
        base.Start();
        this.StartMusicBackground();
    }
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSoundSpawnerCtrl();
    }

    protected virtual void LoadSoundSpawnerCtrl()
    {
        if (this.soundSpCtrl != null) return;
        this.soundSpCtrl = FindAnyObjectByType<SoundSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadSoundSpawnerCtrl", gameObject);
    }

    public virtual void StartMusicBackground()
    {
        if (this.soundSpCtrl == null)  return;

        if (this.bgMusic == null)
            this.bgMusic = CreateMusic(this.bgName);

        if (this.bgMusic != null)
            this.bgMusic.gameObject.SetActive(true);
        
    }

    public virtual void ToggleMusic()
    {
        if (this.bgMusic == null)
        {
            this.StartMusicBackground();
            return;
        }

        bool status = this.bgMusic.gameObject.activeSelf;
        this.bgMusic.gameObject.SetActive(!status);
    }

    public virtual MusicCtrl CreateMusic(SoundName soundName)
    {
        MusicCtrl soundPrefab = (MusicCtrl)this.soundSpCtrl.SoundSp.PoolPrefabs.GetByName(soundName.ToString());
        return this.CreateMusic(soundPrefab);
    }

    public virtual MusicCtrl CreateMusic(MusicCtrl musicPrefab)
    {
        MusicCtrl newMusic = (MusicCtrl)this.soundSpCtrl.SoundSp.Spawn(musicPrefab, Vector3.zero);
        this.AddMusic(newMusic);
        return newMusic;
    }

    public virtual void AddMusic(MusicCtrl newMusic)
    {
        if (this.listMusic.Contains(newMusic)) return;
        this.listMusic.Add(newMusic);
    }

    public virtual SFXCtrl CreateSfx(SoundName soundName)
    {
        SFXCtrl soundPrefab = (SFXCtrl)this.soundSpCtrl.SoundSp.PoolPrefabs.GetByName(soundName.ToString());
        return this.CreateSfx(soundPrefab);
    }

    public virtual SFXCtrl CreateSfx(SFXCtrl sfxPrefab)
    {
        SFXCtrl newSound = (SFXCtrl)this.soundSpCtrl.SoundSp.Spawn(sfxPrefab, Vector3.zero);
        this.AddSfx(newSound);
        return newSound;
    }

    public virtual void AddSfx(SFXCtrl newSound)
    {
        if (this.listSfx.Contains(newSound)) return;
        this.listSfx.Add(newSound);
    }

    public virtual void VolumeMusicUpdating(float volume)
    {
        this.volumeMusic = volume;
        foreach(MusicCtrl musicCtrl in this.listMusic)
        {
            musicCtrl.AudioSource.volume = this.volumeMusic;
        }
    }

    public virtual void VolumeSfxUpdating(float volume)
    {
        this.volumeSfx = volume;
        foreach (SFXCtrl sfxCtrl in this.listSfx)
        {
            sfxCtrl.AudioSource.volume = this.volumeSfx;
        }
    }
}
