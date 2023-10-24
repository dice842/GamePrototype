using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLever : MonoBehaviour
{
    private int _MaxLever = 5;

    [SerializeField] int skillPoint = 0;

    [SerializeField] int marksmanship = 0;
    [SerializeField] int technology = 0;
    [SerializeField] int infiltration = 0;
    [SerializeField] int medicine = 0;
    [SerializeField] int physical = 0;

    public int Marksmanship { get { return marksmanship; } }
    public int Technology { get { return technology; } }
    public int Infiltration { get {  return infiltration; } }
    public int Medicine { get {  return medicine; } }
    public int Physical { get { return physical; } }


    public void UPtoMarksmanship() 
    {
        if ( skillPoint > 0)
        {
            if( marksmanship < _MaxLever)
            {
                skillPoint--;
                marksmanship++;
            }
        }
    }
    public void UPtoTechnology()
    {
        if (skillPoint > 0)
        {
            if (technology < _MaxLever)
            {
                skillPoint--;
                technology++;
            }
        }
    }
    public void UPtoInfiltration()
    {
        if (skillPoint > 0)
        {
            if (infiltration < _MaxLever)
            {
                skillPoint--;
                infiltration++;
            }
        }
    }
    public void UPtoMedicine()
    {
        if (skillPoint > 0)
        {
            if (medicine < _MaxLever)
            {
                skillPoint--;
                medicine++;
            }
        }
    }
    public void UPtoPhysical()
    {
        if (skillPoint > 0)
        {
            if (physical < _MaxLever)
            {
                skillPoint--;
                physical++;
            }
        }
    }


}
