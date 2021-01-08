using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rigidBody;
    private int score;
    public int health;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        speed = 700f;
        score = 0;
        health = 5;
    }

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rigidBody.AddForce(speed * Time.deltaTime, 0 , 0);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rigidBody.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rigidBody.AddForce(0, 0, speed * Time.deltaTime);
        }
        else if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rigidBody.AddForce(0, 0, -speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            score++;
            SetScoreText();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Trap")
        {
            health--;
            Debug.Log($"Health: {health}");
        }
        else if (other.gameObject.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }

    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }
}