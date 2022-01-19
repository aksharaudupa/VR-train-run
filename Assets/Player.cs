using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public Camera gameCamera;
	public TextMesh scoreText;
	public float speed = 1f;
    public bool isDead = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3 (
			gameCamera.transform.forward.x,
			0,
			gameCamera.transform.forward.z
		);

		if (gameCamera.transform.forward.z < 0) {
			direction = Vector3.zero;
		}

		transform.position += direction.normalized * speed * Time.deltaTime;

		if (transform.position.x < -1.75f) {
			transform.position = new Vector3 (-1.75f, transform.position.y, transform.position.z);
		} else if (transform.position.x > 1.75f) {
			transform.position = new Vector3 (1.75f, transform.position.y, transform.position.z);
		}
        if(!isDead)
		    scoreText.text = "Score: " + Mathf.FloorToInt(transform.position.z);
	}

	void OnTriggerEnter (Collider otherCollider) {
		if (otherCollider.tag == "Obstacle") {
            isDead = true;
            speed = 0f;
			scoreText.text = "Dead!Score: " + Mathf.FloorToInt(transform.position.z);
			Invoke("reload",5);
		}
	}

	public void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
