using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora.rtc;
public class VoiceChatManager : MonoBehaviour
{
    string appID = "157b7a11bbfa4c8486192f9434bb8ada";
    IRtcEngine mRtcEngine;
    public static VoiceChatManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mRtcEngine = IRtcEngine.GetEngine(appID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
