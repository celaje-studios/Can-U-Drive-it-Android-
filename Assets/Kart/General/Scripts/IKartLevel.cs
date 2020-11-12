using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKartLevel
{
    void StartRace();

    void FinishRace();

    void SaveRaceResults();
}