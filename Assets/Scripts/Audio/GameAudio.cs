using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Audio
{
    public class GameAudio : MonoBehaviour
    {
        [FormerlySerializedAs("raiseSound")] [SerializeField] private AudioSource raiseValueSound;
        [SerializeField] private AudioSource startSound;
        [SerializeField] private AudioSource gameOverSound;
        [SerializeField] private AudioSource winSound;
        [SerializeField] private AudioSource raiseScoreSound;

        public void PlayRaiseValueSound(float timeout)
        {
            StartCoroutine(RiseSoundCoroutine(timeout));
        }
        
        private IEnumerator RiseSoundCoroutine(float timeout)
        {
            yield return new WaitForSeconds(timeout);
            raiseValueSound.Play();

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

        public void PlayRaiseScoreSound()
        {
            raiseScoreSound.Play();
        }
    }
}
