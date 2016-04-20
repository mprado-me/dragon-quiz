using UnityEngine;
using System.Collections;
using System;

public class GameEffectSoundManager : MonoBehaviour2 {

    public float timeToPlayYeahAfterHitQuestion = 0.5f;
    public float timeToPlayNoohAfterMissQuestion = 1.7f;

    public AudioClip hitQuestion;
    public AudioClip hitQuestionYeah;
    public AudioClip missQuestion;
    public AudioClip missQuestionNoooh;
    public AudioClip buttonClick;

    private AudioSource _audioSource;
    private static GameEffectSoundManager _instance;

    public void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayHitQuestion() {
        _audioSource.PlayOneShot(hitQuestion);
        StartCoroutine(PlayHitQuestion2());
    }
    private IEnumerator PlayHitQuestion2() {
        yield return new WaitForSeconds(timeToPlayYeahAfterHitQuestion);
        _audioSource.PlayOneShot(hitQuestionYeah);
    }

    public void PlayMissQuestion() {
        _audioSource.PlayOneShot(missQuestion);
        StartCoroutine(PlayMissQuestion2());
    }
    private IEnumerator PlayMissQuestion2() {
        yield return new WaitForSeconds(timeToPlayNoohAfterMissQuestion);
        _audioSource.PlayOneShot(missQuestionNoooh);
    }

    public void PlayButtonClick() {
        _audioSource.PlayOneShot(buttonClick);
    }

    public static GameEffectSoundManager Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<GameEffectSoundManager>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
