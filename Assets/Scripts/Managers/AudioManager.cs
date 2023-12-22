using Data.Art;
using Managers;
using UnityEngine;

namespace TKK.Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        private void Start()
        {
            ListenEvents();
            EnableMusic();
        }

        private void EnableMusic()
        {
            var targetClip = DataManager<AudioData>.Data.MusicClip;
            Events.OnPlaySoundMusic.Invoke(targetClip);
        }

        private void ListenEvents()
        {
            Events.OnSfxSettingsChanged.AddListener(MuteSfxChannel);
            Events.OnMusicSettingsChanged.AddListener(MuteMusicChannel);
            Events.OnPlaySoundSfx.AddListener(OnPlaySoundSfx);
            Events.OnPlaySoundMusic.AddListener(OnPlayMusicSfx);
        }

        private void OnPlaySoundSfx(AudioClip clip) => sfxSource.PlayOneShot(clip);

        private void OnPlayMusicSfx(AudioClip clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        } 

        private void MuteMusicChannel(bool state)
        {
            musicSource.mute = state;
        }

        private void MuteSfxChannel(bool state)
        {
            sfxSource.mute = state;
        }
    }
}