using UnityEngine;
using System.Collections;

public class MoveXHorizontalPipeB : MonoBehaviour {

    private float _xToStop;

	void Start () {
        _xToStop = PipesSettings.Instance.upHorizontalPipe.localPosition.x;
    }
	
	void Update () {
        if( transform.position.x > _xToStop) {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * ScenariosManager.Instance.Vel, transform.position.y);
            if(transform.position.x < _xToStop) {
                transform.position = new Vector3(_xToStop, transform.position.y);
                GameStorer.Instance.GameController.Invoke(GameEvent.HORIZONTAL_PIPE_COMPLETLY_VISIBLE);
            }
        }
    }
}
