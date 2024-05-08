using UnityEngine;
using Cinemachine;
public class PlayerController : MonoBehaviour
{
   public CinemachineVirtualCamera Cinemachine;
   private Rigidbody rb;
   [SerializeField] private float moveSpeed;
   private float _xInput, _zInput;

   private void Start()
   {
      rb = GetComponent<Rigidbody>();
      Cinemachine = GetComponent<CinemachineVirtualCamera>();
   }

   private void Update()
   {
      _xInput = Input.GetAxis("Horizontal");
      _zInput = Input.GetAxis("Vertical");
      
       
   }

   private void FixedUpdate()
   {
      float xVelocity = _xInput * moveSpeed;
      float zVelocity = _zInput * moveSpeed;

      rb.velocity = new Vector3(xVelocity, rb.velocity.y, zVelocity);
   }
}