using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerSam : MonoBehaviour
{
    [SerializeField] private int playerSpeed;
    [SerializeField] private float controllerDeadzone = 0.1f;
    [SerializeField] private float gamepadRotateSmoothing = 1000f;

    [SerializeField] private bool isController = false;

    private CharacterController CharacterController;
    private PlayerControls playerControls;
    private PlayerInput playerInput;

    private Vector2 movement = Vector2.zero;
    private Vector2 aim = Vector2.zero;

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
    [Header("Gadget Unlock")]
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
    private bool isShootOnCD = false;
    public bool isTriggerPressed = false;

    //Shield ability
    [Header("Shield Settings")]
    public bool isReflecting = false;
    public int shieldEnergyCost = 3;
    public float shieldDuration = 1.5f;
    public GameObject shieldPrefab;

    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();

        //For the recall ability
        setupImagesArray();
    }

    private void setupImagesArray()
    {
        //throw new NotImplementedException();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

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
        checkInputs();

        checkStatus();
    }

    void FixedUpdate()
    {
        if (!isStunned)
        {
            doMovement();
            animate();
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
        movement = playerControls.Controls.Movement.ReadValue<Vector2>();
        aim = playerControls.Controls.Aim.ReadValue<Vector2>();


        //Trigger status
        if (playerControls.Controls.Shoot.triggered && isTriggerPressed)
            isTriggerPressed = false;
        if(playerControls.Controls.Shoot.triggered && !isTriggerPressed)
            isTriggerPressed = true;

        //Debug.Log("playerControls.Controls.Shoot.triggered");

        if (!isStunned)
        {
            if (isTriggerPressed && !isShootOnCD  && (Math.Abs(aim.x) >= controllerDeadzone || Math.Abs(aim.y) >= controllerDeadzone))
            {
                Debug.Log("Pew pew!");
                shoot();
            }

            if (playerControls.Controls.Dash.triggered)
            {
                Debug.Log("Space input");
                startDash();
            }

            if (playerControls.Controls.Shield.triggered)
            {
                Debug.Log("Space input");
                shield();
            }
        }
        
    }

    private void shield()
    {
        if (!isReflecting && energy >= shieldEnergyCost)
        {
            isReflecting = true;
            Invoke("stopShielding", shieldDuration);
            GameObject shield = Instantiate(shieldPrefab, transform.position + new Vector3(0.0f, 0.01f, 0.0f), Quaternion.identity);
            shield.GetComponent<ShieldScript>().setTimer(shieldDuration);
            energy -= shieldEnergyCost;

        }
    }

    private void stopShielding()
    {
        isReflecting = false;
    }

    private void shoot()
    {
        isShootOnCD = true;
        Invoke("shootOffCooldown", shootDelay);
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        //TO DO COntroller right joystick for direction  
        newBullet.GetComponent<PlayerBullet>().setDirection(aim.normalized);
        
    }

    private void shootOffCooldown()
    {
        isShootOnCD = false;
    }

    private void startDash()
    {
        Debug.Log("Start dash");
        //Cant dash while dashing
        if (!isDashing && energy >= dashCost)
        {
            Debug.Log("Actually dashing");
            isDashing = true;
            energy -= dashCost;
            Invoke("stopDashing", dashTime);
            dashDirection = movement;
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

    private void doMovement()
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
        //Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(Math.Abs(movement.x) >= controllerDeadzone || Math.Abs(movement.y) >= controllerDeadzone)
        {
            playerRigidBody2D.velocity = movement * playerSpeed;
        }
        else
        {
            playerRigidBody2D.velocity = Vector2.zero;
        }
        
    }

    private void animate()
    {
        SetAnimatorToIdle();
        //Debug.Log("aim:"+aim);
        if (Math.Abs(aim.x) > controllerDeadzone)
        {
            SetAnimatorToIdle();
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            mAnimator.SetBool("isMovingLeft", true);
        }
        else if (Math.Abs(aim.x) < controllerDeadzone)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            SetAnimatorToIdle();
            mAnimator.SetBool("isMovingLeft", true);
        }
        if (Math.Abs(aim.y) > controllerDeadzone)
        {
            SetAnimatorToIdle();
            mAnimator.SetBool("isMovingUp", true);
        }
        else if (Math.Abs(aim.y) < controllerDeadzone)
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
            //Health h = GetComponent<Health>();
            //h.DamagePlayer(dmg);
        }
    }



    private void SetAnimatorToIdle()
    {
        mAnimator.SetBool("isMovingLeft", false);
        mAnimator.SetBool("isMovingUp", false);
        mAnimator.SetBool("isMovingDown", false);
    }


    //Methods for aquiring gadgets
    private void getBoots()
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
        hasShield = true;
    }
}
