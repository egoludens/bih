using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form {

    public string FormTypeId { get; set; }
    public List<FormField> Fields { get; set; }

    public Form(string formTypeId)
    {
        FormTypeId = formTypeId;
        Fields = new List<FormField>();
    }

    public void AddField(FormFieldType fieldType, bool canFillVisitor, bool canFillClerk)
    {
        var newField = new FormField()
        {
            FieldType = fieldType,
            CanFillVisitor = canFillVisitor,
            CanFillClerk = canFillClerk
        };
        Fields.Add(newField);
    }

}
