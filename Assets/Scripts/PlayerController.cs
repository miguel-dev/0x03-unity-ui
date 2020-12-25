using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rigidBody;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        speed = 700f;
        score = 0;
    }

    // Update is called once per frame
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
            Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        }
    }
}