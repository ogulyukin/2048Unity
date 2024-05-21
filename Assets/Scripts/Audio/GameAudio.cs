using System.Collections;
using UnityEngine;

namespace Audio
{
    public class GameAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource raiseSound;
        [SerializeField] private AudioSource startSound;
        [SerializeField] private AudioSource gameOverSound;
        [SerializeField] private AudioSource winSound;

        public void PlayRaiseValueSound(float timeout)
        {
            StartCoroutine(RiseSoundCoroutine(timeout));
        }
        
        private IEnumerator RiseSoundCoroutine(float timeout)
        {
            yield return new WaitForSeconds(timeout);
            raiseSound.Play();

        }

        public void PlayStartGameSound()
        {
            startSound.Play();
        }

        public void PlayGameOverSound()
        {
            gameOverSound.Play();
        }

        public void PlayWinSound()
        {
            winSound.Play();
        }
    }
}
