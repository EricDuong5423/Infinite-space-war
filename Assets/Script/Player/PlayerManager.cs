using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Animator animator;
    public Background backGround;
    public float PlayerSpeed = 2f;
    public ObjectPooler bulletPool;
    public int bulletSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isMoving = false;
        bool isMovingForward = false;
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y += 1;
            animator.SetTrigger("GoUp");
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y -= 1;
            animator.SetTrigger("GoDown");
            isMoving = true;

        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += 1;
            animator.SetTrigger("GoFoward");
            isMoving = true;
            isMovingForward = true;
            backGround.speedScroll = 0.03f;

        }
        if (Input.GetKey(KeyCode.A)) 
        {
            moveDirection.x -= 1;
            animator.SetTrigger("GoBackward");
            isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }

        if (!isMoving)
        {
            animator.SetTrigger("Idle");
        }

        if (!isMovingForward)
        {
            backGround.speedScroll = 0.01f;
        }

        if (moveDirection != Vector3.zero)
        {
            transform.position += moveDirection.normalized * PlayerSpeed * Time.deltaTime;
            if (transform.position.y >= 4.5f)
            {
                transform.position = new Vector3(transform.position.x, 4.5f, 0);
            }
            else if (transform.position.y <= -4.5f)
            {
                transform.position = new Vector3(transform.position.x, -4.5f, 0);
            }

            if (transform.position.x >= 7.7f)
            {
                transform.position = new Vector3(7.7f, transform.position.y, 0);
            }
            else if (transform.position.x <= -7.7f)
            {
                transform.position = new Vector3(-7.7f, transform.position.y, 0);
            }
        }
    }
    private void ShootBullet()
    {
        Vector2 targetPosition = new Vector2(transform.position.x + 1, transform.position.y);
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        GameObject bullet = bulletPool.GetGameObject();
        bullet.transform.position = transform.position;
        bullet.SetActive(true);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
    }
}
