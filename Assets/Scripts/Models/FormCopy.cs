using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormCopy {

    public Form Form { get; set; }
    public List<FormFieldType> CompletedFields {get; set;}

    public bool FormCompleted()
    {
        foreach(var field in Form.Fields)
        {
            if (!CompletedFields.Contains(field.FieldType))
                return false;
        }
        return true;
    }

}
