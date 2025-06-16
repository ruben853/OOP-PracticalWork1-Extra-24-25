using System;

namespace Station
{
    public enum TrainStatus
    {
        EnRoute,
        Waiting,
        Docking,
        Docked
    }
    public abstract class Train
    {
        protected string id;
        protected TrainStatus status;
        protected int arrivalTime;
        protected string type;

        public Train(string id, TrainStatus status, int arrivalTime, string type)
        {
            this.id = id;
            this.status = status;
            this.arrivalTime = arrivalTime;
            this.type = type;
        }

        public string GetId()
        {
            return this.id;
        }

        public void SetId(string id)
        {
            this.id = id;
        }

        public TrainStatus GetStatus()
        {
            return this.status;
        }

        public void SetStatus(TrainStatus status)
        {
            this.status = status;
        }

        public int GetArrivalTime()
        {
            return this.arrivalTime;
        }

        public void SetArrivalTime(int time)
        {
            this.arrivalTime = time;
        }

        public string GetTrainType()
        {
            return this.type;
        }

        public void SetTrainType(string type)
        {
            this.type = type;
        }

        public virtual void AdvanceTick(double hours)
        {
            if (this.status == TrainStatus.EnRoute && this.arrivalTime > 0)
            {
                int timeReduction = (int)(hours * 60);
                this.arrivalTime -= timeReduction;
                if (this.arrivalTime < 0)
                {
                    this.arrivalTime = 0;
                }

                if (this.arrivalTime == 0)
                {
                    this.status = TrainStatus.Waiting;
                }
            }
        }

    }
}