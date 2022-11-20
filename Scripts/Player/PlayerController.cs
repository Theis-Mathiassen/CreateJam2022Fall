using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float SteamProgress;
    public SteamPowerBar steamPowerBar;
    private Rigidbody2D rb;
    void Awake(){
        
    }

    private float moveAxis = 0;

    public bool Finish = false;
    //Jump
    public float JumpPower = 15;
    private bool isGrounded = true;
    private bool CanJump = true;

    //Engine power
    private float _EnginePower;
    public float EnginePower {
        get{
            return _EnginePower;
        } set {
            _EnginePower = Mathf.Clamp(value, 0, 1);
        }
    }
    public float EnginePowerMultiplier = 500;
    //How much power is lost each frame
    public float EngineEfficiency = 0.01f;
    public float AddPowerMultiplier;


    //private Vector2 movementInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Finish == false) {

            rb.AddForce(new Vector2(moveAxis * EnginePower * EnginePowerMultiplier * Time.deltaTime, 0));
            EnginePower -= EngineEfficiency;
            steamPowerBar.SetSteamPower(EnginePower);
            SteamProgress += EnginePower/10;
        //movementInput = movement.action
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            print(rb.velocity);
            rb.velocity.Set(0, 0);
            if (transform.position.y < -3.85) {
                rb.MovePosition(new Vector2(transform.position.x + 0.05f, transform.position.y));
            } else 
            {
                rb.MovePosition(new Vector2(transform.position.x, transform.position.y - 0.1f));
            }
            
        }
        if (SteamProgress > 1) {
            GameObject.Instantiate(Resources.Load<GameObject>("Steam"), transform.position + new Vector3(0.3f,0.4f,0), new Quaternion());
            SteamProgress -= 1f;
        }
    }

    //[SerializeField]
    //private InputActionReference movement;

    public void move (InputAction.CallbackContext context) {
        moveAxis = context.action.ReadValue<float>();
    }

    public void AddPower (InputAction.CallbackContext ctx) {
        if (ctx.performed) {
            EnginePower += AddPowerMultiplier;

        }
    }

    public void Jump (InputAction.CallbackContext ctx) {

        if (ctx.performed && CanJump && (Finish == false)) {
            rb.AddForce(new Vector2(0, JumpPower));
            CanJump = false;
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        //print("Entered");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            CanJump = true;
        }
        
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        //print("Stayed");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            CanJump = true;
        }
        
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        //print("Exited");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        //print(isGrounded);
    }

}
