using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;

public class PlayerMovement : MonoBehaviour
{
    //Gernade
    public GameObject Grenade;
    public Vector2 groundDispenseVelocity;
    public Vector2 verticalDispenseVelocity;

    //where gun shoots from
    public Transform ShootingPoint;

    public float moveSpeed = 5.0f; // Movement speed of the player.
    private Rigidbody2D rb; // Reference to the Rigidbody2D component.
    private Vector2 movement; // The current movement vector.

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Flip the entire GameObject based on the direction of horizontal movement.
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        Shoot();
    }

    // FixedUpdate is called at a fixed interval and is used for physics updates.
    void FixedUpdate()
    {
        // Apply the movement to the Rigidbody2D.
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject insantiatedGrenade = Instantiate(Grenade, ShootingPoint.position, Quaternion.identity);
            insantiatedGrenade.GetComponent<HeightObject>().Initialize(ShootingPoint.right * Random.Range(groundDispenseVelocity.x, groundDispenseVelocity.y), Random.Range(verticalDispenseVelocity.x, verticalDispenseVelocity.y));
        }
    }
}
