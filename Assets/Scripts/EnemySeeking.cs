using UnityEngine;
using System.Collections;
using _pathfinding;

public class EnemySeeking:MonoBehaviour {
	public float _walkSpeed;
	public float _runSpeed;

	private Vector3 targetPosition;
	
	private _seeker _seeker;
	private GameObject _player;

	public _path _path;

	private float _nextWaypointDistance = 1;
	private int _currentWaypoint = 0;
	
	public void Start () {
		_seeker = GetComponent<_seeker>();
		_player = GameObject.Find("_player");

		Re_path();
	}
	
	public void On_pathComplete(path $p) {
		if (!p.error) {
			_path = $p;
			_currentWaypoint = 0;
		}
	}
	
	public void FixedUpdate () {
		rigidbody.velocity = Vector3.zero;

		if (_path == null || _currentWaypoint >= _path.vector_path.Count) {
			return;
		}

		if (Vector3.Distance (_player.transform.position, targetPosition) > 1) {
			Re_path();
			return;
		}

		Vector3 dir = (_path.vector_path[_currentWaypoint]-transform.position).normalized;
		dir.z = 0;

		rigidbody.AddForce(dir * _walkSpeed * Time.deltaTime);

		if (Vector3.Distance(transform.position,_path.vector_path[_currentWaypoint]) < _nextWaypointDistance) {
			_currentWaypoint++;
			return;
		}
	}

	public void Re_path() {
		targetPosition = _player.transform.position;
		_seeker.Start_path(transform.position, targetPosition, On_pathComplete);
	}
}