using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class FPcam : MonoBehaviour
{
    
    public float cameraSensitivity = 90f;
    
    public float climbSpeed = 4f;
    public float normalMoveSpeed = 5f;
    public float slowMoveFactor = 0.25f;
    public float fastMoveFactor = 3f;
    public float shiftSpeedLerp = 5f;

    private float rotationX;
    private float rotationY;

    private GameManager gameManager;
    private Player player;
    private Options options;
    
    Quaternion rot = new Quaternion(0f, 0.40120f, 0f, 0f);




    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        TryGetComponent(out Player _player);
        player = _player;

        options = GameObject.Find("GameManager").GetComponent<GameManager>().GetComponentInChildren<Options>();

        //transform.rotation = rot;

    }



   

    private void PlayerSettings()
    {
        cameraSensitivity = options.sensitivitySliderValue;
        normalMoveSpeed = options.moveSpeedSliderValue;
    }



    private void Update()
    {
        
        PlayerSettings();
        
       

        this.rotationX += Input.GetAxis("Mouse X") * this.cameraSensitivity * Time.deltaTime;
        this.rotationY -= Input.GetAxis("Mouse Y") * this.cameraSensitivity * Time.deltaTime;
        this.rotationY = Mathf.Clamp(this.rotationY, -90f, 90f);
        this.transform.localRotation = Quaternion.Euler(this.rotationY, this.rotationX, 0f);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


        

        // else if(!player.look) transform.rotation = player.lastRot;

    }

    private void FixedUpdate()
    {
        float targetMoveSpeed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? this.normalMoveSpeed * this.fastMoveFactor : this.normalMoveSpeed;
        float currentMoveSpeed = this.normalMoveSpeed;
        currentMoveSpeed = Mathf.Lerp(currentMoveSpeed, targetMoveSpeed, Time.deltaTime * shiftSpeedLerp);

        float verticalInput = Input.GetAxis("Vertical") * currentMoveSpeed * Time.fixedDeltaTime;
        float horizontalInput = Input.GetAxis("Horizontal") * currentMoveSpeed * Time.fixedDeltaTime;
    
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            this.transform.position -= Vector3.up * this.climbSpeed * Time.fixedDeltaTime;
        }
        else
        {
            this.transform.position += this.transform.forward * verticalInput;
            this.transform.position += this.transform.right * horizontalInput;
        }
    }

    



}
