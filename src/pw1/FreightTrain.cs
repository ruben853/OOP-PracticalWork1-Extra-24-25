using System;

namespace Station
{
    public class FreightTrain : Train
    {
        private int maxWeight;
        private string freightType;
        public FreightTrain(string id, TrainStatus status, int arrivalTime, string type, int maxWeight, string freightType) : base(id, status, arrivalTime, type)
        {
            this.maxWeight = maxWeight;
            this.freightType = freightType;
        }

        public int GetMaxWeight()
        {
            return this.maxWeight;
        }

        public void SetMaxWeight(int num)
        {
            this.maxWeight = num;
        }

        public string GetFreighttype()
        {
            return this.freightType;
        }

        public void SetFreightType(string type)
        {
            this.freightType = type;
        }
    }
}