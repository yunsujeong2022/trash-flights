using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private GameObject weapon;
    
    [SerializeField]
    private Transform shootTransform;
    
    [SerializeField]
    private float shootInterval = 0.05f;

    private float lastShotTime = 0f;
    // Update is called once per frame
    void Update()
    {
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new Vector3(horizontalInput,verticalInput,0f);
        // transform.position += moveTo *moveSpeed* Time.deltaTime;

        Vector3 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX= Mathf.Clamp(mousePos.x,-2.35f,2.35f);
        transform.position = new Vector3(toX,transform.position.y,transform.position.z);

        Shoot();
    }
    void Shoot(){
        if(Time.time - lastShotTime > shootInterval){

        Instantiate(weapon,shootTransform.position,Quaternion.identity);
        lastShotTime = Time.time;
        }
    }
}
