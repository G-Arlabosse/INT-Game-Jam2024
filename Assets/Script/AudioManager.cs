using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] int sfx_volume;
    [SerializeField] int music_volume;
    private AudioSource[] audios;
    private AudioSource music;
    private AudioSource sfx;
    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponentsInChildren<AudioSource>();
        music = audios[0];
        sfx = audios[1];
        StartCoroutine(MusicPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = music_volume;
        sfx.volume = sfx_volume;
    }

    public void PlaySound(int id)
    {
        sfx = audios[id];
        sfx.volume = sfx_volume;
        StartCoroutine(SFXPlayer(sfx));
    }

    IEnumerator SFXPlayer(AudioSource sound)
    {
        sound.Play();
        yield return null;
    }

    IEnumerator MusicPlayer()
    {
        while (true)
        {
        music.Play();
        yield return new WaitForSeconds(240);
        }
    }
}
