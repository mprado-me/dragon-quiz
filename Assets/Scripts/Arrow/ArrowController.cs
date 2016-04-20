using UnityEngine;
using System.Collections;

public enum ArrowState {
    SHOWING,
    GOING
}

public class ArrowController : MonoBehaviour2 {

    private ArrowState _state;
    private SpriteRenderer _spriteRenderer;
    private float _delta;

	void Start () {
        _state = ArrowState.SHOWING;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _delta = 0f;
        SetAplha(0f);
    }
	
	void Update () {
        _delta += Time.deltaTime;
        float t;
        switch(_state) {
            case ArrowState.SHOWING:
                t = _delta / ArrowSettings.Instance.timeShowing;
                SetAplha(Mathf.Lerp(0f, 1f, t));
                if( t >= 1f) {
                    _state = ArrowState.GOING;
                    _delta = 0f;
                }
                break;
            case ArrowState.GOING:
                float alpha = transform.localEulerAngles.z*Mathf.Deg2Rad;
                transform.localPosition += ArrowSettings.Instance.vel*Time.deltaTime*(new Vector3(Mathf.Cos(alpha), Mathf.Sin(alpha), 0f));
                t = _delta / ArrowSettings.Instance.timeGoing;
                SetAplha(Mathf.Lerp(1f, ArrowSettings.Instance.finalApha, t));
                if(t >= 1f) {
                    Destroy(gameObject);
                }
                break;
        }
    }

    private void SetAplha(float alpha) {
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, alpha);
    }
}
