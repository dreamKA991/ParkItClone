using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup audioMixerGroup;
    [SerializeField] AudioSource winSound;
    [SerializeField] AudioSource loseSound;
    [SerializeField] AudioSource backgroundCitySound;
    [SerializeField] AudioSource backgroundMusicSound;
    [SerializeField] AudioSource liftSound;

    public void PlayWinSounds() => winSound.Play();
    public void PlayLoseSounds() => loseSound.Play();
    private void SetVolume(float value, string name) => 
        audioMixerGroup.audioMixer.SetFloat(name, value);

    public void SetMasterVolume(float value) => SetVolume(value, "MasterVolume");
    public void SetEffectsVolume(float value) => SetVolume(value, "EffectsVolume");
    public void SetMusicVolume(float value) => SetVolume(value, "MusicVolume");
    public void SetBackgroundVolume(float value) => SetVolume(value, "BackgroundVolume");
}
