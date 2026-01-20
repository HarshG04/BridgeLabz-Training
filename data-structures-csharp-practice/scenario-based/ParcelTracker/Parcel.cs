using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.data_structure_csharp_practice.scenario_based.ParcelTracker
{
    // Encapsulated Parcel Class
    internal class Parcel
    {
        private static int NextID = 101;
        public string ParcelID { get; set; }
        
        // Parcel Status Containing The Node of the current Status
        public StageNode ParcelStatus {get; set;}

        // Constructor
        public Parcel()
        {
            this.ParcelID = "P"+NextID++;
            ParcelStatus = new StageNode();
        }

        // Move parcel to next system-defined stage
        public void Move()
        {
            StageNode current = ParcelStatus;

            while (current.Next != null)
                current = current.Next;

            // Stop if already delivered
            if (current.CurrentStage == "Delivered")
                return;

            current.Next = new StageNode(current.StageIdx);
        }

        // Add custom checkpoint
        public void AddCheckPoint(string checkpoint)
        {
            StageNode current = ParcelStatus;

            while (current.Next != null) current = current.Next;

            current.Next = new StageNode(checkpoint, current.StageIdx);
        }

        // Mark parcel as lost (null pointer handling)
        public void MarkLost()
        {
            StageNode current = ParcelStatus;

            while (current.Next != null) current = current.Next;

            current.Next = null; 
        }

        // Track parcel
        public void Track()
        {
            StageNode current = ParcelStatus;
            Console.Write($"Parcel {ParcelID}: ");

            while (current != null)
            {
                Console.Write(current.CurrentStage);
                Console.Write(current.Next != null ? " -> " : " -> null");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}
