using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerSpeed;

    private SpriteRenderer mSpriteRenderer;
    private Rigidbody2D playerRigidBody2D;

    private Animator mAnimator;

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
         if (mMoving)
        {
            playerRigidBody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * playerSpeed;
            SetDirection(horizontal,vertical);
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
