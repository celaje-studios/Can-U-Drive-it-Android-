using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [Header("Public References")]
    [SerializeField]
    public GroundTypes groundType;

    //Variables Privadas
    public enum GroundTypes {_pista, _tierra, _grama, _nieve, _agua, _roca};

    /**********************************************************************
    *
    * pista  - 0
    * tierra - 1
    * grama  - 2
    * nieve  - 3
    * agua   - 4
    * roca   - 5
    *
    * no ground type - 6
    *
    ***********************************************************************/

    public int getGroundType(){
        if(groundType == GroundTypes._pista){
            return 0;
        }else if (groundType == GroundTypes._tierra){
            return 1;
        }else if(groundType == GroundTypes._grama){
            return 2;
        }else if(groundType == GroundTypes._nieve){
            return 3;
        }else if(groundType == GroundTypes._agua){
            return 4;
        }else if(groundType == GroundTypes._roca){
            return 5;
        }else{
            return 6;
        }
    }
}
