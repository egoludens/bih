using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskInstruction {

    public Form Form { get; set; }
    public List<DeskInstructionParagraph> Paragraphs { get; set; }

    public DeskInstruction(Form form)
    {
        Paragraphs = new List<DeskInstructionParagraph>();
        Form = form;
    }

    public void AddParagraph(DeskInstructionParagraph paragraph)
    {
        Paragraphs.Add(paragraph);
    }

}
