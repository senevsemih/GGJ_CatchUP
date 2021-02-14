using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    public void NextLevel()
    {
        LevelChanger.Instance.OpeningLoadLevel();
    }
}
