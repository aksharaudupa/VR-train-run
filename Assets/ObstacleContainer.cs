using UnityEngine;
using System.Collections;

public class ObstacleContainer : MonoBehaviour {

	public Player player;
	public GameObject[] obstaclePrefabs;
	public float distanceFromPlayer = 10f;
	public float distanceBetweenSpawns = 4f;

	private float spawnPointer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnPointer < player.transform.position.z) {
			GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
			GameObject newObstacle = Instantiate (obstaclePrefab);

			newObstacle.transform.position = new Vector3 (
				0,
				0,
				player.transform.position.z + distanceFromPlayer
			);

			spawnPointer += distanceBetweenSpawns;
		}
	}
}
