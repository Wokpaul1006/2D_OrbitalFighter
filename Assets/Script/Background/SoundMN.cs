using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMN : MonoBehaviour
{
    [SerializeField] AudioClip sfxPlayerShoot;
    [SerializeField] AudioClip sfxPlayerExplode;
    [SerializeField] AudioClip sfxGatling;
    [SerializeField] AudioClip sfxMissle;
    [SerializeField] AudioClip sfxMissleExplods;
    [SerializeField] AudioClip sfxAbzalat;
    [SerializeField] AudioClip sfxFlame;
    [SerializeField] AudioClip sfxRocketPods;
    [SerializeField] AudioClip sfxSword;

    [SerializeField] AudioSource sfx;
    [SerializeField] List<AudioClip> clipToPlay = new List<AudioClip>();
    private void Start()
    {
        clipToPlay.Add(sfxPlayerShoot);
        clipToPlay.Add(sfxPlayerExplode);
        clipToPlay.Add(sfxGatling);
        clipToPlay.Add(sfxMissle);
        clipToPlay.Add(sfxMissleExplods);
        clipToPlay.Add(sfxAbzalat);
        clipToPlay.Add(sfxFlame);
        clipToPlay.Add(sfxRocketPods);
        clipToPlay.Add(sfxSword);
    }
    public void OnMuteSFX() => sfx.volume = 0;

    public void OnAllowSFX() => sfx.volume = 1;

    #region PlaySound()
    public void OnDefaultShoot() 
    {
        sfx.clip = clipToPlay[0];
        sfx.Play();
    } 

    public void OnDead()
    {
        sfx.clip = clipToPlay[1];
        sfx.Play();
    }
    public void OnPlayGatling()
    {
        sfx.clip = clipToPlay[2];
        sfx.Play();
    }
    public void OnPlayMissle()
    {
        sfx.clip = clipToPlay[3];
        sfx.Play();
    }
    public void OnPlayMissleExploid()
    {
        sfx.clip = clipToPlay[4];
        sfx.Play();
    }
    public void OnAbzalatShoot()
    {
        sfx.clip = clipToPlay[5];
        sfx.Play();
    }
    public void OnFlame()
    {
        sfx.clip = clipToPlay[6];
        sfx.Play();
    }
    public void OnRocketRelease ()
    {
        sfx.clip = clipToPlay[7];
        sfx.Play();
    }
    public void OnSwordSlash()
    {
        sfx.clip = clipToPlay[8];
        sfx.Play();
    }
    #endregion

}
