using UnityEngine;

namespace Utility
{
    public class PitchShift : MonoBehaviour
    {
        private AudioSource au;

        private void Start()
        {
            au = GetComponent<AudioSource>();
            au.pitch = Random.Range(0.9f, 1.1f);
            au.Play();
        }
    }
}