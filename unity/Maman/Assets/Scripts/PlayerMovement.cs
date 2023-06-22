using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D characterBody;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] private float velRate = 3f;
    [SerializeField] private float jumpRate = 3f;
    private float dirX; // input from user (arrows -> <-)

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
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        updateCount += 1;
        dirX = Input.GetAxis("Horizontal");
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (Input.GetButtonDown("Jump"))
            {
                characterBody.velocity = new Vector2(characterBody.velocity.x, jumpRate);
            }
        if (dirX > 0f)
        {
            characterBody.velocity = new Vector2(dirX * velRate, characterBody.velocity.y);
            anim.SetBool("moving", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            characterBody.velocity = new Vector2(dirX * velRate, characterBody.velocity.y);
            anim.SetBool("moving", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("moving", false);
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
        GUI.Label(new Rect(20, 20, 1000, 50), "Update:      " + updateUpdateCountPerSecond.ToString(), fontSize);
        GUI.Label(new Rect(20, 50, 1000, 50), "FixedUpdate: " + updateFixedUpdateCountPerSecond.ToString(), fontSize);
        GUI.Label(new Rect(20, 80, 700, 50), "x:           " + characterBody.position.x, fontSize);
        GUI.Label(new Rect(20, 110, 700, 50), "y:          " + characterBody.position.y, fontSize);
        GUI.Label(new Rect(20, 140, 200, 50), "moving:     " + anim.GetBool("moving"), fontSize);
        GUI.Label(new Rect(20, 170, 200, 50), "dirRight:   " + anim.GetBool("dirRight"), fontSize);
        GUI.Label(new Rect(20, 200, 200, 50), "inTheAir:  " + anim.GetBool("inTheAir"), fontSize);
        GUI.Label(new Rect(20, 230, 200, 50), "dirLeft:   " + anim.GetBool("dirLeft"), fontSize);
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
