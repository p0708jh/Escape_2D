using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private float cycleInterval = 0.01f;

    private List<ChargedPartcle> chargedParticles;
    private List<MovingChargedPartcle> movingChargedParticles;

    // Start is called before the first frame update
    void Start()
    {
        chargedParticles = new List<ChargedPartcle>(FindObjectsOfType<ChargedPartcle>());
        movingChargedParticles = new List<MovingChargedPartcle>(FindObjectsOfType<MovingChargedPartcle>());

        foreach (MovingChargedPartcle mcp in movingChargedParticles)
        {
            //Debug.Log(mcp.name);
            //if(mcp.name !="player")
            StartCoroutine(Cycle(mcp));
        }

    }

    public IEnumerator Cycle(MovingChargedPartcle mcp)
    {
        bool isFirst = true;

        while (true)
        {
            if (isFirst)
            {
                isFirst = false;
                yield return new WaitForSeconds(Random.Range(0,cycleInterval));
            }
            ApplyMagneticForce(mcp);
            yield return new WaitForSeconds(cycleInterval);
        }
      
    }

    private void ApplyMagneticForce(MovingChargedPartcle mcp)
    {
        Vector3 newForce = Vector3.zero;

        foreach (ChargedPartcle cp in chargedParticles)
        {
            if (mcp == cp)
                continue;
            float distance = Vector3.Distance(mcp.transform.position, cp.gameObject.transform.position);
            //Debug.Log(distance);
            float force = 1000 * mcp.charge * cp.charge / Mathf.Pow(distance, 2);

            Vector3 direction = mcp.transform.position - cp.transform.position;
            direction.Normalize();

            /*
            if(distance<1f)
                newForce += direction * cycleInterval;
            else
                */
                newForce += force * direction * cycleInterval;

            if (float.IsNaN(newForce.x))
                newForce = Vector3.zero;

            mcp.rb.AddForce(newForce);
        }
    }
}
