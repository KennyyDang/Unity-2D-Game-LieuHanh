using UnityEngine;

public class ParalaxBackground : MonoBehaviour
{
        // private GameObject cam;
        //
        // [SerializeField] private float parallaxEffect;
        //
        // private float xPosition;
        // private float length;
        //
        // // Start is called once before the first execution of Update after the MonoBehaviour is created
        // void Start()
        // {
        //     cam = GameObject.Find("Main Camera");
        //
        //     length = GetComponent<SpriteRenderer>().bounds.size.x;
        //     xPosition = transform.position.x;
        // }
        //
        // // Update is called once per frame
        // void Update()
        // {
        //     float distanceMoved = cam.transform.position.x * (1 - parallaxEffect);
        //     float distanceToMove = cam.transform.position.x * parallaxEffect;
        //
        //     transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);
        //
        //     if (distanceMoved > xPosition + length)
        //         xPosition += length;
        //     else if (distanceMoved < xPosition - length)
        //         xPosition -= length;
        // }
        
        public Transform mainCam;
        public Transform midBg;
        public Transform sideBg;
        public float lenght;
// Update is called once per frame
        void Update()
        {
                if (mainCam.position.x > midBg.position.x)
                {
                        UpdateBackgroundPosition(Vector3.right);
                }
                else if (mainCam.position.x < midBg.position.x)
                {
                        UpdateBackgroundPosition(Vector3.left);
                }
        }
        void UpdateBackgroundPosition(Vector3 direction)
        {
                sideBg.position = midBg.position + direction * lenght;
                Transform temp = midBg;
                midBg = sideBg;
                sideBg = temp;
        }
}
