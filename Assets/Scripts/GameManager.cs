using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        
            PhotonNetwork.Instantiate("Warrior-P1", new Vector3(2,2,0), Quaternion.identity);
        else
            PhotonNetwork.Instantiate("Fox-P2", new Vector3(3,2,0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
