using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.data_structure_csharp_practice.scenario_based.ParcelTracker
{
    internal interface IParcelTracker
    {
        void AddParcel();
        void ParcelMove();
        void AddCheckPoint(string checkPoint);
        void TrackParcel();
    }
}
