using UnityEngine;

public class InputControls : MonoBehaviour
{
    Rigidbody rb;
    MusicPlayer musicPlayer;

    //locomotion
    [SerializeField] private float movementSpeed = 2f;//SerializeField makes private attributes visible an avaliable in the editor 
    public float baseSpeed;
    public float pitchYawSpeed;
    public float rollSpeed;
    private bool musicStopped = false;

    //defence
    public float projectileVelocity;
    public GameObject missile;
    public Transform shotPoint;

    public AudioSource source;
    public AudioClip gunFire;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        musicPlayer = GameObject.Find("Scene").GetComponent<MusicPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetKey used for continuous inputs (per frame)

        transform.position += baseSpeed * Time.deltaTime * -transform.right;

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (!musicStopped)
            {
                musicPlayer.source.enabled = false;
                musicPlayer.enabled = false;
                musicStopped = true;
            }
            else
            {
                musicPlayer.source.enabled = true;
                musicPlayer.enabled = true;
                musicStopped = false;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Time.deltaTime * movementSpeed * -transform.right;
            //Time.deltaTime is amount of time in seconds since last update called.
            //game thinks left == forward
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Time.deltaTime * movementSpeed * transform.right;
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-rollSpeed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(rollSpeed, 0f, 0f);
        }
        PitchAndYaw();

        //weapon controls
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject createdMissile = Instantiate(missile, shotPoint.position, shotPoint.rotation);
            createdMissile.GetComponent<Rigidbody>().velocity = -shotPoint.transform.right * projectileVelocity;
            source.PlayOneShot(gunFire);
        }

        //resets player objects inertia after collsion
        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
        } 

    }
    void PitchAndYaw()
    {
        transform.Rotate(0f, pitchYawSpeed*Input.GetAxis("Mouse X"), pitchYawSpeed*-Input.GetAxis("Mouse Y"));
    }
}

