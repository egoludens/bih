using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskInstructionParagraph {

    public FormFieldType FieldType { get; set; }
    public WhoFillsTheField WhoFillsTheField { get; set; }

    public DeskInstructionParagraph(FormFieldType fieldType, WhoFillsTheField whoFillsTheField)
    {
        FieldType = fieldType;
        WhoFillsTheField = whoFillsTheField;
    }
}
