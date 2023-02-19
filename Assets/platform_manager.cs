using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_manager : MonoBehaviour
{
    public GameObject platform;
    public List<GameObject> roofPlatforms = new List<GameObject>();
    public List<GameObject> groundPlatforms = new List<GameObject>();
    public float maxGap = 6f; //max gap has to be greater than min gap
    public float minGap = 3f;
    public float platform_window_buffer = 0.5f;
    private float platformMaxGap;  
    private float platformMinGap;
    private float height_of_screen;
    float height;
    float width;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 topRightCorner = new Vector2(1, 1);
        Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
        height = edgeVector.y * 2;
        width = edgeVector.x * 2;
        //width = height * Screen.width / Screen.height;
        platformMaxGap = width / (maxGap / 2);
        platformMinGap = width / (minGap * 2);
        instantiatePlatforms();
    }

    // Update is called once per frame
    void Update()
    {
       check_platforms();
       create_new_platform();
    }

    void check_platforms()
    {
        for(int i = 0; i < roofPlatforms.Count; i++)
        {
            if(roofPlatforms[i].transform.position.x < width)
            {
                //it is off screen
                roofPlatforms.Remove(roofPlatforms[i]);
            }
        }
        for (int i = 0; i < groundPlatforms.Count; i++)
        {
            if (groundPlatforms[i].transform.position.x < width)
            {
                //it is off screen
                groundPlatforms.Remove(groundPlatforms[i]);
            }
        }
    }

    void create_new_platform()
    {
        if(groundPlatforms.Count < 3)
        {
            GameObject new_platform = Instantiate(platform);
            Vector3 platform_pos = new Vector3(2 * width, -height / 2 + platform_window_buffer, 1);
            new_platform.transform.position = platform_pos;
            groundPlatforms.Add(new_platform);
            Vector3 platformSize = new
                Vector3(width - Random.Range(platformMinGap, platformMaxGap), new_platform.transform.localScale.y, new_platform.transform.localScale.z);
            new_platform.transform.localScale = platformSize;
        }
        if (roofPlatforms.Count < 4)
        {
            GameObject new_platform = Instantiate(platform);
            Vector3 platform_pos = new Vector3(3 * width - width / 2, height / 2 - platform_window_buffer, 1);
            new_platform.transform.position = platform_pos;
            roofPlatforms.Add(new_platform);
            Vector3 platformSize = new
                Vector3(width - Random.Range(platformMinGap, platformMaxGap), new_platform.transform.localScale.y, new_platform.transform.localScale.z);
            new_platform.transform.localScale = platformSize;
        }
    }

    void instantiatePlatforms()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject new_platform = Instantiate(platform);
            if (i < 3)
            {
                Vector3 platform_pos = new Vector3(i * width, -height / 2 + platform_window_buffer, 1);
                new_platform.transform.position = platform_pos;
                groundPlatforms.Add(new_platform);
            }
            else
            {
                Vector3 platform_pos = new Vector3((i - 3) * width - width / 2, height / 2 - platform_window_buffer, 1);
                new_platform.transform.position = platform_pos;
                roofPlatforms.Add(new_platform);
            }
            Vector3 platformSize = new
                Vector3(width - Random.Range(platformMinGap, platformMaxGap), new_platform.transform.localScale.y, new_platform.transform.localScale.z);
            new_platform.transform.localScale = platformSize;
        }
    }
}
