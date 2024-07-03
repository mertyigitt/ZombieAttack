using UnityEngine;

namespace ZombieAttack.Controllers
{
    public class SoundController : MonoBehaviour
    {
        AudioSource _audioSource;

        public bool IsPlaying => _audioSource.isPlaying;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        
        public void SetClip(AudioClip audioClip)
        {
            if (audioClip == _audioSource.clip) return;
            
            _audioSource.clip = audioClip;
        }

        public void PlaySound(Vector3 position)
        {
            if (_audioSource.isPlaying) return;
            transform.position = position;
            _audioSource.Play();
        }
    }
}
