using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SnakeController : MonoBehaviour {


    public Vector2 direction = Vector2.right;
    public List<Transform> tail = new List<Transform>();
    bool ate = false;
    public GameObject tailPrefab;
    public AudioSource eatSound;
    

	// Use this for initialization
	void Start () {
        InvokeRepeating("Move", 0.10f, 0.10f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow) && direction != Vector2.right)
            direction = Vector2.left;
        else if (Input.GetKey(KeyCode.DownArrow) && direction != Vector2.up)
            direction = Vector2.down;
        else if (Input.GetKey(KeyCode.RightArrow) && direction != Vector2.left)
            direction = Vector2.right;
        else if (Input.GetKey(KeyCode.UpArrow) && direction != Vector2.down)
            direction = Vector2.up;
	}

    void Move()
    {
        Vector2 GapPos = transform.position;
        transform.Translate(direction * 0.1f);

        if (ate)
        {
            GameObject tailClone = Instantiate(tailPrefab, GapPos, Quaternion.identity);
            tail.Insert(0, tailClone.transform);
            ate = false;
        }
        else if (tail.Count > 0)
        {
            tail.Last().position = GapPos;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            ate = true;
            Destroy(collision.gameObject);
            eatSound.Play();

        }
        else if(collision.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
