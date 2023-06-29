using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerPos;

    [SerializeField] private float offset = 1f;

    private Vector3 tempPos;

    /*private void Awake()
    {
        PlayerRefernece();
    }*/

    public void PlayerRefernece()
    {
        playerPos = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (!playerPos)
            return;

        tempPos = transform.position;
        tempPos.x = playerPos.position.x + offset;
        transform.position = tempPos;
    }
}
