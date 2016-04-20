using UnityEngine;
using System.Collections;

public class PlayerEffectSoundManager : MonoBehaviour2 {

    public float jumpVol = 0.06f;
    public float timeToPlayNoohAfterColl = 1f;

    public AudioClip jump;
    public AudioClip coll;
    public AudioClip nooh;

    private AudioSource _audioSource;
    private static PlayerEffectSoundManager _instance;

    public void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayJump() {
        _audioSource.PlayOneShot(jump, jumpVol);
    }

    public void PlayColl() {
        _audioSource.PlayOneShot(coll);
        StartCoroutine(PlayColl2());
    }
    private IEnumerator PlayColl2() {
        yield return new WaitForSeconds(timeToPlayNoohAfterColl);
        _audioSource.PlayOneShot(nooh);
    }

    public static PlayerEffectSoundManager Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<PlayerEffectSoundManager>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
