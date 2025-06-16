using System;

namespace Station
{
    public class PassengerTrain : Train
    {
        private int numberOfCarriages;
        private int capacity;

        public PassengerTrain(string id, TrainStatus status, int arrivalTime, string type, int numberOfCarriages, int capacity) : base(id, status, arrivalTime, type)
        {
            this.numberOfCarriages = numberOfCarriages;
            this.capacity = capacity;
        }

        public int GetNumberCarriages()
        {
            return this.numberOfCarriages;
        }

        public void SetNumberCarriages(int num)
        {
            this.numberOfCarriages = num;
        }

        public int GetCapacity()
        {
            return this.capacity;
        }

        public void SetCapacity(int cap)
        {
            this.capacity = cap;
        }
    }
}