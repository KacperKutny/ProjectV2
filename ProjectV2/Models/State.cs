using ProjectV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum StateType
{
    Broken,
    Running
}

public class State
{

    public int StateId { get; set; }
    public DateTime DateOfDamage { get; set; }
    public DateTime DateOfRepair { get; set; }

    public ICollection<CarState> CarStates { get; set; } = null!;
    public State(DateTime dateOfDamage, DateTime dateOfRepair)
    {
        DateOfDamage = dateOfDamage;
        DateOfRepair = dateOfRepair;
    }

}
