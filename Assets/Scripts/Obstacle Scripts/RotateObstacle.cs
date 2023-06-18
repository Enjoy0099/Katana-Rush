using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 300f;

    [SerializeField] private bool X, Y, Z;

    [SerializeField] private float minXRotation = -0.60f, maxXRotation = 0.60f;

    private float zAngle;

    private void Awake()
    {
        rotateSpeed = Random.Range(300, 400);     

        if (X)
        {
            rotateSpeed = Random.Range(100, 200);
        }

        if (Random.Range(0, 2) > 0)
            rotateSpeed *= -1;
    }

    private void Update()
    {
        if(X)
        {

            zAngle += Time.deltaTime * rotateSpeed;

            if (transform.rotation.x < minXRotation)
            {
                rotateSpeed = Mathf.Abs(rotateSpeed);
            }

            if (transform.rotation.x > maxXRotation)
            {
                rotateSpeed = -Mathf.Abs(rotateSpeed);
            }

            transform.rotation = Quaternion.AngleAxis(zAngle, new Vector3(zAngle, transform.rotation.y, transform.rotation.z));
        }

        if (Y)
        {
            zAngle += Time.deltaTime * rotateSpeed;

            transform.rotation = Quaternion.AngleAxis(zAngle, Vector3.up);
        }

        if (Z)
        {
            zAngle += Time.deltaTime * rotateSpeed;

            transform.rotation = Quaternion.AngleAxis(zAngle, Vector3.forward);
        }

    }
}
