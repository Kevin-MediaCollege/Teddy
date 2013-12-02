using UnityEngine;
using System.Collections;

public class ScoreManager:MonoBehaviour {
	public float score;
	public float kills;

	void Start () {
		DontDestroyOnLoad(gameObject);

		score = 0;
		kills = 0;
	}
}
