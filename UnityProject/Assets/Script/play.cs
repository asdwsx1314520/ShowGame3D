using UnityEngine;

public class play : MonoBehaviour
{
    public Rigidbody rig;
    public Joystick joysitck;
    public float speed;

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        float h = joysitck.Horizontal;
        float v = joysitck.Vertical;

        rig.AddForce(-h * speed, 0, -v * speed);
    }
}
