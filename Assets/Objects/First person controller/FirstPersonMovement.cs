using UnityEngine;
using UnityEngine.Events;

public class FirstPersonMovement : MonoBehaviour
{
    public UnityEvent OnMovement;
    public float speed = 5;
    Vector2 velocity;


    void FixedUpdate()
    {
        velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(velocity.x, 0, velocity.y);

        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.S) ))
        {
            OnMovement.Invoke();
        }
    }
}
