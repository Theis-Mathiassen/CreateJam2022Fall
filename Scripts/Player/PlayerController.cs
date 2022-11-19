using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public SteamPowerBar steamPowerBar;
    private Rigidbody2D rb;
    void Awake(){
        
    }

    private float moveAxis = 0;


    //Jump
    public float JumpPower = 15;
    private bool isGrounded = true;

    //Engine power
    private float _EnginePower;
    private float EnginePower {
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
        rb.AddForce(new Vector2(moveAxis * EnginePower * EnginePowerMultiplier * Time.deltaTime, 0));
        EnginePower -= EngineEfficiency;
        steamPowerBar.SetSteamPower(EnginePower);
        //movementInput = movement.action
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
        if (ctx.performed && isGrounded) {
            rb.AddForce(new Vector2(0, JumpPower));
            isGrounded = false;
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        //print("Entered");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        //print("Stayed");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        //print("Exited");
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isGrounded = false;
        }
        //print(isGrounded);
    }

}
