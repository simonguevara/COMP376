using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerSpeed;

    private Rigidbody2D playerRigidBody2D;
    private SpriteRenderer mSpriteRenderer;
    private Animator mAnimator;

     // Invincibility timer
    float kInvincibilityDuration = 1.0f;
    float mInvincibleTimer;
    bool mInvincible;

    // Damage effects
    float kDamagePushForce = 1.5f;

   

    private bool mMoving;
    private bool mVertical;
    private bool mUp;
    private bool mHorizontal;

    void Start()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
        mSpriteRenderer = GetComponent<SpriteRenderer>();
      
    }

    void Update()
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

         if(mInvincible)
        {
            mInvincibleTimer += Time.deltaTime;
            if(mInvincibleTimer >= kInvincibilityDuration)
            {
                mInvincible = false;
                mInvincibleTimer = 0.0f;
            }
        }
        updateAnimator();
    }

      private void FaceDirection(Vector2 direction)
    {
        // Flip the sprite
        mSpriteRenderer.flipX = direction == Vector2.right ? false : true;
    }

      private void updateAnimator(){
          mAnimator.SetBool("Vertical", mVertical);
          mAnimator.SetBool("Horizontal", mHorizontal);
          mAnimator.SetBool("Up", mUp);
      } 

      public void TakeDamage(int dmg)
    {
        if(!mInvincible)
        {           
            Vector2 forceDirection = new Vector2(Vector2.left.x, 1.0f) * kDamagePushForce;
            playerRigidBody2D.velocity = Vector2.zero;
            playerRigidBody2D.AddForce(forceDirection, ForceMode2D.Impulse);
            mInvincible = true;
            Health h = GetComponent<Health>();
            h.DamagePlayer(dmg);
             Debug.Log("Hit");
        }
    }
    
       

    private void SetAnimatorToIdle()
    {
        mAnimator.SetBool("isMovingLeft", false);
        mAnimator.SetBool("isMovingUp", false);
        mAnimator.SetBool("isMovingDown", false);
    }
}
