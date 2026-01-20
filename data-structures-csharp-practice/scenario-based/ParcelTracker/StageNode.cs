using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.data_structure_csharp_practice.scenario_based.ParcelTracker
{
    // Encapsulated Stage Class Containing Parcel Status And Other Fields
    internal class StageNode
    {
        private static string[] stages = { "Packed", "Shipped", "In Transit", "Delivered" };
        
        public int StageIdx { get; set; }
        public string CurrentStage { get; set; }
        public StageNode Next { get; set; }

        // First node
        public StageNode()
        {
            StageIdx = 0;
            CurrentStage = stages[StageIdx];
            Next = null;
        }

        // Next node
        public StageNode(int previousIdx)
        {
            StageIdx = previousIdx + 1;

            if (StageIdx >= stages.Length) StageIdx = stages.Length - 1;

            CurrentStage = stages[StageIdx];
            Next = null;
        }

        // Custom checkpoint stage
        public StageNode(string customStage, int previousIdx)
        {
            StageIdx = previousIdx + 1;
            CurrentStage = customStage;
            Next = null;
        }
    }
}
