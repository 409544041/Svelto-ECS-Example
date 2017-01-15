using System;
using Svelto.ECS.Example.Components.Base;
using Svelto.ECS.Example.Components.Damageable;
using UnityEngine;

namespace Svelto.ECS.Example.Implementators.Player
{
    public class PlayerHealth : MonoBehaviour, IHealthComponent, IDamageSoundComponent, IRemoveEntityComponent
    {
        public int startingHealth = 100;                            // The amount of health the player starts the game with.
        public AudioClip deathClip;                                 // The audio clip to play when the player dies.
        public AudioClip damageClip;                                 // The audio clip to play when the player dies.

        int  IHealthComponent.currentHealth   { get { return _currentHealth; } set { _currentHealth = value; } }

        AudioSource IDamageSoundComponent.audioSource   { get { return _playerAudio; } }
        AudioClip   IDamageSoundComponent.death         { get { return deathClip; } }
        AudioClip   IDamageSoundComponent.damage        { get { return damageClip; } }

        public Action removeEntity { get; set; }

        void Awake()
        {
            _playerAudio = GetComponent<AudioSource> ();

            // Set the initial health of the player.
            _currentHealth = startingHealth;
        }

        /// <summary>
        /// I decided to leave this one for compatibility, probably some ugly animation callback.
        /// </summary>
        public void RestartLevel()
        {
            Application.LoadLevel (Application.loadedLevel);
        }

        int                 _currentHealth;
        AudioSource         _playerAudio;                                    // Reference to the AudioSource component.
    }
}
