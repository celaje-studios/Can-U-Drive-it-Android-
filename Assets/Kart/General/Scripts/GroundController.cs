using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [Header("Public References")]
    [SerializeField]
    public GroundTypes groundType;

    //Variables Privadas
    public enum GroundTypes {_pista, _tierra, _grama, _nieve, _agua};
}
