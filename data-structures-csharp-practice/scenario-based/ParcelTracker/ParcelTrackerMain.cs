using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.data_structure_csharp_practice.scenario_based.ParcelTracker
{
    /// <summary>
    /// The Parcel Tracker Program Simulates a Parcel Delivery Through its Various Transition State At Its Basic Levels
    /// It Uses Linked List To Store And Move Between Various Stages Only One Way (Forward)
    /// We Can Add Parcel, Move Parcel, Add CheckPoint And Track Parcels
    /// 
    /// version - 1.0
    /// </summary>
    // Main Class Containing Starting Point Of Our Program
    internal class ParcelTrackerMain
    {
        static void Main(string[] args)
        {
            ParcelTrackerMenu start = new ParcelTrackerMenu();
            start.Menu();
        }
    }
}
