using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightObject : MonoBehaviour
{
    public Transform trnsObject;
    public Transform trnsBody;
    public Transform trnsShadow;

    public float gravity = -10;
    public Vector2 groundVelocity;
    public float verticalVelocity;
    public bool isGrounded;

    void Update()
    {
        UpdatePosition();
        CheckGroundHit();
    }

    public void Initialize(Vector2 groundVelocity, float verticalVelocity)
    {
        this.groundVelocity = groundVelocity;
        this.verticalVelocity = verticalVelocity;
    }

    void UpdatePosition()
    {
        if (!isGrounded)
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
        trnsBody.position = new Vector3(0, verticalVelocity, 0) * Time.deltaTime;
        trnsObject.position += (Vector3)groundVelocity * Time.deltaTime;
    }

    void CheckGroundHit()
    {
        if (trnsBody.position.y < trnsObject.position.y && !isGrounded)
        {
            trnsBody.position = trnsObject.position;
            isGrounded = true;
        }
    }

}
