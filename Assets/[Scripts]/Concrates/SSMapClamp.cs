using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSMapClamp : MonoBehaviour
{
    Transform ship;
    public SSMapClamp(Transform _ship)
    {
        ship = _ship;
    }
    public void MapClamp()
    {
        if(ship.position.x>2000||ship.position.y>2000||ship.position.z>2000|| ship.position.x < -2000 || ship.position.y < -2000 || ship.position.z < -2000)
        {
            SSWarning.isWarning = true;
        }
        else
        {
            SSWarning.isWarning = false;

        }
    }
}
