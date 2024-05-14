using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace SpotTheDifference
{
    public class SoundManager : MonoBehaviour, IBehaviour
    {
        [Header("Click Audio Config")]
        [SerializeField] private AudioSource clickAudioSource;
        [SerializeField] private List<AudioClip> clickSounds;
        
        [Header("Effects Config")]
        [SerializeField] private AudioSource gameEffectsAudioSource;
        [SerializeField] private List<AudioClip> gameEffectsSounds;
        
        [Header("Game State Audio Config")]
        [SerializeField] private AudioSource gameStateAudioSource;
        [SerializeField] private List<AudioClip> gameStateSounds;
        
        public void Initialize() {}

        public void PlayClickSound(ClickSound clickSound)
        {
            clickAudioSource.clip = clickSounds[(int)clickSound];
            clickAudioSource.Play();
        }
        
        public void PlayGameEffectsSound(GameEffects gameEffect)
        {
            gameEffectsAudioSource.clip = gameEffectsSounds[(int)gameEffect];
            gameEffectsAudioSource.Play();
        }

        public void PlayGameStateSound(GameStateSound gameStateSound)
        {
            gameStateAudioSource.clip = gameStateSounds[(int)gameStateSound];
            gameStateAudioSource.Play();
        }
    }
}
