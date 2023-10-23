using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLever : MonoBehaviour
{
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

    public void UPtoMarksmanship() { marksmanship++; }
    public void UPtoTechnology() { technology++; }
    public void UPtoInfiltration() { infiltration++; }
    public void UPtoMedicine() {  medicine++; }
    public void UPtoPhysical() { physical++; }


}
