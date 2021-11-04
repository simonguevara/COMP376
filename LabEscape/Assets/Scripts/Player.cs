using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerSpeed;

    private SpriteRenderer mSpriteRenderer;
    private Rigidbody2D playerRigidBody2D;

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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        mMoving = !Mathf.Approximately(horizontal, 0f) || !Mathf.Approximately(vertical, 0f);
         if (mMoving && !mInvincible)
        {
            playerRigidBody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * playerSpeed;
            SetDirection(horizontal,vertical);
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
    

    
    private void SetDirection(float horizontal, float vertical){
        FaceDirection(horizontal < 0f ? Vector2.left : Vector2.right);
        mVertical = false;
        mHorizontal = false;
        mUp = false;
        if(vertical < 0f){
            Debug.Log("Down");
            mVertical = true;
            mUp = false;
        }
        else if(vertical > 0f){
            Debug.Log("Up");
            mVertical = true;
            mUp = true;
        }
        if(horizontal < 0f)
        {
            Debug.Log("Left");
            mHorizontal = true;
        }
        else if(horizontal > 0f){
            Debug.Log("Right");
            mHorizontal = true;
        }
        if(Mathf.Abs(horizontal) > Mathf.Abs(vertical)){
            mUp = false;
        }

    }

    public bool isFlipped(){
        return mSpriteRenderer.flipX;
    }
}
