using System;
using UnityEngine;

// Error and Exception Helper Script
public class ErrorHelper : MonoBehaviour
{
    
    /// <summary>
    /// This function throws a new exception upon the given object returning null.
    /// </summary>
    /// <param name="checkObject"> Any given object</param>
    /// <param name="msg"> String for exception display and trace</param>
    public static void LogNullError(object checkObject, string msg)
    {
        if (checkObject == null)
        {
            throw new Exception(msg);
        }
    }
    
}
