using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerSam : MonoBehaviour
{
    [SerializeField] private int playerSpeed;
    [SerializeField] private float controllerDeadzone = 0.1f;

    [SerializeField] private bool isController = false;

    private CharacterController CharacterController;
    private PlayerControls playerControls;

    internal void heal(int healValue)
    {
        health += healValue;
        if (health > maxHealth)
            health = maxHealth;
    }

    private PlayerInput playerInput;

    private Vector2 movement = Vector2.zero;
    private Vector2 aim = Vector2.zero;

    private Rigidbody2D playerRigidBody2D;
    private SpriteRenderer mSpriteRenderer;
    private Animator mAnimator;

    //
    String currentInputScheme;

    // Health
    [Header("Health")]
    public int health = 10;
    public int maxHealth = 10;


    // Invincibility timer
    [Header("Hitstun/Invicibility")]
    float kInvincibilityDuration = 1.0f;

    internal void TakeRadiationDamage(int damage)
    {
        health -= damage;
        //Damage feedback
    }

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
    public bool hasBoots = false;
    public bool hasShield = false;
    public bool hasGun = true;
    public bool hasHazmat = false;
    public bool hasEMP = false;
    public bool hasRecall = false;
    public bool hasPortalGun = false;


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
    public bool isRightTriggerPressed = false;

    //Shield ability
    [Header("Shield Settings")]
    public bool isReflecting = false;
    public int shieldEnergyCost = 3;
    public float shieldDuration = 1.5f;
    public GameObject shieldPrefab;

    //EMP ability
    [Header("EMPSettings")]
    public bool isEMPCD = false;
    public int EMPEnergyCost = 3;
    public GameObject EMPPrefab;
    public bool isLeftTriggerPressed = false;

    //Recall ability
    [Header("RecallSettings")]
    public bool isRecalling = false;
    public int recallEnergyCost = 6;
    public GameObject imagePrefab;
    public int numberOfImages = 6;
    public float imageInterval = 0.5f;
    //Working stuff
    private int oldestImageIndex = 0;
    private int oldestImageIndexSnapShot = 0;
    private int recallHealth;
    private GameObject[] imagesArray;
    private GameObject[] imagesArraySnapShot;
    //Animation
    private float timeOnCurrentImage = 0f;
    private float recallAnimationTime = 0.5f;
    private int currentAnimationIndex = 0;

    //Portal ability
    public enum Color
    {
        Red,
        Blue,
        none
    }
    [Header("PortalSettings")]
    private Color lastTeleportedBy = Color.none;
    public GameObject redPortalProjectilePrefab;
    public GameObject bluePortalProjectilePrefab;
    public int portalEnergyCost = 1;


    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();

        //For the recall ability
        setupImagesArray();

        playerRigidBody2D = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
        mSpriteRenderer = GetComponent<SpriteRenderer>();

        //Start energy regen
        InvokeRepeating("energyRegen", 0.0f, regenTimeStep);
        InvokeRepeating("createImage", 0.0f, imageInterval);
    }

    private void setupImagesArray()
    {
        imagesArray = new GameObject[numberOfImages];
        for (int i = 0; i < imagesArray.Length; i++)
        {
            imagesArray[i] = Instantiate(imagePrefab, transform.position, Quaternion.identity);
            imagesArray[i].GetComponent<ImageScript>().hp = 10;
        }
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
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

            animate();
        }

        doMovement();
    }

    private void createImage()
    {
        imagesArray[oldestImageIndex] = Instantiate(imagePrefab, transform.position, Quaternion.identity);
        imagesArray[oldestImageIndex].GetComponent<ImageScript>().hp = health;
        oldestImageIndex = (oldestImageIndex + 1) % numberOfImages;
        if (oldestImageIndex < 0)
            oldestImageIndex += numberOfImages;
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
        currentInputScheme = playerInput.currentControlScheme;

        movement = playerControls.Controls.Movement.ReadValue<Vector2>();
        aim = playerControls.Controls.Aim.ReadValue<Vector2>();

        if (currentInputScheme == "MKB")
        {
            controllerDeadzone = 0;
            aim.y = aim.y - Screen.height / 2;
            aim.x = aim.x - Screen.width / 2;
        }

        if (!isStunned)
        {
            Debug.Log("RT:" + playerControls.Controls.Shoot.triggered);
            Debug.Log("LT:" + playerControls.Controls.EMP.triggered);


            if (playerControls.Controls.Shoot.triggered && !isShootOnCD && (Math.Abs(aim.x) >= controllerDeadzone || Math.Abs(aim.y) >= controllerDeadzone))
            {
                Debug.Log("Pew pew!");
                shoot();
            }

            if (playerControls.Controls.Dash.triggered && hasBoots)
            {
                Debug.Log("Space input");
                startDash();
            }

            if (playerControls.Controls.Shield.triggered && hasShield)
            {
                Debug.Log("Shield");
                shield();
            }

            if (playerControls.Controls.EMP.triggered && !isEMPCD && (Math.Abs(aim.x) >= controllerDeadzone || Math.Abs(aim.y) >= controllerDeadzone) && hasEMP)
            {
                Debug.Log("EMP");
                EMP();
            }

            if (playerControls.Controls.BluePortal.triggered && (Math.Abs(aim.x) >= controllerDeadzone || Math.Abs(aim.y) >= controllerDeadzone) && hasPortalGun)
            {
                Debug.Log("Blue Portal Fired");
                shootBluePortal();
            }

            if (playerControls.Controls.RedPortal.triggered && (Math.Abs(aim.x) >= controllerDeadzone || Math.Abs(aim.y) >= controllerDeadzone) && hasPortalGun)
            {
                Debug.Log("Red Portal Fired");
                shootRedPortal();
            }

        }

        //Can recall out of hitstun
        if (playerControls.Controls.Recall.triggered && !isRecalling && hasRecall)
        {
            Debug.Log("Recall");
            Recall();
        }
    }

    private void shootRedPortal()
    {
        if (energy >= portalEnergyCost)
        {
            energy -= portalEnergyCost;
            GameObject newBullet = Instantiate(redPortalProjectilePrefab, transform.position, Quaternion.identity);
            newBullet.GetComponent<PortalProjectileScript>().setDirection(aim.normalized);
        }
    }

    private void shootBluePortal()
    {
        if (energy >= portalEnergyCost)
        {
            energy -= portalEnergyCost;
            GameObject newBullet = Instantiate(bluePortalProjectilePrefab, transform.position, Quaternion.identity);
            newBullet.GetComponent<PortalProjectileScript>().setDirection(aim.normalized);
            newBullet.GetComponent<PortalProjectileScript>().isRed = false;
        }
    }

    private void Recall()
    {
        if (energy >= recallEnergyCost)
        {
            isRecalling = true;
            energy -= recallEnergyCost;
            TakeDamage(Vector2.zero, 0);
            //Recall animation
            Invoke("CompleteRecall", recallAnimationTime);
            imagesArraySnapShot = imagesArray;
            oldestImageIndexSnapShot = oldestImageIndex;
            recallHealth = imagesArraySnapShot[oldestImageIndex].GetComponent<ImageScript>().hp;
            timeOnCurrentImage = 1f;
            currentAnimationIndex = (oldestImageIndexSnapShot);
        }
    }

    private void CompleteRecall()
    {
        isRecalling = false;
        health = recallHealth;
        //health = imagesArraySnapShot[oldestImageIndexSnapShot].GetComponent<ImageScript>().hp;
        //transform.position = imagesArraySnapShot[oldestImageIndexSnapShot].transform.position;
        //Recall animation stuff, free maovement, still 0.5 sec off invuln
    }

    private void EMP()
    {
        if (energy >= EMPEnergyCost)
        {
            GameObject newEMP = Instantiate(EMPPrefab, transform.position, Quaternion.identity);
            newEMP.GetComponent<EMPScript>().setDirection(aim.normalized);
            energy -= EMPEnergyCost;
            isEMPCD = true;
            Invoke("EMPOffCD", 0.5f);
        }

    }

    private void EMPOffCD()
    {
        isEMPCD = false;
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
        if (isRecalling)
        {
            recallMovement();
        }
        else if (isDashing)
        {
            dashMovement();
        }
        else if (!isStunned)
        {
            normalMovement();
        }
    }

    private void recallMovement()
    {

        timeOnCurrentImage += Time.deltaTime;

        float timePerImage = recallAnimationTime / numberOfImages;

        if (timeOnCurrentImage >= timePerImage)
        {
            currentAnimationIndex = (currentAnimationIndex - 1) % numberOfImages;
            if (currentAnimationIndex < 0)
                currentAnimationIndex += numberOfImages;
            timeOnCurrentImage = 0f;
            playerRigidBody2D.velocity = Vector2.zero;
        }

        transform.position = imagesArraySnapShot[currentAnimationIndex].transform.position;
    }

    private void dashMovement()
    {
        playerRigidBody2D.velocity = dashDirection.normalized * dashDistance / dashTime;
    }

    private void normalMovement()
    {
        //Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Math.Abs(movement.x) >= controllerDeadzone || Math.Abs(movement.y) >= controllerDeadzone)
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
        if (movement.x > controllerDeadzone)
        {
            SetAnimatorToIdle();
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            mAnimator.SetBool("isMovingLeft", true);
        }
        else if (movement.x < -controllerDeadzone)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            SetAnimatorToIdle();
            mAnimator.SetBool("isMovingLeft", true);
        }
        if (movement.y > controllerDeadzone)
        {
            SetAnimatorToIdle();
            mAnimator.SetBool("isMovingUp", true);
        }
        else if (movement.y < -controllerDeadzone)
        {
            SetAnimatorToIdle();
            mAnimator.SetBool("isMovingDown", true);
        }
        mAnimator.SetBool("isDashing", isDashing);
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
            Vector2 forceDirection = direction.normalized * kDamagePushForce;
            playerRigidBody2D.velocity = Vector2.zero;
            playerRigidBody2D.AddForce(forceDirection, ForceMode2D.Impulse);
            Debug.Log("Player bumped");
            mInvincible = true;
            isStunned = true;
            health -= dmg;
        }
    }

    public void teleport(Color color)
    {
        if (lastTeleportedBy == Color.none)
        {
            lastTeleportedBy = color;
            if (lastTeleportedBy == Color.Blue)
            {
                GameObject redPortal = GameObject.FindWithTag("RedPortal");
                transform.position = redPortal.transform.position;
            }
            if (lastTeleportedBy == Color.Red)
            {
                GameObject bluePortal = GameObject.FindWithTag("BluePortal");
                transform.position = bluePortal.transform.position;
            }
        }
    }

    public void exitTeleporterZone(Color color)
    {
        if (color != lastTeleportedBy)
        {
            lastTeleportedBy = Color.none;
        }
    }

    private void SetAnimatorToIdle()
    {
        mAnimator.SetBool("isMovingLeft", false);
        mAnimator.SetBool("isMovingUp", false);
        mAnimator.SetBool("isMovingDown", false);
    }
}
