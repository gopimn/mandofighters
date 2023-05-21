using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.9F;
    private Rigidbody2D characterBody;
    private Vector2 velocity;
    private Vector2 inputMovement;
    // Start is called before the first frame update
        private float updateCount = 0;
    private float fixedUpdateCount = 0;
    private float updateUpdateCountPerSecond;
    private float updateFixedUpdateCountPerSecond;
        void Awake()
    {
        // Uncommenting this will cause framerate to drop to 10 frames per second.
        // This will mean that FixedUpdate is called more often than Update.
        //Application.targetFrameRate = 10;
        StartCoroutine(Loop());
    }
    void Start()
    {
        Debug.Log("Hello World");
        velocity = new Vector2(speed,speed);
        characterBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         updateCount += 1;
        // if (characterBody.position.x > 0f)
        // {
        //     Debug.Log("The x value is greater than 0.");
        // }
        // else if (characterBody.position.x < 0f)
        // {
        //     Debug.Log("The x value is less than 0.");
        // }
        // else
        // {
        //     Debug.Log("The x value is equal to 0.");
        // }
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Debug.Log("spacedown");
        //     velocity = new Vector2(speed,speed); 
        //     inputMovement = new Vector2(
        //         Input.GetAxisRaw("Horizontal"),
        //         -1.0f
        //     );       
        // }
        // else if (Input.GetKeyUp(KeyCode.Space))
        // {
        //     Debug.Log("spaceup");
        //     velocity = new Vector2(speed,14f); 
        //     inputMovement = new Vector2(
        //         Input.GetAxisRaw("Horizontal"),
        //         1.0f
        //     );       
        // }
        // else if ((Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.RightArrow)))
        // {
 
        // }
        // else 
        // {
        //     inputMovement = new Vector2(0f, 0f);            
        // }
                    inputMovement = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            );
    }


    private void FixedUpdate()
    {
        fixedUpdateCount += 1;
        Vector2 delta = inputMovement * velocity * Time.deltaTime;
        Vector2 newPosition = characterBody.position + delta;
        characterBody.MovePosition(newPosition);
    }
    // void LateUpdate()
    // {
    //     transform.Translate(0, Time.deltaTime, 0);
    // }
        // Show the number of calls to both messages.
    void OnGUI()
    {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 24;
        GUI.Label(new Rect(20, 20, 200, 50), "Update: " + updateUpdateCountPerSecond.ToString(), fontSize);
        GUI.Label(new Rect(20, 50, 200, 50), "FixedUpdate: " + updateFixedUpdateCountPerSecond.ToString(), fontSize);
            GUI.Label(new Rect(20, 80, 200, 50), "x: " + characterBody.position.x, fontSize);
        GUI.Label(new Rect(20, 110, 200, 50), "y: " + characterBody.position.y, fontSize);
    }
        // Update both CountsPerSecond values every second.
    IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            updateUpdateCountPerSecond = updateCount;
            updateFixedUpdateCountPerSecond = fixedUpdateCount;
            updateCount = 0;
            fixedUpdateCount = 0;
        }
    }
}
