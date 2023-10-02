using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour{

    [Header("Character")]
    [SerializeField] private Animator animator;

    [Header("Movement")]
    [SerializeField] private float speed = 0.0f;
    [SerializeField] private float jumpForce = 0.0f;
    public bool ascend = false; // variable provisional para ejecutar la animación de ascend, que no sé para qué se va a usar

    [Header("Audio")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip walkClip;
    [SerializeField] private AudioClip fallClip;

    private Rigidbody2D body;
    private AudioSource _audio;
    private EnemyMovement enemy;

    [SerializeField] private bool isGrounded;
    private int xScale;
    private bool isAudioPlaying;

    private void Start(){

        body = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
        enemy = FindObjectOfType<EnemyMovement>();
        _audio.clip = walkClip;

        isGrounded = true;
        xScale = 1;
    }

    private void Update(){
        Move();
    }

    private void Move(){
        Walk();
        Ascend();
    }


    private void Walk()
    {   
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            xScale = 1;
        }
        else if (horizontalInput < 0)
        {
            xScale = -1;
        }

        transform.localScale = new Vector3(xScale, 1, 1);
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


        if (Input.GetKeyDown(KeyCode.W))
        {
            body.AddForce(new Vector2(0f, 1f) * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("Grounded", isGrounded);
            animator.SetTrigger("Jump");
            _audio.PlayOneShot(jumpClip, 0.5f);
        }
       

        if (Mathf.Abs(horizontalInput) > 0)
        {
            animator.SetFloat("Speed", 1);
            if (!isAudioPlaying && isGrounded)
            {
                StartCoroutine(PlayClip(walkClip, 0.1f));
            }
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    
    }

    private void Ascend(){
        if (ascend){
            animator.SetBool("Ascend", true);
        }
    }

    private void Death(){
        GameManager.instance.state = GameState.gameOver;
        enemy.rotationSpeed = 0;
        enemy.moveSpeed = 0;
        this.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Ground"))
            {
            if (!isGrounded){
                _audio.PlayOneShot(fallClip, 0.5f);
            }
            isGrounded = true;
            animator.SetBool("Grounded", isGrounded);
        }

        if (collision.gameObject.CompareTag("Enemy")){
            Death();
        }
    }

    private IEnumerator PlayClip(AudioClip clip, float volume){
        isAudioPlaying = true;
        _audio.PlayOneShot(clip, volume);
        yield return new WaitForSeconds(clip.length);
        isAudioPlaying = false;
    }
}