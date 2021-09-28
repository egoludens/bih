using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameFactory {

    public static Game GenerateTestGame()
    {
        var testLevel = new Level(5, 4);

        var testForm = new Form("Test Portal Access Request");
        testForm.AddField(FormFieldType.Name, true, false);
        testForm.AddField(FormFieldType.Destination, true, false);
        testForm.AddField(FormFieldType.Date, true, true);
        testLevel.AddForm(testForm);

        var testInstruction = new DeskInstruction(testForm);
        testInstruction.AddParagraph(new DeskInstructionParagraph(FormFieldType.Date, WhoFillsTheField.Clerk));
        testInstruction.AddParagraph(new DeskInstructionParagraph(FormFieldType.Name, WhoFillsTheField.Visitor));
        testInstruction.AddParagraph(new DeskInstructionParagraph(FormFieldType.Destination, WhoFillsTheField.Visitor));
        testLevel.AddInstruction(testInstruction);

        var testOutboundPortal = LevelObjectFactory.CreatePortal(0, 1, PortalType.Outbound);
        testOutboundPortal.RequiredForms.Add(testForm);
        testLevel.AddObject(testOutboundPortal);

        var testDesk = LevelObjectFactory.CreateDesk(2, 1);
        testDesk.AddInstruction(testInstruction);
        testLevel.AddObject(testDesk);

        var testInboundPortal = LevelObjectFactory.CreatePortal(4, 1, PortalType.Inbound);
        testInboundPortal.SpawnSchedule.Items.Add(new CustomerSpawnScheduleItem(3f, 1, 5f, testOutboundPortal));
        testLevel.AddObject(testInboundPortal);

        testLevel.AddActor(new LevelActorClerk(2, 1));


        var newGame = new Game()
        {
            CurrentLevel = testLevel
        };
        return newGame;
    }

}
