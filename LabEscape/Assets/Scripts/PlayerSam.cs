using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSam : MonoBehaviour
{
    [SerializeField] private int playerSpeed;

    private Rigidbody2D playerRigidBody2D;
    private SpriteRenderer mSpriteRenderer;
    private Animator mAnimator;

    // Invincibility timer
    [Header("Hitstun/Invicibility")]
    float kInvincibilityDuration = 1.0f;
    float mInvincibleTimer;
    bool mInvincible;
    bool isStunned = false;
    float hitStunDuration = 0.5f;
    float hitStunTimer;

    // Damage effects
    float kDamagePushForce = 10.0f;

    private bool mMoving;
    private bool mVertical;
    private bool mUp;
    private bool mHorizontal;

    //For gadget aquisition
    private bool hasBoots = true;
    private bool hasShield = true;
    private bool hasGun = true;

    //Energy
    [Header("Energy Settings")]
    public int maxEnergy = 10;
    public int energy = 10;
    public float regenTimeStep = 1.0f;
    public int regenAmount = 1;

    //Boots ability
    [Header("Boosters Settings")]
    public float dashTime = 0.1f;
    public float dashDistance = 3.0f;
    private bool isDashing = false;
    public int dashCost = 1;
    private Vector3 dashDirection;

    //Gun ability
    [Header("Gun Settings")]
    public float shootDelay = 0.2f;
    public GameObject bulletPrefab;
    


    void Start()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
        mSpriteRenderer = GetComponent<SpriteRenderer>();

        //Start energy regen
        InvokeRepeating("energyRegen", 0.0f, regenTimeStep);

    }

    private void Update()
    {
        if (!isStunned)
        {
            checkInputs();
        }

        checkStatus();
    }

    void FixedUpdate()
    {
        if (!isStunned)
        {
            movement();
        }
    }


    private void energyRegen()
    {
        if (energy != maxEnergy)
        {
            energy += regenAmount;
            if (energy > maxEnergy)
            {
                energy = maxEnergy;
            }
        }
    }

    private void checkInputs()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Space input");
            startDash();
        }

        if (Input.GetKeyDown("[1]"))
        {
            Debug.Log("Shoot input");
            shoot();
        }
    }

    private void shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        //TO DO COntroller right joystick for direction  
        newBullet.GetComponent<PlayerBullet>().setDirection(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }

    private void startDash()
    {
        Debug.Log("Start dash");
        //Cant dash while dashing
        if (!isDashing)
        {
            Debug.Log("Actually dashing");
            isDashing = true;
            energy -= dashCost;
            Invoke("stopDashing", dashTime);
            dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }

    private void stopDashing()
    {
        isDashing = false;
    }

    private void checkStatus()
    {
        if (mInvincible)
        {
            mInvincibleTimer += Time.deltaTime;
            if (mInvincibleTimer >= kInvincibilityDuration)
            {
                mInvincible = false;
                mInvincibleTimer = 0.0f;
            }
        }
        if (isStunned)
        {
            hitStunTimer += Time.deltaTime;
            if (hitStunTimer >= hitStunDuration)
            {
                isStunned = false;
                hitStunTimer = 0.0f;
            }
        }
    }

    private void movement()
    {
        //Check for dash movement or normal movement
        if (!isDashing)
        {
            normalMovement();
        }
        else
        {
            dashMovement();
        }
    }

    private void dashMovement()
    {
        playerRigidBody2D.velocity = dashDirection.normalized * dashDistance/dashTime;
    }

    private void normalMovement()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        playerRigidBody2D.velocity = direction.normalized * playerSpeed;

        SetAnimatorToIdle();
        if (direction.x > 0)
        {
            SetAnimatorToIdle();
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            mAnimator.SetBool("isMovingLeft", true);
        }
        else if (direction.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            SetAnimatorToIdle();
            mAnimator.SetBool("isMovingLeft", true);
        }
        if (direction.y > 0)
        {
            SetAnimatorToIdle();
            mAnimator.SetBool("isMovingUp", true);
        }
        else if (direction.y < 0)
        {
            SetAnimatorToIdle();
            mAnimator.SetBool("isMovingDown", true);
        }
    }


    private void FaceDirection(Vector2 direction)
    {
        // Flip the sprite
        mSpriteRenderer.flipX = direction == Vector2.right ? false : true;
    }

    public void TakeDamage(Vector2 direction, int dmg)
    {
        if (!mInvincible || isDashing)
        {
            Vector2 forceDirection = direction * kDamagePushForce;
            playerRigidBody2D.velocity = Vector2.zero;
            playerRigidBody2D.AddForce(forceDirection, ForceMode2D.Impulse);
            mInvincible = true;
            Health h = GetComponent<Health>();
            h.DamagePlayer(dmg);
        }
    }



    private void SetAnimatorToIdle()
    {
        mAnimator.SetBool("isMovingLeft", false);
        mAnimator.SetBool("isMovingUp", false);
        mAnimator.SetBool("isMovingDown", false);
    }


    //Methods for aquiring gadgets
    private void findBoots()
    {
        hasBoots = true;
        //display dialogue or events
    }
    private void getGun()
    {
        hasGun = true;
    }
    private void getShield()
    {

    }
}
