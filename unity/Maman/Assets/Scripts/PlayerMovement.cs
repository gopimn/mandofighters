using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D characterBody;
    private Animator anim;
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
        Debug.Log("What up bitches!");
        characterBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        updateCount += 1;
        float dirX = Input.GetAxis("Horizontal");
        characterBody.velocity = new Vector2(dirX * 7f, characterBody.velocity.y);
        if (Input.GetButtonDown("Jump"))
            {
                characterBody.velocity = new Vector2(characterBody.velocity.x, 5f);
            }
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }
    }


    private void FixedUpdate()
    {
        fixedUpdateCount += 1;
    }
    // void LateUpdate()
    // {
    //     transform.Translate(0, Time.deltaTime, 0);
    // }
        
    void OnGUI()
    {
        // Show the number of calls to both messages.
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 24;
        GUI.Label(new Rect(20, 20, 200, 50), "Update: " + updateUpdateCountPerSecond.ToString(), fontSize);
        GUI.Label(new Rect(20, 50, 200, 50), "FixedUpdate: " + updateFixedUpdateCountPerSecond.ToString(), fontSize);
            GUI.Label(new Rect(20, 80, 200, 50), "x: " + characterBody.position.x, fontSize);
        GUI.Label(new Rect(20, 110, 200, 50), "y: " + characterBody.position.y, fontSize);
    }
    IEnumerator Loop()
    {
        // Update both CountsPerSecond values every second.
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
