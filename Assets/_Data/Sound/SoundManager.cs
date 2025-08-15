using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneMusicPair
{
    public string sceneName;
    public SoundName soundName;
}
public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] protected MusicCtrl bgMusic;
    [SerializeField] protected SoundSpawnerCtrl soundSpCtrl;
    public SoundSpawnerCtrl SoundSpCtrl => soundSpCtrl;
    
    [Header("Music LoadScene")]
    [SerializeField]protected List<SceneMusicPair> sceneMusicList  = new List<SceneMusicPair>();
    protected Dictionary<string,MusicCtrl> sceneMusicMap = new Dictionary<string, MusicCtrl>();
    
    [UnityEngine.Range(0f, 1f)]
    [SerializeField] protected float volumeMusic = 0.5f;
    public float VolumeMusic => volumeMusic;

    [UnityEngine.Range(0f, 1f)]
    [SerializeField] protected float volumeSfx = 0.8f;
    public float VolumeSfx => volumeSfx;
    
    [SerializeField] protected List<MusicCtrl> listMusic;
    [SerializeField] protected List<SFXCtrl> listSfx;
    
    private bool isInitialized = false;
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
        if (!isInitialized)
        {
            SetupSceneMusic();
            isInitialized = true;
        }
        
        StartMusicScene();
    }
    
    protected virtual void SetupSceneMusic()
    {
        foreach (var pair in sceneMusicList)
        {
            MusicCtrl musicPrefabs = (MusicCtrl)this.soundSpCtrl.SoundSp.PoolPrefabs.GetByName(pair.soundName.ToString());
            if (musicPrefabs != null && !sceneMusicMap.ContainsKey(pair.sceneName))
            {
                sceneMusicMap.Add(pair.sceneName, musicPrefabs);
            }
        }
    }
    private void ClearNullReferences()
    {
        listMusic.RemoveAll(m => m == null);
        listSfx.RemoveAll(s => s == null);
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

    public virtual void StartMusicScene()
    {
        if (this.soundSpCtrl == null)  return;
        string currentScene = SceneManager.GetActiveScene().name;
        
        StopAllMusic();
       
        if (sceneMusicMap.TryGetValue(currentScene, out MusicCtrl music))
        {

            if (bgMusic != null ) return;
            bgMusic = CreateMusic(music);
            bgMusic.gameObject.SetActive(true);
        }
        
    }
    
    protected virtual void StopAllMusic()
    {
        if (bgMusic != null)
        {
            bgMusic.Despawn.DoDespawn();
            bgMusic = null;
        }
        
        foreach (var music in listMusic)
        {
            if (music != null)
            {
                music.Despawn.DoDespawn();
            }
        }
        listMusic.Clear();
    }
    
    public virtual void ToggleMusic()
    {
        if (this.bgMusic == null)
        {
            this.StartMusicScene();
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
    
    public virtual void PlaySfx(SoundName soundName)
    {
        SFXCtrl sfx = CreateSfx(soundName);
        sfx.AudioSource.volume = this.volumeSfx; 
        sfx.gameObject.SetActive(true);
        sfx.AudioSource.Play();
    }
}
