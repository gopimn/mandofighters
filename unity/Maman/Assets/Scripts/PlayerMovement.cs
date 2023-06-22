using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D characterBody;
    private Animator anim;
    private float dirX = 0f;

    // estos son para el display

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
        dirX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            {
                characterBody.velocity = new Vector2(characterBody.velocity.x, 3f);
                //anim.SetBool("inTheAir", true);
            }
        if (dirX > 0f)
        {
            characterBody.velocity = new Vector2(dirX * 3f, characterBody.velocity.y);
            anim.SetBool("moving", true);
            anim.SetBool("dirRight", true);
            anim.SetBool("dirLeft", false);
        }
        else if (dirX < 0f)
        {
            characterBody.velocity = new Vector2(dirX * 3f, characterBody.velocity.y);
            anim.SetBool("moving", true);
            anim.SetBool("dirLeft", true);
            anim.SetBool("dirRight", false);
        }
        else
        {
            anim.SetBool("moving", false);
        }    }

    private void UpdateAnimationState()
    {

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
        GUI.Label(new Rect(20, 20, 200, 50), "Update:      " + updateUpdateCountPerSecond.ToString(), fontSize);
        GUI.Label(new Rect(20, 50, 200, 50), "FixedUpdate: " + updateFixedUpdateCountPerSecond.ToString(), fontSize);
        GUI.Label(new Rect(20, 80, 200, 50), "x:           " + characterBody.position.x, fontSize);
        GUI.Label(new Rect(20, 110, 200, 50), "y:          " + characterBody.position.y, fontSize);
        GUI.Label(new Rect(20, 140, 200, 50), "moving:     " + anim.GetBool("moving"), fontSize);
        GUI.Label(new Rect(20, 170, 200, 50), "dirRight:   " + anim.GetBool("dirRight"), fontSize);
        GUI.Label(new Rect(20, 1200, 200, 50), "inTheAir:  " + anim.GetBool("inTheAir"), fontSize);
        GUI.Label(new Rect(20, 1500, 200, 50), "dirLeft:   " + anim.GetBool("dirLeft"), fontSize);
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
