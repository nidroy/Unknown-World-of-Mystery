using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRequest
{
    public string Execute(string connectionString);
}
