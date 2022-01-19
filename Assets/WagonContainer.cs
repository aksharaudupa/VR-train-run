using UnityEngine;
using System.Collections;

public class WagonContainer : MonoBehaviour {

	public Player player;
	public GameObject[] wagons;
	public float offsetLimit = 2.5f;
	public float wagonDistance = 10.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject wagon in wagons) {

			if (player.transform.position.z > wagon.transform.position.z + offsetLimit) {
				wagon.transform.position = new Vector3 (
					wagon.transform.position.x,
					wagon.transform.position.y,
					wagon.transform.position.z + wagonDistance * wagons.Length
				);
			}

		}
	}
}
